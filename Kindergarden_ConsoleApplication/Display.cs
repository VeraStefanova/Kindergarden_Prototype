using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kindergarden_ConsoleApplication
{
    /// <summary>
    /// Represents the user interface for managing kindergarten data, including CRUD operations for kids, parents, and groups.
    /// </summary>
    public class Display
    {
        private int closeOperationId = 9;
        private readonly KidService kidService;
        private readonly ParentService parentService;
        private readonly GroupService groupService;
        private readonly KindergardenDbContext db;

        /// <summary>Initializes a new instance of the <see cref="Display" /> class.</summary>
        public Display()
        {
            this.db = new KindergardenDbContext();
            db.Database.EnsureCreated();
            this.kidService = new KidService(db);
            this.parentService = new ParentService(db);
            this.groupService = new GroupService(db);
            Input();
        }

        /// <summary>Shows the menu.</summary>
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all kids");
            Console.WriteLine("2. List all groups");
            Console.WriteLine("3. List all parents");
            Console.WriteLine("4. Search kid and parent");
            Console.WriteLine("5. Create kid");
            Console.WriteLine("6. Update kid");
            Console.WriteLine("7. Update parent");
            Console.WriteLine("8. Delete kid");
            Console.WriteLine("9. Exit");


        }
        /// <summary>Awaits the choice of the user.</summary>
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (operation)
                {
                    case 1:
                        ListAllKids();
                        break;
                    case 2:
                        ListAllGroups();
                        break;
                    case 3:
                        ListAllParents();
                        break;
                    case 4:
                        FetchKidAndParent();
                        break;
                    case 5:
                        CreateKid();
                        break;
                    case 6:
                        UpdateKid();
                        break;
                    case 7:
                        UpdateParent();
                        break;
                    case 8:
                        DeleteKid();
                        break;
                    default:
                        break;
                }
                return;
            } while (operation != closeOperationId);
        }

        /// <summary>Lists all kids.</summary>
        private void ListAllKids()
        {
            Console.Clear();
            List<Kid> kidsList = db.Kids.ToList();
            Kid kid;
            Parent parent;
            Group group;
            foreach (var kid1 in kidsList)
            {
                 kid = kid1;
                 group = db.Groups.FirstOrDefault(x=>x.GroupId==kid.GroupId);
                 parent = db.Parents.FirstOrDefault(y => y.ParentId == kid.ParentId);

                if(kid== null)
                {
                    Console.WriteLine("No kid found!");
                    break;
                }
                Console.WriteLine($"Kid name: {kid.FirstName + " " + kid.LastName}, Age: {kid.Age}, " +
                    $"Parent name: {parent.FirstName + " " + parent.LastName}, Parent phone number: {parent.PhoneNumber}, " +
                    $"Address: {parent.Address}, Group: {group.GroupName}");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();

        }

        /// <summary>Lists all groups.</summary>
        private void ListAllGroups()
        {
            Console.Clear();
            for (int i = 1; i <= 4; i++)
            {
                Group group = groupService.Fetch(i);
                Console.WriteLine($"Group: {group.GroupName}");
                foreach (var kid in db.Kids.Where(x => x.GroupId == group.GroupId))
                {
                    Console.Write($"{kid.FirstName + " " + kid.LastName}; ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();

        }
        /// <summary>Lists all parents.</summary>
        private void ListAllParents()
        {
            Console.Clear();
            var parentsList = db.Parents.ToList();
            foreach (var parent1 in parentsList)
            {
                Parent parent = parentService.Fetch(parent1.ParentId);
                Console.WriteLine($"Parent name: {parent.FirstName + " " + parent.LastName}, " +
                    $"Parent phone number: {parent.PhoneNumber}, Address: {parent.Address}");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();

        }

        /// <summary>Fetches the kid and parent.</summary>
        private void FetchKidAndParent()
        {
            Console.Clear();
            Console.Write("Enter kid's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                FetchKidAndParent();
                return;
            }
            List<Kid> kidsWithThisName = new List<Kid>();
            Kid kid = kidService.FetchKidAndParent(name);

            if (kid == null)
            {
                Console.WriteLine("There is no kid with this name!");
                Console.WriteLine("1. Enter name again");
                Console.WriteLine("2. Go back to main menu");
                int choice = int.Parse(Console.ReadLine());
                bool n = true;
                while (n)
                {
                    if (choice == 1)
                    {
                        FetchKidAndParent();
                        return;
                    }
                    else if (choice == 2)
                    {

                        Input();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                        choice = int.Parse(Console.ReadLine());
                    }
                }

            }
            else
            {
                kid.Parent = db.Parents.FirstOrDefault(x => x.ParentId == kid.ParentId);
                kid.Group = db.Groups.FirstOrDefault(x => x.GroupId == kid.GroupId);

                foreach (var kid1 in db.Kids)
                {
                    if (kid1.FirstName == name)
                    {
                        kidsWithThisName.Add(kid1);
                    }
                }
                for (int i = 1; i <= kidsWithThisName.Count; i++)
                {
                    Console.WriteLine($"{i}. Kid name: {kidsWithThisName[i-1].FirstName + " " + kidsWithThisName[i-1].LastName}," +
                        $" Age: {kidsWithThisName[i-1].Age}, Group: {kidsWithThisName[i-1].Group.GroupName}," +
                        $" Parent name: {kidsWithThisName[i - 1].Parent.FirstName + " " + kidsWithThisName[i-1].Parent.LastName}, " +
                        $"Parent phone number: {kidsWithThisName[i - 1].Parent.PhoneNumber}, Address: {kidsWithThisName[i - 1].Parent.Address}");
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();    

        }

        /// <summary>Updates the kid.</summary>
        private void UpdateKid()
        {
            Console.Clear();
            Console.Write("Enter kid's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                UpdateKid();
                return;
            }
            List<Kid> kidsWithThisName = new List<Kid>();
            Kid kid = kidService.FetchKidAndParent(name);
            if (kid == null)
            {
                Console.WriteLine("There is no kid with this name!");
                Console.WriteLine("1. Enter name again");
                Console.WriteLine("2. Go back to main menu");
                int choice = int.Parse(Console.ReadLine());
                bool n = true;
                while (n)
                {
                    if (choice == 1)
                    {
                        UpdateKid();
                        return;
                    }
                    else if (choice == 2)
                    {
                        Input();
                        return;
                        
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                        choice = int.Parse(Console.ReadLine());
                    }
                }
            }
            else
            {
                foreach (var kid1 in db.Kids)
                {
                    if (kid1.FirstName == name)
                    {
                        kidsWithThisName.Add(kid1);
                    }
                }
                for (int i = 1; i <= kidsWithThisName.Count; i++)
                {
                    Console.WriteLine($"{i}. Name: {kidsWithThisName[i-1].FirstName + " " + kidsWithThisName[i-1].LastName}, Age: {kidsWithThisName[i-1].Age}");
                }
                Console.Write("Please, enter the id of your choice: ");
                Kid selectedKid = kidsWithThisName[int.Parse(Console.ReadLine()) - 1];

                Console.WriteLine("1.Update name.");
                Console.WriteLine("2.Update age.");
                int choice = int.Parse(Console.ReadLine());
                bool n = true;
                while (n)
                {
                    if (choice == 1)
                    {
                        Console.Write("Enter kid's new full name: ");
                        string newName = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(newName))
                        {
                            Console.WriteLine("You must type a name!");
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            UpdateKid();
                            return;
                        }
                        n = false;
                        kidService.UpdateName(selectedKid.KidId, newName);
                        Console.WriteLine("Name has been successfully updated.");

                    }
                    else if (choice == 2)
                    {
                        Console.Write("Enter kid's new age: ");
                        int newAge = int.Parse(Console.ReadLine());
                        if (newAge < 3 || newAge > 6 || newAge.ToString().Count()==0)
                        {
                            Console.WriteLine("You must type a valid age!");
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            UpdateKid();
                            return;
                        }
                        n = false;
                        kidService.UpdateAge(selectedKid.KidId, newAge);
                        Console.WriteLine("Age has been successfully updated.");

                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                        choice = int.Parse(Console.ReadLine());
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();


        }
        /// <summary>Updates the parent.</summary>
        private void UpdateParent()
        {
            Console.Clear();
            Console.Write("Enter parent's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                UpdateParent();
                return;
            }
            List<Parent> parentsWithThisName = new List<Parent>();
            Parent parent = db.Parents.FirstOrDefault(x => x.FirstName == name);
            if (parent == null)
            {
                Console.WriteLine("There is no parent with this name!");
                Console.WriteLine("1. Enter name again");
                Console.WriteLine("2. Go back to main menu");

                int choice = int.Parse(Console.ReadLine());
                bool n = true;
                while (n)
                {
                    if (choice == 1)
                    {
                        UpdateParent();
                        return;
                    }
                    else if (choice == 2)
                    {

                        Input();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                        choice = int.Parse(Console.ReadLine());
                    }
                }
            }
            else
            {
                foreach (var parentSearch in db.Parents)
                {
                    if (parentSearch.FirstName == name)
                    {
                        parentsWithThisName.Add(parentSearch);
                    }
                }
                for (int i = 1; i <= parentsWithThisName.Count; i++)
                {
                    Console.WriteLine($"{i}. Name: {parentsWithThisName[i-1].FirstName + " " + parentsWithThisName[i-1].LastName}, " +
                        $"Phone number: {parentsWithThisName[i-1].PhoneNumber}, Address: {parentsWithThisName[i - 1].Address}");
                }
                Console.Write("Please, enter the id of your choice: ");
                Parent selectedParent = parentsWithThisName[int.Parse(Console.ReadLine()) - 1]; //TODO: Change this row and some others

                Console.WriteLine("1.Update name.");
                Console.WriteLine("2.Update phone number.");
                Console.WriteLine("3.Update address.");

                int choice = int.Parse(Console.ReadLine());
                bool n = true;
                while (n)
                {
                    if (choice == 1) // update name
                    {
                        Console.Write("Enter parents's new full name: ");
                        string newName = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(newName))
                        {
                            Console.WriteLine("You must type a name!");
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            UpdateParent();
                            return;
                        }
                        parentService.UpdateName(selectedParent.ParentId, newName);
                        Console.WriteLine("Name has been successfully updated.");
                        n = false;
                    }
                    else if (choice == 2) // update phone number
                    {
                        Console.Write("Enter parent's new phone number: ");
                        string newPN = Console.ReadLine();
                        if (newPN.Count() != 10 && String.IsNullOrWhiteSpace(newPN))
                        {
                            Console.WriteLine("You must type a valid phone number!");
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            UpdateParent();
                            return;
                        }
                        parentService.UpdatePN(selectedParent.PhoneNumber, newPN);
                        Console.WriteLine("Phone number has been successfully updated.");
                        n = false;
                    }
                    else if (choice == 3) //update address
                    {
                        Console.Write("Enter parents's new address: ");
                        string newAddress = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(newAddress))
                        {
                            Console.WriteLine("You must type an addreess!");
                            Console.WriteLine();
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                            UpdateParent();
                            return;
                        }
                        parentService.UpdateAddress(selectedParent.Address, newAddress);
                        Console.WriteLine("Address has been successfully updated.");
                        n = false;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                        choice = int.Parse(Console.ReadLine());
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();

        }
        /// <summary>Creates the kid.</summary>
        private void CreateKid()
        {
            Console.Clear();
            Console.Write("Enter kid's first name:"); //kid First name
            string fName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(fName))
            {
                Console.WriteLine("You must type a first name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }

            Console.Write("Enter kid's last name:"); // kid Last name
            string lName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(lName))
            {
                Console.WriteLine("You must type a last name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }
            
            Console.Write("Enter kid's age:");      // kid Age
            int age = int.Parse(Console.ReadLine());
            if(String.IsNullOrEmpty(age.ToString()))
            {
                Console.WriteLine("You must type an age!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }
            else if (age<0 || age>120)
            {
                Console.WriteLine("You must type a valid age!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }
            else if(age<3|| age>6)
            {
                Console.WriteLine("This kid cannot be in our kindergarden!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }    


            Console.Write("Enter parents's first name:"); //Parent First name
            string parentFName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(parentFName))
            {
                Console.WriteLine("You must type first name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }


            Console.Write("Enter parents's last name:");  //Parent Last name
            string parentLName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(parentLName))
            {
                Console.WriteLine("You must type last name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }

            Console.Write("Enter parents's phone number:");  //Parent phone number
            string pn = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(pn))
            {
                Console.WriteLine("You must type a phone number!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }

            Console.Write("Enter parents's address:");  //Parent address
            string address = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("You must type an address!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }

            kidService.CreateKid(fName, lName, age, parentFName, parentLName, pn, address);
            Console.WriteLine("The kid has been successfully added to our kindergarden!");
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();
        }
        /// <summary>Deletes the kid.</summary>
        private void DeleteKid()
        {
            Console.Clear();
            Console.Write("Enter kid's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a first name!");
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                DeleteKid();
                return;
            }
            List<Kid> kidsWithThisName = new List<Kid>();
            Kid kid = db.Kids.FirstOrDefault(x=>x.FirstName == name);
           
            
            if (kid == null)
            {
                Console.WriteLine("There is no kid with this name!");
                Console.WriteLine("1. Enter name again");
                Console.WriteLine("2. Go back to main menu");
                int choice = int.Parse(Console.ReadLine());
                bool n = true;
                while (n)
                {
                    if (choice == 1)
                    {
                        DeleteKid();
                        return;
                    }
                    else if (choice == 2)
                    {

                        Input();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                        choice = int.Parse(Console.ReadLine());
                    }
                }
            }
            else
            { 
                Group group = db.Groups.FirstOrDefault(y => y.GroupId == kid.GroupId);
                Parent parents = db.Parents.FirstOrDefault(y => y.ParentId == kid.ParentId);
                foreach (var kidSearch in db.Kids)
                {
                    if (kidSearch.FirstName == name)
                    {
                        kidsWithThisName.Add(kidSearch);
                    }
                }
                for (int i = 1; i <= kidsWithThisName.Count; i++)
                {
                    Console.WriteLine($"{i}. Name: {kidsWithThisName[i-1].FirstName + " " + kidsWithThisName[i - 1].LastName}, Age: {kidsWithThisName[i - 1].Age}");
                }
                Console.Write("Please, enter the id of your choice: ");
                Kid selectedKid = kidsWithThisName[int.Parse(Console.ReadLine()) - 1];
                kidService.Delete(selectedKid.FirstName);
                Console.WriteLine("The kid has been successfully removed from our kindergarden.");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to go back to main menu.");
            Console.ReadLine();
            Input();

        }
    }
}


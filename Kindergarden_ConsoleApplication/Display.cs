using Kindergarden_Data;
using Kindergarden_Models;
using Kindergarden_Services;
using Kindergarden_Services.ViewModels;
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
    public class Display
    {
        private int closeOperationId = 9;
        private readonly KidService kidService;
        private readonly ParentService parentService;
        private readonly GroupService groupService;
        private readonly KindergardenDbContext db;

        public Display()
        {
            this.db = new KindergardenDbContext();
            db.Database.EnsureCreated();
            this.kidService = new KidService(db);
            this.parentService = new ParentService(db);
            this.groupService = new GroupService(db);
            Input();
        }

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
            } while (operation != closeOperationId);
        }

        private void ListAllKids()
        {
            Console.Clear();
            foreach (var kid in db.Kids)
            {
                KidViewModel kvm = kidService.FetchKidAndParent(kid.FirstName);
                Console.WriteLine($"Kid name: {kvm.Name}, Age: {kvm.Age}, Parent name: {kvm.ParentName}, Parent phone number: {kvm.PhoneNumber}, Address: {kvm.Address}, Group: {kvm.GroupName}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
            Input();

        }

        private void ListAllGroups()
        {
            Console.Clear();
            for (int i = 1; i <= 4; i++)
            {
                GroupViewModel gvm = groupService.Fetch(i);
                Console.WriteLine($"Group: {gvm.Name}");
                foreach (var kid in gvm.Kids)
                {
                    Console.Write($"{kid.FirstName + " " + kid.LastName}, ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
            Input();

        }
        private void ListAllParents()
        {
            Console.Clear();
            foreach (var parent in db.Parents)
            {
                ParentViewModel pvm = parentService.Fetch(parent.ParentId);
                Console.WriteLine($"Parent name: {pvm.Name}, Parent phone number: {pvm.PhoneNumber}, Address: {pvm.Address}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
            Input();

        }

        private void FetchKidAndParent()
        {
            Console.Clear();
            Console.Write("Enter kid's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a name!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                FetchKidAndParent();
                return;
            }
            List<Kid> kidsWithThisName = new List<Kid>();


            KidViewModel kvm = kidService.FetchKidAndParent(name);
            if (kvm == null)
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
                foreach (var kid in db.Kids)
                {
                    if (kid.FirstName == name)
                    {
                        kidsWithThisName.Add(kid);
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
            Console.WriteLine("Press any key to go back to main menu.");
            //Console.ReadLine();
            Input();    

        }

        private void UpdateKid()
        {
            Console.Clear();
            Console.Write("Enter kid's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a name!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                UpdateKid();
                return;
            }
            List<Kid> kidsWithThisName = new List<Kid>();
            KidViewModel kvm = kidService.FetchKidAndParent(name);
            if (kvm == null)
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
                foreach (var kid in db.Kids)
                {
                    if (kid.FirstName == name)
                    {
                        kidsWithThisName.Add(kid);
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
                        Console.Write("Enter kid's new name: ");
                        string newName = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(newName))
                        {
                            Console.WriteLine("You must type a name!");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            UpdateKid();
                            return;
                        }
                        kidService.UpdateName(selectedKid.KidId, newName);
                        Console.WriteLine("Name has been successfully updated.");

                    }
                    else if (choice == 2)
                    {
                        Console.Write("Enter kid's new age: ");
                        int newAge = int.Parse(Console.ReadLine());
                        if (newAge < 3 || newAge > 6 || newAge == null)
                        {
                            Console.WriteLine("You must type a valid age!");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            UpdateKid();
                            return;
                        }
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
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
            Input();


        }
        private void UpdateParent()
        {
            Console.Clear();
            Console.Write("Enter parent's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a name!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
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
                    Console.WriteLine($"{i}. Name: {parentsWithThisName[i-1].FirstName + " " + parentsWithThisName[i-1].LastName}, Phone number: {parentsWithThisName[i-1].PhoneNumber}");
                }
                Console.Write("Please, enter the id of your choice: ");
                Parent selectedParent = parentsWithThisName[int.Parse(Console.ReadLine()) - 1];

                Console.WriteLine("1.Update name.");
                Console.WriteLine("2.Update phone number.");
                Console.WriteLine("2.Update address.");

                int choice = int.Parse(Console.ReadLine());
                bool n = true;
                while (n)
                {
                    if (choice == 1) // update name
                    {
                        Console.Write("Enter parents's new name: ");
                        string newName = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(newName))
                        {
                            Console.WriteLine("You must type a name!");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            UpdateParent();
                            return;
                        }
                        parentService.UpdateName(selectedParent.ParentId, newName);
                        Console.WriteLine("Name has been successfully updated.");

                    }
                    else if (choice == 2) // update phone number
                    {
                        Console.Write("Enter parent's new phone number: ");
                        string newPN = Console.ReadLine();
                        if (newPN.Count() != 10 && String.IsNullOrWhiteSpace(newPN))
                        {
                            Console.WriteLine("You must type a valid phone number!");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            UpdateParent();
                            return;
                        }
                        parentService.UpdatePN(selectedParent.PhoneNumber, newPN);
                        Console.WriteLine("Phone number has been successfully updated.");

                    }
                    else if (choice == 3) //update address
                    {
                        Console.Write("Enter parents's new address: ");
                        string newAddress = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(newAddress))
                        {
                            Console.WriteLine("You must type an addreess!");
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            UpdateParent();
                            return;
                        }
                        parentService.UpdateAddress(selectedParent.Address, newAddress);
                        Console.WriteLine("Address has been successfully updated.");
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                        choice = int.Parse(Console.ReadLine());
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
            Input();

        }
        private void CreateKid()
        {
            Console.Clear();
            Console.Write("Enter kid's first name:"); //kid First name
            string fName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(fName))
            {
                Console.WriteLine("You must type a first name!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
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
                Console.WriteLine("Press any key to continue.");
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
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }
            else if (age<0 || age>120)
            {
                Console.WriteLine("You must type a valid age!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }
            else if(age<3|| age>6)
            {
                Console.WriteLine("This kid cannot be in our kindergarden!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
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
                Console.WriteLine("Press any key to continue.");
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
                Console.WriteLine("Press any key to continue.");
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
                Console.WriteLine("Press any key to continue.");
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
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                CreateKid();
                return;
            }

            kidService.CreateKid(fName, lName, age, parentFName, parentLName, pn, address);
            Console.WriteLine("The kid has been successfully added to our kindergarden!");
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
            Input();
        }

        private void DeleteKid()
        {
            Console.Clear();
            Console.Write("Enter kid's first name: ");
            string name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a first name!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
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
                foreach (var kidSearch in db.Kids)
                {
                    if (kidSearch.FirstName == name)
                    {
                        kidsWithThisName.Add(kidSearch);
                    }
                }
                for (int i = 1; i <= kidsWithThisName.Count; i++)
                {
                    Console.WriteLine($"{i}. Name: {kidsWithThisName[i-1].FirstName + " " + kidsWithThisName[i].LastName}, Age: {kidsWithThisName[i].Age}");
                }
                Console.Write("Please, enter the id of your choice: ");
                Kid selectedKid = kidsWithThisName[int.Parse(Console.ReadLine()) - 1];
                kidService.Delete(selectedKid.FirstName);
                
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
            Input();

        }
    }
}


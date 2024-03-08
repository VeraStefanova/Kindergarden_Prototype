using Kindergarden_Data;
using Kindergarden_Services;
using Kindergarden_Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            Console.WriteLine("4. Search kid and parent by ID");
            Console.WriteLine("5. Create kid");//
            Console.WriteLine("6. Update kid");
            Console.WriteLine("7. Update parent");
            Console.WriteLine("8. Delete");
            Console.WriteLine("9. Exit");
            
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
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
                        Delete();
                        break;
                    case 6:
                        CreateMovie();
                        break;
                    case 7:
                        ListAllMoviesByViewModel();
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
                KidViewModel kvm =  kidService.FetchKidAndParent(kid.FirstName);
                Console.WriteLine($"Kid name: {kvm.Name}, Age: {kvm.Age}, Parent name: {kvm.ParentName}, Parent phone number: {kvm.PhoneNumber}, Address: {kvm.Address}, Group: {kvm.GroupName}");
            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();
            ShowMenu();
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
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();
            ShowMenu();
        }
        private void ListAllParents()
        {
            Console.Clear();
            foreach (var parent in db.Parents)
            {
                ParentViewModel pvm = parentService.Fetch(parent.ParentId);
                Console.WriteLine($"Parent name: {pvm.Name}, Parent phone number: {pvm.PhoneNumber}, Address: {pvm.Address}");
            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();
            ShowMenu();
        }

        private void FetchKidAndParent()
        {
            Console.Clear();
            Console.Write("Enter kid name: ");
            string name = Console.ReadLine();
            if(String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("You must type a name!");
                FetchKidAndParent();
            }
            KidViewModel kvm = kidService.FetchKidAndParent(name);
            if(kvm==null)
            {
                Console.WriteLine("There is no kid with this name!");
                Console.WriteLine("1. Search again");
                Console.WriteLine("2. Go back to main menu");
                int choice = int.Parse(Console.ReadLine());

                do
                {
                    if (choice == 1)
                    {
                        FetchKidAndParent();
                    }
                    else if (choice == 2)
                    {

                        ShowMenu();
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option!");
                    }
                }
                while (choice != 1 && choice != 2);
                
            }
            else
            {
                Console.WriteLine($"Kid name: {kvm.Name}, Age: {kvm.Age}, Parent name: {kvm.ParentName}, Parent phone number: {kvm.PhoneNumber}, Address: {kvm.Address}, Group: {kvm.GroupName}");
            }

        }

    }
}

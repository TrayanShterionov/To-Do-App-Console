using System;
using ToDoAppM;

namespace ADisplay
{
   
    class Program
    {   
        static void Main(string[] args)
        {
            Business business = new Business();
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            CheckAccount(username,password,business);
        }

        static void CheckAccount(string username, string password, Business business)
        {
            var loginUser = business.Get(1);

            if (loginUser == null)
            {
                loginUser = new Users()
                {
                    Username = "Admin0",
                    Password = "",
                    Role = "Admin"
                };
                business.Add(loginUser);

            }
          

            var users = business.GetAll();

            foreach (var user in users)
            {
                if (user.Username == username
                    && user.Password == password
                    )
                {


                    Console.WriteLine("You succssefully logged in!");
                    if (user.Role == "Admin")
                    {
                        AdminMenu(business);
                    }
                    else
                    {
                       UserMenu();
                      
                    }
                }
            }

        }
        static void AdminMenu(Business business)
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("1. Delete user by Id");
            Console.WriteLine("2. Update user by Id");
            Console.WriteLine("3. Users Management View");
            Console.WriteLine("4. Create User");
            Console.WriteLine("5. log out");
            Console.WriteLine("========================");
            Console.WriteLine("Choose an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                
                    break;
                case "2":

                    break;
                case "3":
                    ShowUsers(business);
                    break;
                case "4":
                    DeleteUserById(business);
                    break;
                case "5":

                    break;
            }

        }

        static void UserMenu()
        {

        }

        static void DeleteUserById(Business business)
        {   
            Console.Clear();
            Console.WriteLine("Enter the Id of the user you want to delete: ");
            var deleteUserId = int.Parse(Console.ReadLine());
            if (IfUserExist(business, deleteUserId))
            {
                business.Delete(deleteUserId);
            }
            else
            {
                Console.WriteLine("User does not exist with this Id!");
                DeleteUserById(business);
            }
        }

        static bool IfUserExist(Business business, int id)
        {
            var users = business.GetAll();
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return true;
                }
                
            }
            return false;
        }
        static bool IfUsernameExist(Business business, string username)
        {
            var users = business.GetAll();
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    Console.WriteLine("Username already exist!");
                    return true;
                }

            }
            return false;
        }

        static void ShowUsers(Business business)
        {
            Console.Clear();
            var employees = business.GetAll();
            foreach (var employee in employees)
            {
                Console.WriteLine("Employee -> {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |\n", employee.Id, employee.Username, employee.Password, employee.FirstName,
                    employee.LastName, employee.Role,employee.DateOfCreation, employee.IdOfCreator, employee.LastChange, employee.UserThatDidTheLastChange);
            }
            Console.WriteLine("Do you want to list again? Y/N");
            var answer = Console.ReadLine();
            switch (answer)
            {
                case "Y":
                    ShowUsers(business);
                    break;
                case "y":
                    ShowUsers(business);
                    break;
                case "n":
                    AdminMenu(business);
                    break;
                case "N":
                    AdminMenu(business);
                    break;
            }
        }
        static void CreateUser(Business business)
        {
            Console.WriteLine("Enter a Username:");
            var username = Console.ReadLine();
            if (username == null)
            {
                Console.Clear();
                Console.WriteLine("Username cant be empty! Try again.");
                CreateUser(business);
            }
            else
            {
                IfUsernameExist(business, username);
            }
            Console.WriteLine("Enter a Password:");
            var password = Console.ReadLine();
            if (password == null)
            {
                Console.Clear();
                Console.WriteLine("Password cant be empty! Try again.");
                CreateUser(business);
            }
            Console.WriteLine("Enter the first name of the user:");
            var firstName = Console.ReadLine();
            if (firstName == null)
            {
                Console.Clear();
                Console.WriteLine("FirstName cant be empty! Try again.");
                CreateUser(business);
            }
            Console.WriteLine("Enter the last name of the user:");
            var lastName = Console.ReadLine();
            if (lastName == null)
            {
                Console.Clear();
                Console.WriteLine("LastName cant be empty! Try again.");
                CreateUser(business);
            }
            Console.WriteLine("Enter the role of the user:");
            var role = Console.ReadLine();
            if (role != "Admin" || role != "User")
            {   Console.Clear();
                Console.WriteLine("Wrong role! Try again.");
                CreateUser(business);
            }

        }

    }
}

// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Text;

namespace UserLogin{
    class Program
    {
        public static void printError(string errorMsg)
        {
            Console.WriteLine("Error: " + errorMsg + " !!!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Username:");
            string username=Console.ReadLine();
            Console.WriteLine("Password:");
            string password=Console.ReadLine();
            User user=null;
            LoginValidation lv = new LoginValidation(username,password,printError);
            if (lv.ValidateUserInput(ref user))
            {
              
                Console.WriteLine("username: "+user.Username);
                Console.WriteLine("password: " + user.Password);
                Console.WriteLine("fac.no.: " + user.Fac_no);
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS: 
                        Console.WriteLine("You are anonymous.");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("You are a student.");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("You are an admin.");
                        adminMenu();
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("You are a professor.");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("You are an inspector.");
                        break;
                }
 
                
            }
         
        }
        public static void adminMenu()
        {
            int option;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("0.Exit\n1.Change user role\n2.Change username validity date\n3.List of users\n4.View Log\n5.View current activity");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine("Input user to change:");
                            string username1 = Console.ReadLine();
                            Console.WriteLine("0-ANONYMOUS\n1-ADMIN\n2-INSPECTOR\n3-PROFESSOR\n4-STUDENT\n Insert role:");
                            int role = Convert.ToInt32(Console.ReadLine());
                            UserRoles role1 = (UserRoles)role;
                            UserData.AssignUserRole(username1, role1);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Input the user for validity change:");
                            string username1 = Console.ReadLine();
                            Console.WriteLine("Insert a date in the following format (mm.dd.yyyy hh:mm:ss):");
                            String time = Console.ReadLine();
                            DateTime dt = DateTime.Parse(time);
                            UserData.SetUserActiveTo(username1, dt);
                            break;
                        }
                    case 3:
                        {
                            UserData.displayUsers();
                            break;
                        }
                    case 4:
                        {
                            IEnumerable<string> log=Logger.getLog();
                            foreach (string s in log)
                                Console.WriteLine(s);
                            break;
                        }
                    case 5:
                        {
                            string filter="";
                            StringBuilder sb = new StringBuilder();
                            IEnumerable<string> currentActs =
                            Logger.GetCurrentSessionActivities(filter);
                            foreach (string line in currentActs)
                            {
                                sb.Append(line);
                            }
                            break;
                            ;
                        }
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                };
            } while (option!=0);
        }
    }
}


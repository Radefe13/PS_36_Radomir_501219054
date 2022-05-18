using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers = new();

        static public List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
       
        static private void ResetTestUserData()
        {
            if (!_testUsers.Any())
            {
                User testUser1 = new User();
                testUser1.Username = "ddimchev";
                testUser1.Password = "123456";
                testUser1.Fac_no = "501219028";
                testUser1.Role = 1;
                testUser1.Created = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                testUser1.ValidUntil = new DateTime();
                testUser1.ValidUntil = DateTime.MaxValue;
                _testUsers.Add(testUser1);


                User testUser2 = new User();
                testUser2.Username = "dgocov";
                testUser2.Password = "654321";
                testUser2.Fac_no = "501219029";
                testUser2.Role = 4;
                testUser2.Created = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                testUser2.ValidUntil = new DateTime();
                testUser2.ValidUntil = DateTime.MaxValue;
                _testUsers.Add(testUser2);

                User testUser3 = new User();
                testUser3.Username = "divanov";
                testUser3.Password = "123456avcs";
                testUser3.Fac_no = "501219030";
                testUser3.Role = 4;
                testUser3.Created = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                testUser3.ValidUntil = new DateTime();
                testUser3.ValidUntil = DateTime.MaxValue;
                _testUsers.Add(testUser3);
            }
        }
        
        static public User isUserPassCorrect(string username,string password)
        {
            ResetTestUserData();
            User userToBeLogged = ((User)(from user in _testUsers where 
                         user.Username == username 
                         && user.Password == password 
                         select user));
            if (userToBeLogged != null)
                return userToBeLogged;
            return null;
        }

        static public void SetUserActiveTo(string username, DateTime validity)
        {
            foreach(User user in _testUsers)
            {
                if (user.Username == username)
                {
                    user.ValidUntil = validity;
                    Logger.LogActivity("Changed validity of " + username);
                }
            }
        }

        static public void AssignUserRole(string username, UserRoles role)
        {
            foreach (User user in _testUsers)
            {
                if (user.Username == username)
                {
                    user.Role = (int)role;
                    Logger.LogActivity("Changed role of  " + username);
                }
            }
        }

        static public void displayUsers()
        {
            foreach(User u in _testUsers)
            {
                Console.WriteLine("\nusername: " + u.Username);
                Console.WriteLine("fac.no.: " + u.Fac_no);
                Console.Write("role: ");
                switch (u.Role)
                {
                    case 0:
                        Console.WriteLine("anonymous");
                        break;
                    case 1:
                        Console.WriteLine("admin");
                        break;
                    case 2:
                        Console.WriteLine("inspector");
                        break;
                    case 3:
                        Console.WriteLine("professor");
                        break;
                    case 4:
                        Console.WriteLine("student");
                        break;
                }
            }
        }
    }
}

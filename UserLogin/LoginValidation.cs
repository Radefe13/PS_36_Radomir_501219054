using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        static public string username;
        private string password;
        private string errorMsg;
        private ActionOnError aoe;

        public delegate void ActionOnError(string errorMsg);
        static public UserRoles currentUserRole { get; private set; }

        public LoginValidation(string username, string password,ActionOnError aoe)
        {
            LoginValidation.username = username;
            this.password = password;
            this.aoe = aoe;
        }

        public bool ValidateUserInput(ref User user)
        {
            bool emptyUserName;
            emptyUserName = username.Equals(string.Empty);
            if (emptyUserName == true)
            {
                aoe("No username input.");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            bool emptyPassword;
            emptyPassword = password.Equals(string.Empty);
            if (emptyPassword == true)
            {
                aoe("No password input.");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            if (username.Length < 5)
            {
                aoe("Username shorter than 5 symbols.");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (password.Length < 5)
            {
                aoe("Password shorter than 5 symbols.");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            user = new User();
            user = UserData.isUserPassCorrect(username, password);
            if (user != null)
            {
                currentUserRole =(UserRoles) user.Role;
                Logger.LogActivity("Successful Login");
                return true;
            }
            else
            {
                aoe("User not found / wrong password.");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
         }
    }
}

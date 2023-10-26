using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities
{
    internal class StaUsersManager
    {
        internal static event EventHandler<EventArgs> OnRD_Login;
        internal static event EventHandler<EventArgs> OnLogout;
        internal enum USER_GROUP
        {
            VISITOR,
            USER_ENG,
            GPM_ENG,
            GPM_RD
        }
        internal class User
        {
            public USER_GROUP Group { get; set; }
            public string Name { get; set; } = "";
            public string Password { get; set; }
        }


        internal static User CurrentUser { get; private set; } = new User()
        {
            Group = USER_GROUP.VISITOR,
        };

        internal static Dictionary<USER_GROUP, List<User>> Users = new Dictionary<USER_GROUP, List<User>>()
        {
            {
                USER_GROUP.USER_ENG, new List<User>() {
                    new User() {
                         Group = USER_GROUP.USER_ENG,
                          Name = "ENG",
                          Password = "12345678"
                    }
                } },
            {
                USER_GROUP.GPM_ENG, new List<User>() {
                    new User() {
                         Group = USER_GROUP.GPM_ENG,
                          Name = "ENG",
                          Password = "33838628"
                    }
                }
            },
            {
                USER_GROUP.GPM_RD, new List<User>() {
                    new User(){
                         Group = USER_GROUP.GPM_RD,
                         Name = "GPM",
                         Password ="33838628"
                    },
                    new User(){
                         Group = USER_GROUP.GPM_RD,
                         Name = "GPM",
                         Password ="12345678"
                    }
                }
            },
        };



        internal static bool TryLogin(string name, string pw, out User user)
        {

            if (Debugger.IsAttached)
            {
                user = CurrentUser = new User()
                {
                    Group = USER_GROUP.GPM_RD,
                    Name = "Developer"
                };
                OnRD_Login?.Invoke("", EventArgs.Empty);

                return true;
            }

            user = Users.Values.SelectMany(v => v).FirstOrDefault(user => user.Name.ToUpper() == name.ToUpper() && user.Password == pw);
            bool success = user != null;
            CurrentUser = success ? user : new User()
            {
                Group = USER_GROUP.VISITOR,
            };
            if (user.Group == USER_GROUP.GPM_RD)
            {
                OnRD_Login?.Invoke("", EventArgs.Empty);
            }
            return success;
        }

        internal static void Logout()
        {
            CurrentUser = new User()
            {
                Group = USER_GROUP.VISITOR
            };
        }
    }
}

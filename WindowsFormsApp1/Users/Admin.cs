using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Users
{
    public class Admin : Account
    {
        public List<Account> users { get; private set; } = new List<Account>();

        public Admin(string username, string password) : base(username) {
            base.AccountType = "Admin";
            base.Password = password;
            AccountType = "Admin";
        }

        public void getUsers() => users = DeserializeAccounts(PATH_TO_FILE);

        public void DeleteUser(int userId)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].id == userId)
                {
                    users.RemoveAt(i);
                    SerializeAccounts(users);
                    if (File.Exists(PATH_TO_USERSFAV + "\\" + userId + "\\manga")) File.Delete(PATH_TO_USERSFAV + "\\"+ userId + "\\manga");
                    if (File.Exists(PATH_TO_AVATARS + userId))File.Delete(PATH_TO_AVATARS + userId);
                    break;
                }
            }
        }

        public override bool isAdmin() => true;

    }
}

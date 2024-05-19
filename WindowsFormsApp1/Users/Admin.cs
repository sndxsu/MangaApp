using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Users
{
    public class Admin : Account
    {
        public List<Account> users { get; private set; }

        public Admin(string username, string password) : base(username) {
            base.AccountType = "Admin";
            base.Password = password;
        }

        public void loadAccounts() => users = DeserializeAccounts(PATH_TO_FILE);
    }
}

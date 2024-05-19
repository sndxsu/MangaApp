using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApp1.Users
{
    public abstract class Account
    {
        public int id { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string AccountType { get; protected set; }

        protected const string PATH_TO_FILE = "userdata";
        protected const string PATH_TO_AUTHDATA = "acc";

        public bool Auth()
        {
            if (this != null && AccountIsExist(this, true)) return true;
            else return false;
        }
        public bool AccountIsExist(Account acc, bool checkPassword)
        {
            List<Account> accounts = DeserializeAccounts(PATH_TO_FILE);
            Boolean res = false;
            foreach (Account c in accounts)
            {
                if (checkPassword)
                {
                    if (acc.Username == c.Username && acc.Password == c.Password)
                    {
                        res = true; break;
                    }
                }
                else if (acc.Username == c.Username)
                {
                    res = true; break;
                }
            }
            return res;
        }

        public static bool isAdmin(Account account)
        {

            List<Account> accounts = Account.DeserializeAccounts(PATH_TO_FILE);
            bool res = false;
            foreach (Account c in accounts){
                if (account.Username == c.Username && account.Password == c.Password && c.AccountType == "Admin")
                {
                    res = true;
                    break;
                }
            }
            return res;

        }

        public bool CheckHashEquals(string tmpNewHash, string tmpHash)
        {
            bool bEqual = false;
            if (tmpNewHash.Length == tmpHash.Length)
            {
                int i = 0;
                while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpHash[i]))
                {
                    i += 1;
                }
                if (i == tmpNewHash.Length)
                {
                    bEqual = true;
                }
            }
            return bEqual;
        }

        public string GetHash(string text)
        {
            string hash;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hash = builder.ToString();
            }
                return hash.ToString();
        }

        public Account(string username)
        {
            Username = username;
        }

        public void SetPassword(string pass)
        {
            Password = GetHash(pass);
        }

        public bool Registrate()
        {
            if (!File.Exists(PATH_TO_FILE))
            {
                FileStream fs = File.Create(PATH_TO_FILE);
                fs.Close();
            }

            if (AccountIsExist(this, false))
            {
                return false;
            }
            else
            {
                List<Account> accounts = DeserializeAccounts(PATH_TO_FILE);
                int id = 0;
                if (accounts.Count > 0) id = accounts.Last().id + 1;
                this.id = id;
                accounts.Add(this);
                string output = JsonConvert.SerializeObject(accounts, Formatting.Indented);
                File.WriteAllText(PATH_TO_FILE, output);
                return true;
            }
        }

        public void SaveLogin()
        {
            string authData = JsonConvert.SerializeObject(this);
            File.WriteAllText(PATH_TO_AUTHDATA, authData);
        }

        protected static List<Account> DeserializeAccounts(string path)
        {
            List<Account> result = new List<Account>();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var accounts = JsonConvert.DeserializeObject<List<JObject>>(json);

                if (accounts != null)
                {
                    foreach (var account in accounts)
                    {
                        string accountType = account.GetValue("AccountType").ToString();

                        switch (accountType)
                        {
                            case "User":
                                result.Add(account.ToObject<User>());
                                break;
                            case "Admin":
                                result.Add(account.ToObject<Admin>());
                                break;
                        }
                    }
                }
            }
            return result;
        }
    }
}



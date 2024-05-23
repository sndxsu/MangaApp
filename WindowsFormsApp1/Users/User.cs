using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WindowsFormsApp1.Manga;

namespace WindowsFormsApp1.Users
{
    public class User:Account
    {

        private List<Title> FavoriteTitles;
        public string avatarPath;
        public User(string username) : base (username){
            base.AccountType = "User";
            avatarPath = "default";
        }
        [JsonConstructor]
        public User(int id, string username, string password, string avatarPath) : base(username)
        {
            base.id = id;
            Password = password;
            base.AccountType = "User";
            FavoriteTitles = new List<Title>();
            this.avatarPath = avatarPath;
        }


        public void setAvatar(string path)
        {
            string destinationPath = PATH_TO_AVATARS + id;

            if (!Directory.Exists(PATH_TO_AVATARS))
                Directory.CreateDirectory(PATH_TO_AVATARS);
            try
            {
                using (FileStream sourceStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        sourceStream.CopyTo(destStream);
                    }
                }
                List<Account> accounts = DeserializeAccounts(PATH_TO_FILE);

                for (int i = 0; i<accounts.Count; i++)
                {
                    if (accounts[i].id == this.id && accounts[i] is User)
                    {
                        (accounts[i] as User).avatarPath = destinationPath;
                        this.avatarPath = destinationPath;
                    }
                }
                SerializeAccounts(accounts);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to set avatar", ex);
            }
            }


        public bool avatarIsExit => !avatarPath.Equals("default");

        public override bool isAdmin() => false;

        public List<Title> FavTitles => FavoriteTitles;

        public static User LoggedBefore()
        {
            if (File.Exists(PATH_TO_AUTHDATA))
            {
                string json = File.ReadAllText(PATH_TO_AUTHDATA);

                var Juser = JsonConvert.DeserializeObject<JObject>(json);
                User user = Juser.ToObject<User>();
                return user;
            }
            else return null;
        }

        public static string getUsername(int id)
        {
            List<Account> accounts = DeserializeAccounts(PATH_TO_FILE);
            foreach (Account account in accounts)
            {
                if (id == account.id)
                    return account.Username;
            }
            return null;
        }

        public void LoadFavTitles() => FavoriteTitles = Title.DeserializeArrayFromFile(PATH_TO_USERSFAV + "\\" + id);

        public void AddFavoriteTitle(Title manga) => FavoriteTitles.Add(manga);

        public void SaveTitles() => Title.SerializeArrayToFile(FavoriteTitles, PATH_TO_USERSFAV  + "\\" + id);

        public void delSavedAcc() => File.Delete(PATH_TO_AUTHDATA);

        public bool AlreadyFavorite(Title manga)
        {
            bool res = false;
            foreach (Title t in FavoriteTitles)
            {
                res = t.id.Equals(manga.id);
                break;
            }
            return res;
        }

        public void DelFavoriteTitle(Title manga)
        {
            for (int i = 0; i<FavoriteTitles.Count; i++)
            {
                if (manga.id == FavoriteTitles[i].id)
                {
                    FavoriteTitles.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
 
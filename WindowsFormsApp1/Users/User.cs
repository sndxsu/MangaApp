using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WindowsFormsApp1.Manga;

namespace WindowsFormsApp1.Users
{
    public class User:Account
    {
        private const string PATH_TO_USERSFAV = "data\\users_info";
        private List<Title> FavoriteTitles;
        public User(string username) : base (username){
            base.AccountType = "User";
        }
        [JsonConstructor]
        public User(int id, string username, string password) : base(username)
        {
            base.id = id;
            Password = password;
            base.AccountType = "User";
            FavoriteTitles = new List<Title>();
        }

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


        public void LoadFavTitles() => FavoriteTitles = Title.DeserializeArrayFromFile(PATH_TO_USERSFAV + id);

        public void AddFavoriteTitle(Title manga) => FavoriteTitles.Add(manga);

        public void SaveTitles() => Title.SerializeArrayToFile(FavoriteTitles, PATH_TO_USERSFAV + id);

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
 
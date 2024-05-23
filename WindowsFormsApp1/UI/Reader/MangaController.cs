using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.Manga;
using WindowsFormsApp1.Users;

namespace WindowsFormsApp1.UI.Reader
{
    public class MangaController
    {
        private List<Title> titles = Title.DeserializeAllTitles();
        Account account;
        UserForm userForm;
        public int getCountTitles() => titles.Count;

        public MangaController(Account acc, UserForm f)
        {
            account = acc;
            userForm = f;
        }

        public MangaController(){}

        public bool infoStarted { get; set; }

        public void InitializeMangaCards(FlowLayoutPanel f)
        {
            baseInitialie(f, titles);
        }

        private void baseInitialie(FlowLayoutPanel f, List<Title> titles)
        {
            infoStarted = false;
            f.Controls.Clear();
            List<MangaCard> m = new List<MangaCard>();
            foreach (Title t in titles)
            {
                MangaCard c = new MangaCard(t);
                c.GetMaterialCard().MouseClick += (sender, e) => MangaCard_Click(sender, e, t);
                m.Add(c);
            }
            f.Controls.AddRange(m.ToArray());
        }


        public void ReturnSearch(FlowLayoutPanel f, string searchText) => baseInitialie(f, SearchManga(searchText));

        public void LoadFavorites(FlowLayoutPanel f)
        {
            User u;
            if (account is User) u = (User)account;
            else return;

            baseInitialie(f, u.FavTitles);
        }

        private void MangaCard_Click(object sender, EventArgs e, Title title)
        {
            if (!infoStarted)
            {
                int userId = -1;
                if (account is User) userId = (account as User).id;

                MangaInfo m = new MangaInfo(title, userId, this);
                m.Show();
                infoStarted = true;
            }
        }

        public void AddFavoriteManga(Title mng)
        {
            if (account is User)
            {
                (account as User).AddFavoriteTitle(mng);
                (account as User).SaveTitles();
                userForm.UpdateFavList();
                userForm.UpdateFavCount();
            }
        }



        public List<Title> SearchManga(string name)
        {
            List<Title> res = new List<Title>();
            foreach(Title n in titles)
            {
                if (n.Name.ToLower().Contains(name.ToLower()))
                {
                    res.Add(n);
                }
            }
            return res;
        }

        public bool isAlreadyFavorite(Title m)
        {
            User s;
            if (account is User) {
                s = (account as User);
                if (s.AlreadyFavorite(m)) return true;
            }
            return false;

        }

        public void delFavorite(Title m)
        {
            if (account is User)
            {
                (account as User).DelFavoriteTitle(m);
                (account as User).SaveTitles();
                userForm.UpdateFavList();
                userForm.UpdateFavCount();
            }
        }

        public void AddManga(Title title)
        {
            titles.Add(title);
            Title.SerializeAllTitles(titles);
        }

    }
}

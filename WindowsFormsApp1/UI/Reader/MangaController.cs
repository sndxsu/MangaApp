using MaterialSkin.Controls;
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
            infoStarted = false;
            baseInitialie(f, titles);
        }

        private void baseInitialie(FlowLayoutPanel f, List<Title> titles)
        {
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
                bool isUser = false;
                if (account is User) isUser = true;
                MangaInfo m = new MangaInfo(title, isUser, this);
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
            }
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
            }
        }

        public void AddManga(Title title)
        {
            titles.Add(title);
            Title.SerializeAllTitles(titles);
        }

    }
}

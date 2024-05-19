using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Manga;

namespace WindowsFormsApp1.UI.Reader
{
    public partial class MangaInfo : MaterialForm
    {
        Title manga;
        bool isUser = false;
        MangaController mangaController;
        ThemeControl theme;

        public MangaInfo(Title manga, bool isUser, MangaController m)
        {
            this.manga = manga;
            InitializeComponent();
            InitializeManga();
            this.isUser = isUser;
            mangaController = m;
            theme = new ThemeControl(this);
            theme.Initialize();
            this.Text = manga.Name;
            if (isUser) InitializeUserControls();
            label1.MaximumSize = new Size(590, 0);
        }

        public void InitializeUserControls() { 
            materialButton1.Visible = true;
        }

        private void InitializeManga()
        {
            materialLabel1.Text = manga.Name;
            label1.Text = manga.Description;
            pictureBox1.Image = Image.FromFile(manga.PathToImg);

            for (int i = 0; i < manga.Chapters.Count; i++) {
                ChapterItem chapterItem = new ChapterItem(manga.Chapters[i]);
                chapterItem.SetText("Розділ " + (i+1));
                chapterItem.Dock = DockStyle.Top;
                flowLayoutPanel1.Controls.Add(chapterItem);

            }
        }
        private void MangaInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            mangaController.infoStarted = false;
        }


        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (!mangaController.isAlreadyFavorite(manga))
            {
                mangaController.AddFavoriteManga(manga);
                MaterialMessageBox.Show("Успішно добавлено!");
            }
            else
            {
                mangaController.delFavorite(manga);
                MaterialMessageBox.Show("Успішно видалено!");
            }
        }
    }
}

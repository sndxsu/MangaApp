using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Manga;

namespace WindowsFormsApp1.UI.Reader
{
    public partial class MangaInfo : MaterialForm
    {
        Title manga;
        int userId;
        MangaController mangaController;
        ThemeControl theme;
        RatingControl ratingControl;

        const string textLabel2 = "Середня оцінка: ";

        public MangaInfo(Title manga, int userID, MangaController m)
        {
            this.manga = manga;
            ratingControl = new RatingControl(manga.id);
            userId = userID;
            ratingControl.DeserializeGrades();
            InitializeComponent();
            InitializeManga();
            mangaController = m;
            theme = new ThemeControl(this);
            theme.Initialize();
            this.Text = manga.Name;
            if (userId != -1) InitializeUserControls();
            label1.MaximumSize = new Size(590, 0);
            materialLabel2.Text = textLabel2 + ratingControl.getAverage().ToString("0.##");
            starRatingControl1.RatingChanged += StarRatingControl_RatingChanged;
        }

        public void InitializeUserControls() { 
            materialButton1.Visible = true;
            starRatingControl1.Visible = true;
        }

        private void InitializeManga()
        {
            materialLabel1.Text = manga.Name;
            label1.Text = manga.Description;
            pictureBox1.Image = Image.FromFile(manga.PathToImg);

            if (userId != -1)
            {
                starRatingControl1.Rating = ratingControl.getGrade(userId);
            }

            for (int i = 0; i < manga.Chapters.Count; i++) {
                ChapterItem chapterItem = new ChapterItem(manga.Chapters[i]);
                chapterItem.SetText("Розділ " + (i+1));
                chapterItem.Dock = DockStyle.Top;
                flowLayoutPanel1.Controls.Add(chapterItem);
            }
        }
        private void MangaInfo_FormClosing(object sender, FormClosingEventArgs e) => mangaController.infoStarted = false;


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

        private void StarRatingControl_RatingChanged(object sender, EventArgs e)
        {
            ratingControl.addGrade(userId, starRatingControl1.Rating);
            ratingControl.SerializeGrades();
            materialLabel2.Text = textLabel2 + ratingControl.getAverage().ToString("0.##");
        }

    }
}

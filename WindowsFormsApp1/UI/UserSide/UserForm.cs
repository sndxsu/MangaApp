using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.UI;
using WindowsFormsApp1.UI.Reader;
using WindowsFormsApp1.Users;

namespace WindowsFormsApp1
{
    public partial class UserForm : MaterialForm
    {
        User user;
        MangaController mangaController;
        bool accountExit = false;
        public UserForm(User user)
        {
            this.user = user;
            Text = user.Username;
            ThemeControl theme = new ThemeControl(this);
            InitializeComponent();
            user.LoadFavTitles();
            theme.Initialize();
            mangaController = new MangaController(user, this);
            mangaController.InitializeMangaCards(flowLayoutPanel1);
            mangaController.LoadFavorites(flowLayoutPanel2);
        }

        private void UserForm_FormClosed(object sender, FormClosingEventArgs e)
        {
            if (!accountExit) Application.Exit();
            else
            {
                e.Cancel = true;
                accountExit = false;
                this.Hide();
            }
        }

        private void materialButton1_Click(object sender, System.EventArgs e)
        {
            user.delSavedAcc();
            AuthPage n = new AuthPage();
            n.Show();
            accountExit = true;
            this.Close();
        }

        public void UpdateFavList() => mangaController.LoadFavorites(flowLayoutPanel2);

    }
}

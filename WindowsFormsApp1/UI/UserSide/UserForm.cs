using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            UpdateFavCount();
            materialLabel1.Text = user.Username;
            if (user.avatarIsExit && File.Exists(user.avatarPath)) roundedPictureBox1.Image = new Bitmap(user.avatarPath);
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

        public void UpdateFavCount() => materialLabel2.Text = "Кількість улюблених: " + user.FavTitles.Count;

        private void materialButton1_Click(object sender, System.EventArgs e)
        {
            user.delSavedAcc();
            AuthPage n = new AuthPage();
            n.Show();
            accountExit = true;
            this.Close();
        }

        public void UpdateFavList() => mangaController.LoadFavorites(flowLayoutPanel2);

        private void materialTextBox21_TextChanged(object sender, System.EventArgs e) => mangaController.ReturnSearch(flowLayoutPanel2, materialTextBox21.Text);

        private void materialTextBox22_TextChanged(object sender, System.EventArgs e) => mangaController.ReturnSearch(flowLayoutPanel1, materialTextBox22.Text);

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "*.jpg, *.png, *.gif|*.jpg;*.png;*.gif";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                roundedPictureBox1.Image.Dispose();
                roundedPictureBox1.Image = Properties.Resources.images;
                user.setAvatar(fileDialog.FileName);
                if (user.avatarIsExit) roundedPictureBox1.Image = new Bitmap(user.avatarPath);
                else MaterialMessageBox.Show("Щось пішло не так!");
            }
        }
    }
}

using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Manga;
using WindowsFormsApp1.UI.Reader;
using WindowsFormsApp1.Users;

namespace WindowsFormsApp1.UI.AdminSide
{
    public partial class AdminForm : MaterialForm
    {
        MangaController cntrll;
        ThemeControl themeControl;
        Admin admin;
        public AdminForm()
        {
            admin = new Admin("test", "test");
            InitializeComponent();
            cntrll = new MangaController();
            cntrll.InitializeMangaCards(flowLayoutPanel1);
            themeControl = new ThemeControl(this);
            themeControl.Initialize();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("username", "Username");
            dataGridView1.Columns.Add("accountType", "Admin");
            admin.getUsers();
            dataGridView1.DefaultCellStyle.BackColor = Color.Black;
            UpdateDataGrid();
        }
        public int getCountTitles() => cntrll.getCountTitles();
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateDataGrid()
        {
            dataGridView1.Rows.Clear();
            if (admin.users != null)
            {
                foreach (Account s in admin.users)
                {
                    dataGridView1.Rows.Add(s.id, s.Username, s.isAdmin()); 
                }
            }
        }

        public void UpdateList() => cntrll.InitializeMangaCards(flowLayoutPanel1);

        public void AddManga(Title title) => cntrll.AddManga(title);

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            AddManga m = new AddManga(this);
            m.Show();
        }

        private void materialTextBox22_TextChanged(object sender, System.EventArgs e) => cntrll.ReturnSearch(flowLayoutPanel1, materialTextBox22.Text);

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            materialButton1.Visible = true;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            bool isAdmin = Boolean.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            if (isAdmin) MaterialMessageBox.Show("Ви не можете видалити адміна!");
            else admin.DeleteUser(Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            UpdateDataGrid();
        }
    }
}

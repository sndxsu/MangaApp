using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            admin.loadAccounts();
            dataGridView1.Columns.Add("id", "ID");
            dataGridView1.Columns.Add("username", "Username");
            dataGridView1.Columns.Add("accountType", "Account Type");
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Black;
            UpdateDataGrid();
        }
        public int getCountTitles() => cntrll.getCountTitles();
        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateDataGrid()
        {
            if (admin.users != null)
            {
                foreach (Account s in admin.users)
                {
                    dataGridView1.Rows.Add(s.id, s.Username, s.AccountType); 
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
    }
}

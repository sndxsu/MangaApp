using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Manga;

namespace WindowsFormsApp1.UI.AdminSide
{
    public partial class AddManga : MaterialForm
    {
        AdminForm adminForm;
        string[] pathes;
        ThemeControl themeControl;
        public AddManga(AdminForm f)
        {
            adminForm = f;
            InitializeComponent();
            themeControl = new ThemeControl(this);
            themeControl.Initialize();
        }


        private void materialButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "cbz (*.cbz)|*.cbz",
                Title = "title.cbz"
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pathes = openFileDialog2.FileNames;
                if (pathes.Length != 0)
                {
                    MaterialMessageBox.Show("Файли додано!");
                    materialButton1.Enabled = false;
                }
            }
        }

        

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (textBoxesIsEmpty())
            {
                MaterialMessageBox.Show("Одне або декілька із полей пусті!");
                return;
            }

            if (pictureBox1.Image == null)
            {
                MaterialMessageBox.Show("Не додана прев'ю!");
                return;
            }

            if (pathes == null || pathes.Length == 0)
            {
                MaterialMessageBox.Show("Не додані файли!");
                return;
            }


            string name = materialTextBox21.Text;
            string description = materialMultiLineTextBox21.Text;
            List<string> path = new List<string>();
            string MangaPath = "data\\manga_catalog\\";
            if (!Directory.Exists(MangaPath + name)) Directory.CreateDirectory(MangaPath + name);
            if (!File.Exists(MangaPath + "manga")) File.Create(MangaPath + "manga");
            for (int i = 0; i<pathes.Length; i++)
            {
                string res = MangaPath + name + "\\" + i + ".cbz";
                if (File.Exists(res)) File.Delete(res);
                File.Copy(pathes[i], res);
                path.Add(res);
            }

            Title title = new Title(pictureBox1.Image, name, description, path, adminForm.getCountTitles());
            adminForm.AddManga(title);
            if (MaterialMessageBox.Show("Успішно додано!") == DialogResult.OK)
            {
                adminForm.UpdateList();
                Close();
            }
        }

        private bool textBoxesIsEmpty()
        {
            if (materialTextBox21.Text == "" || materialMultiLineTextBox21.Text == "") return true;
            else return false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "png (*.png)|*.png|jpg (*.jpg)|*.jpg";
            openFileDialog1.FileName = "image.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                Image image = Image.FromFile(filePath);
                pictureBox1.Image = image;
                
                label1.Visible = false;
            }
        }
    }
}

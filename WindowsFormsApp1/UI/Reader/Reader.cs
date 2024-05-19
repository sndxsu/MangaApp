using MaterialSkin.Controls;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApp1.UI.Reader.Reader
{
    public partial class Reader : MaterialForm
    {
        string path;
        ThemeControl theme;
        private List<Image> images;
        private int currentIndex = 0;
        public Reader(string path)
        {
            this.path = path;
            theme = new ThemeControl(this);
            theme.Initialize();
            InitializeComponent();
            InitializeFullScreenMode();
            images = ExtractImagesFromCBZ(path);
            DisplayCurrentImage();
        }

        private void InitializeFullScreenMode()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                addPage();
            else if (e.KeyCode == Keys.Left)
                backPage();
        }

        private void addPage()
        {
            if (images == null || images.Count == 0 || currentIndex == images.Count - 1) return;
            currentIndex = (currentIndex + 1) % images.Count;
            DisplayCurrentImage();
        }
        private void backPage()
        {
            if (images == null || images.Count == 0 || currentIndex == 0) return;
            currentIndex = (currentIndex - 1 + images.Count) % images.Count;
            DisplayCurrentImage();
        }

        private void DisplayCurrentImage()
        {
            if (images != null && images.Count > 0 && currentIndex >= 0 && currentIndex < images.Count)
            {
                pictureBox1.Image = images[currentIndex];
            }
            currentPageText.Text = $"{currentIndex + 1}/{images.Count}";
        }


        private List<Image> ExtractImagesFromCBZ(string cbzFilePath)
        {
            List<Image> images = new List<Image>();

            using (ZipArchive archive = ZipFile.OpenRead(cbzFilePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (IsImageFile(entry.Name))
                    {
                        using (Stream stream = entry.Open())
                        {
                            images.Add(Image.FromStream(stream));
                        }
                    }
                }
            }

            return images;
        }

        private bool IsImageFile(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp" || ext == ".gif";
        }

        private void pictureBox3_Click(object sender, System.EventArgs e)
        {
            addPage();
        }

        private void pictureBox2_Click(object sender, System.EventArgs e)
        {
            backPage();
        }
    }
}

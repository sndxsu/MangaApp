using MaterialSkin;
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
using WindowsFormsApp1.UI.Reader;

namespace WindowsFormsApp1.UI
{
    public partial class MangaCard : UserControl
    {
        public MangaCard(Title manga)
        {
            InitializeComponent();
            Title.Text = manga.Name;
            pictureBox1.Image = Image.FromFile(manga.PathToImg);
        }

        public MaterialCard GetMaterialCard()
        {
            return materialCard1;
        }

    }
}

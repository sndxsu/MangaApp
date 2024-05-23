using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.UI.Reader;

namespace WindowsFormsApp1.UI.Reader
{
    public partial class ChapterItem : UserControl
    {
        public string Chapter { get; private set; }

        public ChapterItem(string chapter)
        {
            InitializeComponent();
            Chapter = chapter;
        }

        public void SetText(string text)
        {
            materialLabel1.Text = text;
        }


        private void materialCard1_Click(object sender, EventArgs e)
        {
            Reader.Reader r = new Reader.Reader(Chapter);
            r.Show();
        }

        public void Reader()
        {
            BackColor = Color.Black;
        }
    }
}

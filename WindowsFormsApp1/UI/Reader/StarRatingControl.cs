using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UI.Reader
{
    public partial class StarRatingControl : UserControl
    {
        private List<PictureBox> stars;
        private int rating;
        FlowLayoutPanel flowLayoutPanel1;
        public event EventHandler RatingChanged;

        public StarRatingControl()
        {
            stars = new List<PictureBox>();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Controls.Add(flowLayoutPanel1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            for (int i = 0; i < 5; i++)
            {
                PictureBox pictureBox = new PictureBox()
                {
                    Height = 30,
                    Width = 30,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                pictureBox.Click += Star_Click;
                stars.Add(pictureBox);
            }
            flowLayoutPanel1.Controls.AddRange(stars.ToArray());
            InitializeComponent();
        }

        private void Star_Click(object sender, EventArgs e)
        {
            var clickedStar = sender as PictureBox;
            rating = stars.IndexOf(clickedStar) + 1;

            UpdateStars();
            RatingChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateStars()
        {
            for (int i = 0; i < stars.Count; i++)
            {
                stars[i].Image = i < rating ? Properties.Resources.FilledStar : Properties.Resources.StarEmpty;
            }
        }

        public int Rating
        {
            get => rating;
            set
            {
                rating = value;
                UpdateStars();
            }
        }
    }
}

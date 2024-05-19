namespace WindowsFormsApp1
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabFavorites = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabExplore = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabAcc = new System.Windows.Forms.TabPage();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.materialTabControl1.SuspendLayout();
            this.tabFavorites.SuspendLayout();
            this.tabExplore.SuspendLayout();
            this.tabAcc.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabFavorites);
            this.materialTabControl1.Controls.Add(this.tabExplore);
            this.materialTabControl1.Controls.Add(this.tabAcc);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(903, 459);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabFavorites
            // 
            this.tabFavorites.Controls.Add(this.flowLayoutPanel2);
            this.tabFavorites.ImageKey = "favorite.png";
            this.tabFavorites.Location = new System.Drawing.Point(4, 43);
            this.tabFavorites.Name = "tabFavorites";
            this.tabFavorites.Padding = new System.Windows.Forms.Padding(3);
            this.tabFavorites.Size = new System.Drawing.Size(895, 412);
            this.tabFavorites.TabIndex = 0;
            this.tabFavorites.Text = "Улюблені";
            this.tabFavorites.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(889, 406);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(889, 406);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // tabExplore
            // 
            this.tabExplore.Controls.Add(this.flowLayoutPanel1);
            this.tabExplore.ImageKey = "browse.png";
            this.tabExplore.Location = new System.Drawing.Point(4, 43);
            this.tabExplore.Name = "tabExplore";
            this.tabExplore.Size = new System.Drawing.Size(895, 412);
            this.tabExplore.TabIndex = 4;
            this.tabExplore.Text = "Каталог";
            this.tabExplore.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(895, 412);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // tabAcc
            // 
            this.tabAcc.Controls.Add(this.materialButton1);
            this.tabAcc.ImageKey = "account.png";
            this.tabAcc.Location = new System.Drawing.Point(4, 43);
            this.tabAcc.Name = "tabAcc";
            this.tabAcc.Size = new System.Drawing.Size(895, 412);
            this.tabAcc.TabIndex = 2;
            this.tabAcc.Text = "Акаунт";
            this.tabAcc.UseVisualStyleBackColor = true;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(0, 0);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(895, 36);
            this.materialButton1.TabIndex = 0;
            this.materialButton1.Text = "Вийти із аккаунту";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "account.png");
            this.imageList1.Images.SetKeyName(1, "browse.png");
            this.imageList1.Images.SetKeyName(2, "favorite.png");
            this.imageList1.Images.SetKeyName(3, "history.png");
            this.imageList1.Images.SetKeyName(4, "settings.png");
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 526);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerIsOpen = true;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosed);
            this.materialTabControl1.ResumeLayout(false);
            this.tabFavorites.ResumeLayout(false);
            this.tabExplore.ResumeLayout(false);
            this.tabExplore.PerformLayout();
            this.tabAcc.ResumeLayout(false);
            this.tabAcc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabAcc;
        private System.Windows.Forms.TabPage tabExplore;
        private System.Windows.Forms.TabPage tabFavorites;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}


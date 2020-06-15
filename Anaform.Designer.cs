namespace Ekonometri
{
    partial class Ekonometri
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chowTestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lMTestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mvdTestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basitDogrusalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chowTestiToolStripMenuItem,
            this.lMTestiToolStripMenuItem,
            this.mvdTestiToolStripMenuItem,
            this.basitDogrusalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1424, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chowTestiToolStripMenuItem
            // 
            this.chowTestiToolStripMenuItem.Name = "chowTestiToolStripMenuItem";
            this.chowTestiToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.chowTestiToolStripMenuItem.Text = "Chow Testi";
            this.chowTestiToolStripMenuItem.Click += new System.EventHandler(this.chowTestiToolStripMenuItem_Click);
            // 
            // lMTestiToolStripMenuItem
            // 
            this.lMTestiToolStripMenuItem.Name = "lMTestiToolStripMenuItem";
            this.lMTestiToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.lMTestiToolStripMenuItem.Text = "LM Testi";
            this.lMTestiToolStripMenuItem.Click += new System.EventHandler(this.lMTestiToolStripMenuItem_Click);
            // 
            // mvdTestiToolStripMenuItem
            // 
            this.mvdTestiToolStripMenuItem.Name = "mvdTestiToolStripMenuItem";
            this.mvdTestiToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.mvdTestiToolStripMenuItem.Text = "MVD Testi";
            this.mvdTestiToolStripMenuItem.Click += new System.EventHandler(this.mvdTestiToolStripMenuItem_Click);
            // 
            // basitDogrusalToolStripMenuItem
            // 
            this.basitDogrusalToolStripMenuItem.Name = "basitDogrusalToolStripMenuItem";
            this.basitDogrusalToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.basitDogrusalToolStripMenuItem.Text = "Basit Doğrusal";
            this.basitDogrusalToolStripMenuItem.Click += new System.EventHandler(this.basitDogrusalToolStripMenuItem_Click);
            // 
            // Ekonometri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 861);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Ekonometri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekonometri";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chowTestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lMTestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mvdTestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basitDogrusalToolStripMenuItem;
    }
}


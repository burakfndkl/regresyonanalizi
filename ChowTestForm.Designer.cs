namespace Ekonometri
{
    partial class ChowTestForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dgwVeri = new System.Windows.Forms.DataGridView();
            this.btnHesapla = new System.Windows.Forms.Button();
            this.lblBeta1donem = new System.Windows.Forms.Label();
            this.lblBeta = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblBeta1 = new System.Windows.Forms.Label();
            this.lblBeta2donem = new System.Windows.Forms.Label();
            this.lblBetaTdonem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVeri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwVeri
            // 
            this.dgwVeri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVeri.Location = new System.Drawing.Point(22, 12);
            this.dgwVeri.Name = "dgwVeri";
            this.dgwVeri.Size = new System.Drawing.Size(1221, 253);
            this.dgwVeri.TabIndex = 0;
            // 
            // btnHesapla
            // 
            this.btnHesapla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHesapla.Location = new System.Drawing.Point(140, 503);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(75, 23);
            this.btnHesapla.TabIndex = 26;
            this.btnHesapla.Text = "Hesapla";
            this.btnHesapla.UseVisualStyleBackColor = true;
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            // 
            // lblBeta1donem
            // 
            this.lblBeta1donem.AutoSize = true;
            this.lblBeta1donem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeta1donem.Location = new System.Drawing.Point(27, 379);
            this.lblBeta1donem.Name = "lblBeta1donem";
            this.lblBeta1donem.Size = new System.Drawing.Size(174, 20);
            this.lblBeta1donem.TabIndex = 33;
            this.lblBeta1donem.Text = "1.Donem için betalar";
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeta.Location = new System.Drawing.Point(27, 308);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(35, 20);
            this.lblBeta.TabIndex = 31;
            this.lblBeta.Text = "HO";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(256, 271);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Point";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Doğru";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(934, 488);
            this.chart1.TabIndex = 35;
            this.chart1.Text = "chart1";
            title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            title1.Name = "Title1";
            title1.Text = "Saçılım Grafiği";
            title2.Name = "Title2";
            title2.Position.Auto = false;
            title2.Position.Height = 10F;
            title2.Position.Width = 15F;
            title2.Text = "X";
            title3.Alignment = System.Drawing.ContentAlignment.BottomRight;
            title3.Name = "Title3";
            title3.Position.Auto = false;
            title3.Position.Height = 90F;
            title3.Position.Width = 90F;
            title3.Position.Y = 2F;
            title3.Text = "Y";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            this.chart1.Titles.Add(title3);
            // 
            // lblBeta1
            // 
            this.lblBeta1.AutoSize = true;
            this.lblBeta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeta1.Location = new System.Drawing.Point(27, 341);
            this.lblBeta1.Name = "lblBeta1";
            this.lblBeta1.Size = new System.Drawing.Size(32, 20);
            this.lblBeta1.TabIndex = 32;
            this.lblBeta1.Text = "H1";
            // 
            // lblBeta2donem
            // 
            this.lblBeta2donem.AutoSize = true;
            this.lblBeta2donem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeta2donem.Location = new System.Drawing.Point(27, 409);
            this.lblBeta2donem.Name = "lblBeta2donem";
            this.lblBeta2donem.Size = new System.Drawing.Size(176, 20);
            this.lblBeta2donem.TabIndex = 36;
            this.lblBeta2donem.Text = "2.Donem için Betalar";
            // 
            // lblBetaTdonem
            // 
            this.lblBetaTdonem.AutoSize = true;
            this.lblBetaTdonem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBetaTdonem.Location = new System.Drawing.Point(27, 446);
            this.lblBetaTdonem.Name = "lblBetaTdonem";
            this.lblBetaTdonem.Size = new System.Drawing.Size(224, 20);
            this.lblBetaTdonem.TabIndex = 37;
            this.lblBetaTdonem.Text = "Toplam Donem için Betalar";
            // 
            // ChowTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 800);
            this.Controls.Add(this.lblBetaTdonem);
            this.Controls.Add(this.lblBeta2donem);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblBeta1donem);
            this.Controls.Add(this.lblBeta1);
            this.Controls.Add(this.lblBeta);
            this.Controls.Add(this.btnHesapla);
            this.Controls.Add(this.dgwVeri);
            this.Name = "ChowTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChowTesti";
            ((System.ComponentModel.ISupportInitialize)(this.dgwVeri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwVeri;
        private System.Windows.Forms.Button btnHesapla;
        private System.Windows.Forms.Label lblBeta1donem;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblBeta1;
        private System.Windows.Forms.Label lblBeta2donem;
        private System.Windows.Forms.Label lblBetaTdonem;
    }
}
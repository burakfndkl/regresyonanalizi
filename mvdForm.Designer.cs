namespace Ekonometri
{
    partial class mvdForm
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblBeta = new System.Windows.Forms.Label();
            this.btnHesapla = new System.Windows.Forms.Button();
            this.lblBeta1 = new System.Windows.Forms.Label();
            this.lblBetaTest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVeri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwVeri
            // 
            this.dgwVeri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVeri.Location = new System.Drawing.Point(2, 21);
            this.dgwVeri.Name = "dgwVeri";
            this.dgwVeri.Size = new System.Drawing.Size(367, 419);
            this.dgwVeri.TabIndex = 24;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(375, -4);
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
            this.chart1.Size = new System.Drawing.Size(998, 746);
            this.chart1.TabIndex = 27;
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
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeta.Location = new System.Drawing.Point(12, 456);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(128, 20);
            this.lblBeta.TabIndex = 26;
            this.lblBeta.Text = "HO için betalar";
            // 
            // btnHesapla
            // 
            this.btnHesapla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHesapla.Location = new System.Drawing.Point(294, 522);
            this.btnHesapla.Name = "btnHesapla";
            this.btnHesapla.Size = new System.Drawing.Size(75, 23);
            this.btnHesapla.TabIndex = 25;
            this.btnHesapla.Text = "Hesapla";
            this.btnHesapla.UseVisualStyleBackColor = true;
            this.btnHesapla.Click += new System.EventHandler(this.btnHesapla_Click);
            // 
            // lblBeta1
            // 
            this.lblBeta1.AutoSize = true;
            this.lblBeta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBeta1.Location = new System.Drawing.Point(12, 489);
            this.lblBeta1.Name = "lblBeta1";
            this.lblBeta1.Size = new System.Drawing.Size(125, 20);
            this.lblBeta1.TabIndex = 29;
            this.lblBeta1.Text = "H1 için betalar";
            // 
            // lblBetaTest
            // 
            this.lblBetaTest.AutoSize = true;
            this.lblBetaTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBetaTest.Location = new System.Drawing.Point(12, 522);
            this.lblBetaTest.Name = "lblBetaTest";
            this.lblBetaTest.Size = new System.Drawing.Size(137, 20);
            this.lblBetaTest.TabIndex = 30;
            this.lblBetaTest.Text = "Test için betalar";
            // 
            // mvdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 738);
            this.Controls.Add(this.lblBetaTest);
            this.Controls.Add(this.lblBeta1);
            this.Controls.Add(this.dgwVeri);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblBeta);
            this.Controls.Add(this.btnHesapla);
            this.Name = "mvdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mvdForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgwVeri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgwVeri;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Button btnHesapla;
        private System.Windows.Forms.Label lblBeta1;
        private System.Windows.Forms.Label lblBetaTest;
    }
}
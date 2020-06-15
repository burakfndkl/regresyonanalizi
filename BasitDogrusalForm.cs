using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using MathNet.Numerics.LinearAlgebra;

namespace Ekonometri
{
    public partial class BasitDogrusalForm : Form
    {
        public BasitDogrusalForm()
        {
            InitializeComponent();
            veriOku veri = new veriOku();
            dgwVeri.DataSource = veri.Veriler(this.Text).DataSource;
        }

       
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            var M = Matrix<double>.Build;

            double dtoplamY = 0;//double şeklinde toplam y için
            double dXY = 0; // double XYler için
            double dtoplamX = 0; //double toplam x için
            double xKare = 0; // double x kareler 
            double toplamYsapkaEksiYortalama = 0;
            double toplamYiEksiYortalama = 0;

            
            for (int i = 0; i < dgwVeri.RowCount - 1; i++)
            {
                double sY = Convert.ToDouble(dgwVeri.Rows[i].Cells[0].Value.ToString());
                dtoplamY += sY;

                double sX =Convert.ToDouble(dgwVeri.Rows[i].Cells[1].Value.ToString());
                dtoplamX += sX;

                xKare += Pow(sX, 2);
                dXY += sY * sX;


            }


            
            double[,] xUssuX = new double[,] { { dgwVeri.RowCount - 1, dtoplamX }, { dtoplamX, xKare } };
            Matrix<double> mlxUssuX = M.DenseOfArray(xUssuX);// kütüphaneyi kullanmak için xUssuX matrisini kopyaladım. 
            mlxUssuX = mlxUssuX.Inverse();
            double[,] xUssuY = new double[,] { { dtoplamY, dXY } };
            Matrix<double> mlxUssuY = M.DenseOfArray(xUssuY);
            mlxUssuY = mlxUssuY.Transpose();
            Matrix<double> beta;
            beta = mlxUssuX.Multiply(mlxUssuY);

            //b1 in işaretini dinamikleştirdim..--------------------------------------------------------------------------------------
            string beta1 = beta[1, 0].ToString();
            string isaret = beta1[0] == '-' ? " " : "+";

            lblBeta.Text = "Ŷ= " +  Round(beta[0, 0], 3) + isaret +  Round(beta[1, 0], 3) + " x";

            //b0 b1 fonksiyonuna değer vererek çizdireceğimiz doğrunun noktalarını belirlemek için-----------------------------------------
            double fuction(double b0, double b1, double d)
            {
                return b0 + b1 * d;
            }
            
            Vector<double> eiKare = Vector<double>.Build.Dense(dgwVeri.RowCount);
            Vector<double> ySapka = Vector<double>.Build.Dense(dgwVeri.RowCount);
            
            //ei'leri hesaplama-----------------------------------------------------------------------------------------------------------
            for (int l = 0; l < dgwVeri.RowCount - 1; l++)
            {
                if (l == 0)
                {
                    dgwVeri.Columns.Add("ei", "ei^2");
                    dgwVeri.Columns.Add("Yi", "Ŷ,");
                }
                ySapka[l] = fuction(beta[0, 0], beta[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString()));
                eiKare[l] = Pow(Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString()) -
                fuction(beta[0, 0], beta[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString())), 2);

                dgwVeri.Rows[l].Cells[2].Value =  Round(eiKare[l], 3);

                toplamYsapkaEksiYortalama +=Pow(ySapka[l]-(dtoplamY/dgwVeri.RowCount),2);
                toplamYiEksiYortalama += Pow(Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString())-(dtoplamY/dgwVeri.RowCount), 2);
               
                dgwVeri.Rows[l].Cells[3].Value =  Round(ySapka[l], 3);

                lblRkare.Text ="R^2= "+  Round(toplamYsapkaEksiYortalama / toplamYiEksiYortalama,3).ToString();

            }
            
            


            //noktaları grafiğe çizdirme--------------------------------------------------------------------------------------
            for (int j = 0; j < dgwVeri.RowCount - 1; j++)
            {
                chart1.Series["Point"].Points.AddXY(dgwVeri.Rows[j].Cells[1].Value, dgwVeri.Rows[j].Cells[0].Value);
            }


            //regresyon doğrusunu çizdirme------------------------------------------------------------------------------------

            for (int k = 1; k < 25; k++)
            {
                chart1.Series["Doğru"].Points.AddXY(k, fuction(beta[0, 0], beta[1, 0], k));
            }

            chart1.Series["Doğru"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //   ---------------------------------------------------------------------------------------------------------------

            /*    
            // satır ekleme  
                  string[] row = new string[] { (dgwTemeLislemler.Rows.Count-1).ToString(), "2"," 3" };
                  dgwVeri.Rows.Add(row);
           */
        }
    }
}

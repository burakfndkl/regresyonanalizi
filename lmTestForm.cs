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

    public partial class lmTestForm : Form
    {

        public lmTestForm()
        {
            InitializeComponent();
            veriOku veri = new veriOku();
            dgwVeri.DataSource = veri.Veriler(this.Text).DataSource;


        }
        double fuction(double b0, double b1, double d)
        {
            return b0 + b1 * d;
        }
        double fuction2(double b0, double b1, double b2, double d1, double d2)
        {
            return b0 + b1 * d1 + b2 * d2;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            var M = Matrix<double>.Build;

            double dtoplamY = 0;//double şeklinde toplam y için
            double dX1Y = 0; // double XYler için
           
            double dtoplamX1 = 0; //double toplam x için
            
            double x1Kare = 0; // double x kareler 
            
            double toplamYsapkaEksiYortalama = 0;
            double toplamYiEksiYortalama = 0;


            for (int i = 0; i < dgwVeri.RowCount - 1; i++)
            {
                double sY = Convert.ToDouble(dgwVeri.Rows[i].Cells[0].Value.ToString());
                dtoplamY += sY;

                double sX1 = Convert.ToDouble(dgwVeri.Rows[i].Cells[1].Value.ToString());
                dtoplamX1 += sX1;

                x1Kare += Pow(sX1, 2);
                dX1Y += sY * sX1;


            }



            double[,] xUssuX = new double[,] { { dgwVeri.RowCount - 1, dtoplamX1}, { dtoplamX1, x1Kare}};
            Matrix<double> mlxUssuX = M.DenseOfArray(xUssuX);// kütüphaneyi kullanmak için xUssuX matrisini kopyaladım. 
            mlxUssuX = mlxUssuX.Inverse();
            double[,] xUssuY = new double[,] { { dtoplamY, dX1Y}};
            Matrix<double> mlxUssuY = M.DenseOfArray(xUssuY);
            mlxUssuY = mlxUssuY.Transpose();
            Matrix<double> beta;
            beta = mlxUssuX.Multiply(mlxUssuY);

            //b1 in işaretini dinamikleştirdim..--------------------------------------------------------------------------------------
            string beta1 = beta[1, 0].ToString();
            string isaret = beta1[0] == '-' ? " " : "+";
           // string beta2 = beta[2, 0].ToString();
           // string isaret2 = beta1[0] == '-' ? " " : "+";

            lblBeta.Text = "Ŷ= " +  Round(beta[0, 0], 3) + isaret +  Round(beta[1, 0], 3) + " x";

            
            Vector<double> ySapka = Vector<double>.Build.Dense(dgwVeri.RowCount);
            Vector<double> ei = Vector<double>.Build.Dense(dgwVeri.RowCount);

            //ei, ei^2 , Ŷ lari hesaplama-----------------------------------------------------------------------------------------------------------
            for (int l = 0; l < dgwVeri.RowCount - 1; l++)
            {
                if (l == 0)
                {
                    dgwVeri.Columns.Add("ei", "ei");
                    dgwVeri.Columns.Add("ei^2", "ei^2");
                    dgwVeri.Columns.Add("Yi", "Ŷ,");
                }
                ySapka[l] = fuction(beta[0, 0], beta[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString()));
                ei[l] = Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString()) -
                fuction(beta[0, 0], beta[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString()));
                dgwVeri.Rows[l].Cells[3].Value =  Round(ei[l], 3);
                dgwVeri.Rows[l].Cells[4].Value =  Round( Pow(ei[l],2), 3);

                toplamYsapkaEksiYortalama += Pow(ySapka[l] - (dtoplamY / dgwVeri.RowCount), 2);
                toplamYiEksiYortalama += Pow(Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString()) - (dtoplamY / dgwVeri.RowCount), 2);

                dgwVeri.Rows[l].Cells[5].Value =  Round(ySapka[l], 3);

                lblRkare.Text = "R^2= " +  Round(toplamYsapkaEksiYortalama / toplamYiEksiYortalama, 3).ToString();

            }




            //noktaları grafiğe çizdirme--------------------------------------------------------------------------------------
            for (int j = 0; j < dgwVeri.RowCount - 1; j++)
            {
                chart1.Series["Point"].Points.AddXY(dgwVeri.Rows[j].Cells[1].Value, dgwVeri.Rows[j].Cells[0].Value);
            }


            //regresyon doğrusunu çizdirme------------------------------------------------------------------------------------

            for (int k = 1; k < 10; k++)
            {
                chart1.Series["Doğru"].Points.AddXY(k, fuction(beta[0, 0], beta[1, 0], k));
            }

            chart1.Series["Doğru"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void btnAsama2_Click(object sender, EventArgs e)
        {
            var M = Matrix<double>.Build;
            double dtoplamY = 0;
            double dX1Y = 0; 

            double dtoplamX1 = 0;

            double x1Kare = 0;
            double dX2Y = 0;
            double dtoplamX2 = 0;
            double dtoplamX2X1 = 0;
            double x2Kare = 0;
            for (int m = 0; m < dgwVeri.RowCount - 1; m++)
            {
                double sY = Convert.ToDouble(dgwVeri.Rows[m].Cells[3].Value.ToString());
                dtoplamY += sY;

                double sX1 = Convert.ToDouble(dgwVeri.Rows[m].Cells[1].Value.ToString());
                dtoplamX1 += sX1;
                double sX2 = Convert.ToDouble(dgwVeri.Rows[m].Cells[2].Value.ToString());
                dtoplamX2 += sX2;
                dtoplamX2X1 += sX1 * sX2;

                x1Kare += Pow(sX1, 2);
                x2Kare += Pow(sX2, 2);
                dX1Y += sY * sX1;
                dX2Y += sY * sX2;


            }


            double[,] xUssuX = new double[,] { { dgwVeri.RowCount - 1, dtoplamX1, dtoplamX2 }, { dtoplamX1, x1Kare, dtoplamX2X1 }, { dtoplamX2, dtoplamX2X1, x2Kare } };
            Matrix<double> mlxUssuX = M.DenseOfArray(xUssuX);// kütüphaneyi kullanmak için xUssuX matrisini kopyaladım. 
            mlxUssuX = mlxUssuX.Inverse();
            double[,] xUssuY = new double[,] { { dtoplamY, dX1Y,dX2Y } };
            Matrix<double> mlxUssuY = M.DenseOfArray(xUssuY);
            mlxUssuY = mlxUssuY.Transpose();
            Matrix<double> beta;
            beta = mlxUssuX.Multiply(mlxUssuY);

            //R^2 HESAPLAMA 2.AŞAMA
            double toplamYsapkaEksiYortalama = 0;
            double toplamYiEksiYortalama = 0;
            Vector<double> ySapka = Vector<double>.Build.Dense(dgwVeri.RowCount);
            Vector<double> ei = Vector<double>.Build.Dense(dgwVeri.RowCount);


            //eilerin toplamı
            double eiToplam = 0;
            for (int n = 0; j < dgwVeri.RowCount-1; n++)
            {
                eiToplam +=Convert.ToDouble(dgwVeri.Rows[n].Cells[3].Value.ToString());


            }
            for (int o = 0; o < dgwVeri.RowCount-1; o++)
            {

                ySapka[o] = fuction2(beta[0, 0], beta[1, 0], beta[2,0], Convert.ToDouble(dgwVeri.Rows[o].Cells[1].Value.ToString()),Convert.ToDouble(dgwVeri.Rows[o].Cells[2].Value.ToString()));
                dgwVeri.Rows[o].Cells[5].Value =  Round(ySapka[o], 3);
                toplamYsapkaEksiYortalama += Pow(ySapka[o] - (eiToplam / dgwVeri.RowCount), 2);
                toplamYiEksiYortalama += Pow(Convert.ToDouble(dgwVeri.Rows[o].Cells[3].Value.ToString()) - (dtoplamY / dgwVeri.RowCount), 2);

                ei[o] = Convert.ToDouble(dgwVeri.Rows[o].Cells[0].Value.ToString()) -
               fuction2(beta[0, 0], beta[1, 0], beta[2,0], Convert.ToDouble(dgwVeri.Rows[o].Cells[1].Value.ToString()), Convert.ToDouble(dgwVeri.Rows[o].Cells[2].Value.ToString()));
                dgwVeri.Rows[o].Cells[3].Value =  Round(ei[o], 3);
                dgwVeri.Rows[o].Cells[4].Value =  Round( Pow(ei[o],2), 3);
            }

            lblRkare.Text = "R^2= " +  Round(toplamYsapkaEksiYortalama / toplamYiEksiYortalama, 3).ToString();
            double TestIstatistik =(toplamYsapkaEksiYortalama / toplamYiEksiYortalama)*dgwVeri.RowCount-1;
            MessageBox.Show(TestIstatistik.ToString());

            //b1,b2 nin işaretini dinamikleştirdim..--------------------------------------------------------------------------------------
            string beta1 = beta[1, 0].ToString();
            string isaret = beta1[0] == '-' ? " " : "+";
            string beta2 = beta[2, 0].ToString();
            string isaret2 = beta2[0] == '-' ? " " : "+";
            lblBeta.Text = "Ŷ= " +  Round(beta[0, 0], 3) + " " + isaret +  Round(beta[1, 0], 3) + "x1" + isaret2 +  Round(beta[2,0],3)+ "x2";

        }
        
    }
}

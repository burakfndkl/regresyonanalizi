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
    public partial class mvdForm : Form
    {
        public mvdForm()
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

            Vector<double> lnx = Vector<double>.Build.Dense(dgwVeri.RowCount);
            Vector<double> lny = Vector<double>.Build.Dense(dgwVeri.RowCount);

            double dtoplamY = 0;//double şeklinde toplam y için
            double dX1Y = 0; // double XYler için
            
            double dtoplamX1 = 0; //double toplam x için

            double x1Kare = 0; // double x kareler 
            
            double toplamLnx = 0;
            double toplamLny = 0;
            double toplamLnxKare = 0;
            double toplamLnyLnx = 0;



            for (int i = 0; i < dgwVeri.RowCount - 1; i++)
            {
                
                double sY = Convert.ToDouble(dgwVeri.Rows[i].Cells[0].Value.ToString());
                lny[i] = Log(sY);
                toplamLny += lny[i];

                dtoplamY += sY;

                double sX1 = Convert.ToDouble(dgwVeri.Rows[i].Cells[1].Value.ToString());
                lnx[i] = Log(sX1);
                toplamLnx += lnx[i];

                dtoplamX1 += sX1;

                toplamLnxKare += Pow(lnx[i], 2);
                x1Kare += Pow(sX1, 2);
                toplamLnyLnx += lnx[i] * lny[i];
                dX1Y += sY * sX1;


            }


            
            double[,] xUssuX = new double[,] { { dgwVeri.RowCount - 1, dtoplamX1 },
                                               { dtoplamX1, x1Kare } };
            double[,] alternatifxUssuX = new double[,] { { dgwVeri.RowCount - 1, toplamLnx },
                                                         { toplamLnx, toplamLnxKare } };

            Matrix<double> m2xUssuX = M.DenseOfArray(alternatifxUssuX);// kütüphaneyi kullanmak için xUssuX matrisini kopyaladım. 
            Matrix<double> mlxUssuX = M.DenseOfArray(xUssuX);// kütüphaneyi kullanmak için xUssuX matrisini kopyaladım. 
            mlxUssuX = mlxUssuX.Inverse();
            m2xUssuX = m2xUssuX.Inverse();
            double[,] xUssuY = new double[,] { { dtoplamY, dX1Y } };
            double[,] alternatifxUssuY = new double[,] { { toplamLny, toplamLnyLnx } };
            Matrix<double> mlxUssuY = M.DenseOfArray(xUssuY);
            Matrix<double> m2xUssuY = M.DenseOfArray(alternatifxUssuY);
            mlxUssuY = mlxUssuY.Transpose();
            m2xUssuY = m2xUssuY.Transpose();
            Matrix<double> beta = mlxUssuX.Multiply(mlxUssuY);
            Matrix<double> betaAlternatif= m2xUssuX.Multiply(m2xUssuY);

            //b1Alternatifin işaretinin dinamikleştirilmesi
            string betaAlter = betaAlternatif[1, 0].ToString();
            string isaret1 = betaAlter[0] == '-' ? " " : "+";

            //b1 in işaretini dinamikleştirdim..--------------------------------------------------------------------------------------
            string beta1 = beta[1, 0].ToString();
            string isaret = beta1[0] == '-' ? " " : "+";

            lblBeta.Text = "Ŷ= " + Round(beta[0, 0], 3) + isaret + Round(beta[1, 0], 3) + " x";
            lblBeta1.Text = "Ŷ= " + Round(betaAlternatif[0, 0], 3) + isaret + Round(betaAlternatif[1, 0], 3) + " x";

            Vector<double> ySapka = Vector<double>.Build.Dense(dgwVeri.RowCount);
            Vector<double> ySapkaAlternatif = Vector<double>.Build.Dense(dgwVeri.RowCount);
            
            Vector<double> ei = Vector<double>.Build.Dense(dgwVeri.RowCount);

            Vector<double> wVector = Vector<double>.Build.Dense(dgwVeri.RowCount);

            //ei, ei^2 , Ŷ lari hesaplama-----------------------------------------------------------------------------------------------------------
            for (int l = 0; l < dgwVeri.RowCount - 1; l++)
            {
                if (l == 0)
                {
                    dgwVeri.Columns.Add("ei", "ei");
                    dgwVeri.Columns.Add("ei^2", "ei^2");
                    dgwVeri.Columns.Add("Yi", "Ŷ,");
                    dgwVeri.Columns.Add("w", "w");
                }
                ySapka[l] = fuction(beta[0, 0], beta[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString()));
                ySapkaAlternatif[l] = fuction(betaAlternatif[0, 0], betaAlternatif[1, 0],lnx[l]);
                wVector[l] = Log(ySapka[l]) - ySapkaAlternatif[l];
                ei[l] = Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString()) -
                fuction(beta[0, 0], beta[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString()));
                dgwVeri.Rows[l].Cells[2].Value = Round(ei[l], 3);
                dgwVeri.Rows[l].Cells[3].Value = Round(Pow(ei[l], 2), 3);

               
                
                dgwVeri.Rows[l].Cells[4].Value = Round(ySapka[l], 3);
                dgwVeri.Rows[l].Cells[5].Value = Round(wVector[l], 3);
                
               

            }

            // [ 1  x  w ] modelinin çözümlemesi
            dtoplamX1 = 0;
            dtoplamY = 0;
            dX1Y = 0;
            double toplamW = 0;
            x1Kare = 0;
            double dX1w = 0;
            double wKare = 0;
            double wY = 0;

            for (int i = 0; i < dgwVeri.RowCount -1; i++)
            {
                double sY = Convert.ToDouble(dgwVeri.Rows[i].Cells[0].Value.ToString());
                double sX = Convert.ToDouble(dgwVeri.Rows[i].Cells[1].Value.ToString());
                double w = Convert.ToDouble(dgwVeri.Rows[i].Cells[5].Value.ToString());

                dtoplamY += sY;
                dtoplamX1 += sX;
                toplamW += w;
                x1Kare += Pow(sX, 2);
                dX1w += sX * w;
                dX1Y += sX * sY;
                wKare += Pow(w, 2);
                wY += w * sY;



            }

            double[,] xUssuXtest = new double[,] { { dgwVeri.RowCount - 1, dtoplamX1,toplamW },
                                                   { dtoplamX1, x1Kare,dX1w },
                                                   {toplamW,dX1w,wKare } };
            Matrix<double> m1xUssuXtest = M.DenseOfArray(xUssuXtest);// kütüphaneyi kullanmak için xUssuX matrisini kopyaladım. 
            m1xUssuXtest = m1xUssuXtest.Inverse();
            double[,] xUssuYtest = new double[,] { { dtoplamY, dX1Y, wY } };
            Matrix<double> mlxUssuYtest = M.DenseOfArray(xUssuYtest);
            mlxUssuYtest = mlxUssuYtest.Transpose();
            Matrix<double> betaTest = m1xUssuXtest.Multiply(mlxUssuYtest);

            //b1,b2 nin işaretini dinamikleştirdim..--------------------------------------------------------------------------------------
            string beta1test = betaTest[1, 0].ToString();
            string isaretTest = beta1test[0] == '-' ? " " : "+";
            string beta2test = betaTest[2, 0].ToString();
            string isaret2test = beta2test[0] == '-' ? " " : "+";
            lblBetaTest.Text = "Ŷ= " + Round(betaTest[0, 0], 3) + " " + isaretTest + Round(betaTest[1, 0], 3) + "x1" + isaret2test + Round(betaTest[2, 0], 3) + "x2";

            Vector<double> HSySapka = Vector<double>.Build.Dense(dgwVeri.RowCount);

            Vector<double> HSeiKare = Vector<double>.Build.Dense(dgwVeri.RowCount);

            double HSeiKareToplam = 0;
            double varB2 = 0;
            double th = 0;
            for (int k = 0; k < dgwVeri.RowCount - 1; k++)
            {
                if (k == 0)
                {
                    dgwVeri.Columns.Add("ei", "HS ei^2");
                    dgwVeri.Columns.Add("Yi", " Ŷ ");

                }

                HSySapka[k] = fuction2(betaTest[0, 0], betaTest[1, 0], betaTest[2, 0], Convert.ToDouble(dgwVeri.Rows[k].Cells[1].Value.ToString()), wVector[k]);
                HSeiKare[k] = Pow(Convert.ToDouble(dgwVeri.Rows[k].Cells[0].Value.ToString()) - HSySapka[k], 2);
                HSeiKareToplam += HSeiKare[k];
                dgwVeri.Rows[k].Cells[6].Value = Round(HSeiKare[k], 3);

                dgwVeri.Rows[k].Cells[7].Value = Round(HSySapka[k], 3);

                
            }
            varB2 = HSeiKareToplam * m1xUssuXtest[2, 2];
            th = (betaTest[2, 0] - 0) / Sqrt(varB2);
            MessageBox.Show(Round(th,4).ToString());
            //noktaları grafiğe çizdirme--------------------------------------------------------------------------------------
            for (int j = 0; j < dgwVeri.RowCount - 1; j++)
            {
                chart1.Series["Point"].Points.AddXY(dgwVeri.Rows[j].Cells[1].Value, dgwVeri.Rows[j].Cells[0].Value);
            }


            //regresyon doğrusunu çizdirme------------------------------------------------------------------------------------

            for (int m = 1; m < 10; m++)
            {
                chart1.Series["Doğru"].Points.AddXY(m, fuction(beta[0, 0], beta[1, 0], m));
            }

            chart1.Series["Doğru"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

       
    }
}

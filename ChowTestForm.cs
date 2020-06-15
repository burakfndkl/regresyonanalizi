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
    public partial class ChowTestForm : Form
    {
        public ChowTestForm()
        {
            InitializeComponent();
            veriOku veri = new veriOku();
            dgwVeri.DataSource = veri.Veriler(this.Text).DataSource;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            var M = Matrix<double>.Build;

            double dtoplamY1 = 0;//double şeklinde toplam y için
            double dtoplamY2 = 0;
            double dtoplamYT = 0;

            double dXY1 = 0; // double XYler için
            double dXY2 = 0;
            double dXYT = 0;

            double dtoplamX1 = 0; //double toplam x için
            double dtoplamX2 = 0;
            double dtoplamXT = 0;

            double xKare1 = 0; // double x kareler 
            double xKare2 = 0;
            double xKareT = 0;

            double donem;
            double sY1;
            double sY2;
            double sYT;

            double sX1;
            double sX2;
            double sXT;

            int donem1sayi=0;
            int donem2sayi=0;
            for (int i = 0; i < dgwVeri.RowCount - 1; i++)
            {
                donem = Convert.ToDouble(dgwVeri.Rows[i].Cells[2].Value.ToString());

                if (donem==0)
                {
                    sY1 = Convert.ToDouble(dgwVeri.Rows[i].Cells[0].Value.ToString());
                    dtoplamY1 += sY1;
                    sX1 = Convert.ToDouble(dgwVeri.Rows[i].Cells[1].Value.ToString());
                    dtoplamX1 += sX1;
                    xKare1 += Pow(sX1, 2);
                    dXY1 += sY1 * sX1;
                    donem1sayi += 1;
                }
                else
                {
                    sY2 = Convert.ToDouble(dgwVeri.Rows[i].Cells[0].Value.ToString());
                    dtoplamY2 += sY2;
                    sX2 = Convert.ToDouble(dgwVeri.Rows[i].Cells[1].Value.ToString());
                    dtoplamX2 += sX2;
                    xKare2 += Pow(sX2, 2);
                    dXY2 += sY2 * sX2;
                    donem2sayi += 1;
                }

            }
            dtoplamYT = dtoplamY1 + dtoplamY2;
            dtoplamXT = dtoplamX1 + dtoplamX2;
            xKareT = xKare1 + xKare2;
            dXYT = dXY1 + dXY2;



            double[,] xUssuX1 = new double[,] { { donem1sayi, dtoplamX1 }, { dtoplamX1, xKare1 } };
            double[,] xUssuX2 = new double[,] { { donem2sayi, dtoplamX2 }, { dtoplamX2, xKare2 } };
            double[,] xUssuXT = new double[,] { { dgwVeri.RowCount - 1, dtoplamXT }, { dtoplamXT, xKareT } };
            Matrix<double> mlxUssuX1 = M.DenseOfArray(xUssuX1);// kütüphaneyi kullanmak için xUssuX matrisini kopyaladım. 
            Matrix<double> mlxUssuX2 = M.DenseOfArray(xUssuX2);
            Matrix<double> mlxUssuXT = M.DenseOfArray(xUssuXT);
            mlxUssuX1 = mlxUssuX1.Inverse();
            mlxUssuX2 = mlxUssuX2.Inverse();
            mlxUssuXT = mlxUssuXT.Inverse();

            double[,] xUssuY1 = new double[,] { { dtoplamY1, dXY1 } };
            double[,] xUssuY2 = new double[,] { { dtoplamY2, dXY2 } };
            double[,] xUssuYT = new double[,] { { dtoplamYT, dXYT } };
            Matrix<double> mlxUssuY1 = M.DenseOfArray(xUssuY1);
            Matrix<double> mlxUssuY2 = M.DenseOfArray(xUssuY2);
            Matrix<double> mlxUssuYT = M.DenseOfArray(xUssuYT);

            mlxUssuY1 = mlxUssuY1.Transpose();
            mlxUssuY2 = mlxUssuY2.Transpose();
            mlxUssuYT = mlxUssuYT.Transpose();
            Matrix<double> beta1donem;
            Matrix<double> beta2donem;
            Matrix<double> betaTdonem;
            beta1donem = mlxUssuX1.Multiply(mlxUssuY1);

            beta2donem = mlxUssuX2.Multiply(mlxUssuY2);
            betaTdonem = mlxUssuXT.Multiply(mlxUssuYT);


            //b1 in işaretini dinamikleştirdim..--------------------------------------------------------------------------------------
            string beta1 = beta1donem[1, 0].ToString();
            string isaret1donem = beta1[0] == '-' ? " " : "+";

            lblBeta1donem.Text = "Ŷ= " +  Round(beta1donem[0, 0], 3) + isaret1donem +  Round(beta1donem[1, 0], 3) + " x";

            string beta2 = beta2donem[1, 0].ToString();
            string isaret2donem = beta2[0] == '-' ? " " : "+";

            lblBeta2donem.Text = "Ŷ= " +  Round(beta2donem[0, 0], 3) + isaret2donem +  Round(beta2donem[1, 0], 3) + " x";

            string betaT = beta2donem[1, 0].ToString();
            string isaretTdonem = betaT[0] == '-' ? " " : "+";

            lblBetaTdonem.Text = "Ŷ= " +  Round(betaTdonem[0, 0], 3) + isaretTdonem +  Round(betaTdonem[1, 0], 3) + " x";

            //b0 b1 fonksiyonuna değer vererek çizdireceğimiz doğrunun noktalarını belirlemek için-----------------------------------------
            double fuction(double b0, double b1, double d)
            {
                return b0 + b1 * d;
            }

            Vector<double> eiKare1 = Vector<double>.Build.Dense(donem1sayi);
            Vector<double> eiKare2 = Vector<double>.Build.Dense(donem2sayi);
            Vector<double> eiKareT = Vector<double>.Build.Dense(dgwVeri.RowCount);

            Vector<double> ySapka1 = Vector<double>.Build.Dense(donem1sayi);
            Vector<double> ySapka2 = Vector<double>.Build.Dense(donem2sayi);
            Vector<double> ySapkaT = Vector<double>.Build.Dense(dgwVeri.RowCount);

            double toplamE1donem = 0;
            double toplamE2donem = 0;
            double toplamETdonem = 0;
            //ei'leri hesaplama-----------------------------------------------------------------------------------------------------------
            for (int l = 0; l < dgwVeri.RowCount - 1; l++)
            {
                if (l == 0)
                {
                    dgwVeri.Columns.Add("ei", "1.donem ei^2");
                    dgwVeri.Columns.Add("Yi", "1.donem Ŷ,");
                    dgwVeri.Columns.Add("ei", "2.donem ei^2");
                    dgwVeri.Columns.Add("Yi", "2.donem Ŷ,");
                    dgwVeri.Columns.Add("ei", "Toplam donem ei^2");
                    dgwVeri.Columns.Add("Yi", "Toplam donem Ŷ,");
                }
                if (donem1sayi > l)
                {
                    ySapka1[l] = fuction(beta1donem[0, 0], beta1donem[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString()));
                    eiKare1[l] = Pow(Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString()) -
               fuction(beta1donem[0, 0], beta1donem[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString())), 2);
                    dgwVeri.Rows[l].Cells[3].Value =  Round(eiKare1[l], 3);

                    dgwVeri.Rows[l].Cells[4].Value =  Round(ySapka1[l], 3);
                    toplamE1donem += eiKare1[l];
                }
                if (donem1sayi<=l)
                {
                    ySapka2[l-donem1sayi] = fuction(beta2donem[0, 0], beta2donem[1, 0], Convert.ToDouble(dgwVeri.Rows[donem1sayi].Cells[1].Value.ToString()));
                    
                    eiKare2[l-donem1sayi] = Pow(Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString()) -
                    fuction(beta2donem[0, 0], beta2donem[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString())), 2);

                    dgwVeri.Rows[l].Cells[5].Value =  Round(eiKare2[l-donem1sayi], 3);

                    dgwVeri.Rows[l].Cells[6].Value =  Round(ySapka2[l-donem1sayi], 3);
                    toplamE2donem += eiKare2[l-donem1sayi];
                }

                ySapkaT[l] = fuction(betaTdonem[0, 0], betaTdonem[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString()));
                eiKareT[l] = Pow(Convert.ToDouble(dgwVeri.Rows[l].Cells[0].Value.ToString()) -
                fuction(betaTdonem[0, 0], betaTdonem[1, 0], Convert.ToDouble(dgwVeri.Rows[l].Cells[1].Value.ToString())), 2);
                
                
                toplamETdonem += eiKareT[l];

                
                dgwVeri.Rows[l].Cells[7].Value =  Round(eiKareT[l], 3);

                dgwVeri.Rows[l].Cells[8].Value =  Round(ySapkaT[l], 3);
                

            }
            double Fh = ((toplamETdonem - (toplamE1donem + toplamE2donem)) / 2) / ((toplamE2donem + toplamE1donem) / donem1sayi + donem2sayi - 4);
            MessageBox.Show(Fh.ToString());



            //noktaları grafiğe çizdirme--------------------------------------------------------------------------------------
            for (int j = 0; j < dgwVeri.RowCount - 1; j++)
            {
                chart1.Series["Point"].Points.AddXY(dgwVeri.Rows[j].Cells[1].Value, dgwVeri.Rows[j].Cells[0].Value);
            }


            //regresyon doğrusunu çizdirme------------------------------------------------------------------------------------

            for (int k = 1; k < 25; k++)
            {
                chart1.Series["Doğru"].Points.AddXY(k, fuction(beta1donem[0, 0], beta1donem[1, 0], k));
            }

            chart1.Series["Doğru"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

     
    }
}

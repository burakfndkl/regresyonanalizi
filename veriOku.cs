using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Ekonometri
{
    class veriOku
    {
        //--------------------- VERİ OKUMA -----------------------------

        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\burakfndkl\Desktop\ekoVeri.xlsx;
                                                        Extended Properties='Excel 12.0 Xml; HDR = YES;'");
       public DataGrid Veriler(string sayfa)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [" + sayfa + "$]", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGrid data = new DataGrid();
            data.DataSource = dt;
             return data;
        }

        //---------------------- VERİ OKUMA --------------------------
    }
}

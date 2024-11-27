using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelKayit
{
    public partial class FormGrafik : Form
    {
        public FormGrafik()
        {
            InitializeComponent();
        }

        private void FormGrafik_Load(object sender, EventArgs e)
        {
            VTIslem.baglanti.Open();
            string komut1 = "SELECT PerSehir,COUNT(*) FROM Tbl_Personel GROUP BY PerSehir";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Connection = VTIslem.baglanti;
            VTIslem.command.CommandText = komut1;
            SqlDataReader reader = VTIslem.command.ExecuteReader();

            while (reader.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(reader[0], reader[1]);
            }
            VTIslem.baglanti.Close();

            VTIslem.baglanti.Open();
            string komut2 = "SELECT PerMeslek,AVG(PerMaas) FROM Tbl_Personel GROUP BY PerMeslek";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Connection = VTIslem.baglanti;
            VTIslem.command.CommandText = komut2;
            SqlDataReader reader2 = VTIslem.command.ExecuteReader();

            while (reader2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(reader2[0], reader2[1]);
            }
            VTIslem.baglanti.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayit
{
    public partial class FormIstatistik : Form
    {
        public FormIstatistik()
        {
            InitializeComponent();
        }

        private void FormIstatistik_Load(object sender, EventArgs e)
        {
            VTIslem.baglanti.Open();
            string toplam = "SELECT COUNT(*) FROM Tbl_Personel";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Connection = VTIslem.baglanti;
            VTIslem.command.CommandText = toplam;
            SqlDataReader reader = VTIslem.command.ExecuteReader();
          
            while (reader.Read())
            {
                LblTopPer.Text = reader[0].ToString();
            }
            VTIslem.baglanti.Close();

            VTIslem.baglanti.Open();
            string evlitoplam = "SELECT COUNT(*) FROM Tbl_Personel WHERE PerDurum=1";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Connection = VTIslem.baglanti;
            VTIslem.command.CommandText = evlitoplam;
            SqlDataReader reader2 = VTIslem.command.ExecuteReader();
            
            while (reader2.Read())
            {
                LblEvliPer.Text = reader2[0].ToString();
            }
            VTIslem.baglanti.Close();

            VTIslem.baglanti.Open();
            string maasaralik = "SELECT COUNT(*) FROM Tbl_Personel WHERE PerMaas < 3000";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Connection = VTIslem.baglanti;
            VTIslem.command.CommandText = maasaralik;
            SqlDataReader reader3 = VTIslem.command.ExecuteReader();
            
            while (reader3.Read())
            {
                LblMaasPer.Text = reader3[0].ToString();
            }
            VTIslem.baglanti.Close();

            VTIslem.baglanti.Open();
            string sehir = "SELECT COUNT(DISTINCT PerSehir) FROM Tbl_Personel";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Connection = VTIslem.baglanti;
            VTIslem.command.CommandText = sehir;
            SqlDataReader reader4 = VTIslem.command.ExecuteReader();
            
            while (reader4.Read())
            {
                LblSehir.Text = reader4[0].ToString();
            }
            VTIslem.baglanti.Close();

            VTIslem.baglanti.Open();
            string ortmaas = "SELECT AVG(PerMaas) FROM Tbl_Personel";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Connection = VTIslem.baglanti;
            VTIslem.command.CommandText = ortmaas;
            SqlDataReader reader5 = VTIslem.command.ExecuteReader();
            
            while (reader5.Read())
            {
                LblOrtMaas.Text = reader5[0].ToString();
            }
            VTIslem.baglanti.Close();
        }
    }
}

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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VTIslem.baglanti.Open();
                string kullanici = TBoxKullaniciAdi.Text;
                string sifre = TBoxSifre.Text;
                string giris = "SELECT * FROM Tbl_Giris WHERE KullaniciAdi=@kullanici AND Sifre=@sifre";
                VTIslem.command.Parameters.Clear();
                VTIslem.command.Parameters.AddWithValue("@kullanici", kullanici);
                VTIslem.command.Parameters.AddWithValue("@sifre", sifre);
                VTIslem.command.Connection = VTIslem.baglanti;
                VTIslem.command.CommandText = giris;
                SqlDataReader reader = VTIslem.command.ExecuteReader();

                if (reader.Read())
                {
                    AnaForm afrm = new AnaForm();
                    afrm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                VTIslem.baglanti.Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Beklenmedik bir hata var.","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }
    }
}

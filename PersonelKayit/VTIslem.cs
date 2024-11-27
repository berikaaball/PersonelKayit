using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PersonelKayit
{
    public static class VTIslem
    {
       public static SqlConnection baglanti = new SqlConnection(VTBaglanti.baglanticumlesi);
        public static SqlCommand command = new SqlCommand();
        static SqlDataAdapter adapter;


        public static DataTable VeriGetir(string sec)
        {
            DataTable goster = new DataTable();
            adapter = new SqlDataAdapter(sec, baglanti);
            adapter.Fill(goster);
            return goster;

        }

        public static void KomutCalistir(string komut)
        {
            try
            { 
                if(baglanti.State == ConnectionState.Closed)
            
                baglanti.Open();
                command.Connection = baglanti;
                command.CommandText=komut;
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantıda bir problem oluştu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }

        }

       
    }

   
}

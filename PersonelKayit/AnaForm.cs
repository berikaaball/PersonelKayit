using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PersonelKayit
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            VeriDoldur();
        }

        private void VeriDoldur()
        {
            string sec = "Select * FROM Tbl_Personel";
            DGVTabloGoster.DataSource = VTIslem.VeriGetir(sec);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            Boolean durum= false;
            if (RBtnEvli.Checked)
            {
                durum = true;
            }
            else if (RBtnBekar.Checked)
            {
                durum = false;
            }

            string ad = TBoxAdi.Text;
            string soyad = TBoxSoyadi.Text;
            string sehir = CBoxSehir.Text;
            int maas = Convert.ToInt16(MskdTBoxMaas.Text);
            string meslek = TBoxMeslek.Text;
            VTIslem.baglanti.Open();
            string ekle = "INSERT INTO Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerDurum,PerMeslek) VALUES" +
                " (@PerAd,@PerSoyad,@PerSehir,@PerMaas,@PerDurum,@PerMeslek)";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Parameters.AddWithValue("@PerAd", ad);
            VTIslem.command.Parameters.AddWithValue("PerSoyad", soyad);
            VTIslem.command.Parameters.AddWithValue("PerSehir", sehir);
            VTIslem.command.Parameters.AddWithValue("PerMaas", maas);
            VTIslem.command.Parameters.AddWithValue("PerDurum", durum);
            VTIslem.command.Parameters.AddWithValue("PerMeslek", meslek);
            VTIslem.KomutCalistir(ekle);
            VeriDoldur();
            TBoxAdi.Clear();
            TBoxSoyadi.Clear();
            TBoxMeslek.Clear();
            CBoxSehir.Text = " ";
            MskdTBoxMaas.Clear();
            durum = false;
        }

        private void DGVTabloGoster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TBoxID.Text = DGVTabloGoster.CurrentRow.Cells[0].Value.ToString();
            TBoxAdi.Text = DGVTabloGoster.CurrentRow.Cells[1].Value.ToString();
            TBoxSoyadi.Text = DGVTabloGoster.CurrentRow.Cells[2].Value.ToString();
            CBoxSehir.Text = DGVTabloGoster.CurrentRow.Cells[3].Value.ToString();
            MskdTBoxMaas.Text = DGVTabloGoster.CurrentRow.Cells[4].Value.ToString();
            TBoxMeslek.Text = DGVTabloGoster.CurrentRow.Cells[6].Value.ToString();
            object secilen = DGVTabloGoster.CurrentRow.Cells[5].Value;
            if (secilen != null && bool.TryParse(secilen.ToString(),out bool boolValue))
            {
                if(boolValue)
                {
                    RBtnEvli.Checked = true; 
                }
                else
                {
                    RBtnBekar.Checked = true;
                }
            }
           
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(TBoxID.Text);
            string sil = "DELETE FROM Tbl_Personel WHERE PerId=@PerId";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Parameters.AddWithValue("@PerId", id);
            VTIslem.KomutCalistir(sil);
            VeriDoldur();
            TBoxAdi.Clear();
            TBoxSoyadi.Clear();
            TBoxMeslek.Clear();
            CBoxSehir.Text = " ";
            MskdTBoxMaas.Clear();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            Boolean durum = false;
            if (RBtnEvli.Checked)
            {
                durum = true;
            }
            else if (RBtnBekar.Checked)
            {
                durum = false;
            }
            int id =Convert.ToInt16(TBoxID.Text);
            string ad = TBoxAdi.Text;
            string soyad = TBoxSoyadi.Text;
            string sehir = CBoxSehir.Text;
            int maas = Convert.ToInt16(MskdTBoxMaas.Text);
            string meslek = TBoxMeslek.Text;
            //VTIslem.baglanti.Open();
            string guncelle = "UPDATE Tbl_Personel SET PerAd = @PerAd, PerSoyad = @PerSoyad, PerSehir = @PerSehir, " +
            "PerMaas = @PerMaas, PerDurum = @PerDurum, PerMeslek = @PerMeslek WHERE PerId = @PerId";
            VTIslem.command.Parameters.Clear();
            VTIslem.command.Parameters.AddWithValue("@PerId", id);
            VTIslem.command.Parameters.AddWithValue("@PerAd", ad);
            VTIslem.command.Parameters.AddWithValue("PerSoyad", soyad);
            VTIslem.command.Parameters.AddWithValue("PerSehir", sehir);
            VTIslem.command.Parameters.AddWithValue("PerMaas", maas);
            VTIslem.command.Parameters.AddWithValue("PerDurum", durum);
            VTIslem.command.Parameters.AddWithValue("PerMeslek", meslek);
            VTIslem.KomutCalistir(guncelle);
            VeriDoldur();
            TBoxID.Clear();
            TBoxAdi.Clear();
            TBoxSoyadi.Clear();
            TBoxMeslek.Clear();
            CBoxSehir.Text = " ";
            MskdTBoxMaas.Clear();
            durum = false;
        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
          FormIstatistik ist = new FormIstatistik();
            ist.Show();
        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            FormGrafik grf = new FormGrafik();
            grf.Show();
        }
    }
}

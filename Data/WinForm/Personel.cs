using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class PersonelForm : Form
    {
        IPersonelService personelService;
        public PersonelForm()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                personelService = new PersonelService();

                personelService.insert("insert into Personel (Adi,Soyadi,KayitTarihi)" +
                    "values('" + txtAd.Text + "','" + txtSoyad.Text + "','" + Convert.ToDateTime(dtpKayitTarihi.Text) + "')");
                PersonelListele();

                lblHata.ForeColor = Color.Blue;
                lblHata.Text = ("Kayıt Başarılı");

            }
            catch (Exception ex)
            {
                lblHata.ForeColor = Color.Red;
                lblHata.Text = ("Kayıt Başarısız");

            }
            
        }

        private void PersonelForm_Load(object sender, EventArgs e)
        {
            PersonelListele();
        }

        void PersonelListele()
        {
            personelService = new PersonelService();

            var sonuc = personelService.PersonelListesi("select * from Personel");

            dtgPersonelListesi.DataSource = sonuc;
            dtgPersonelListesi.Columns[0].Visible = false;
            dtgPersonelListesi.Columns[2].Width = 57;
        }
    }
}

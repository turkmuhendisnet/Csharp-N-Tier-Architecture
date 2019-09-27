using Service;
using Service.DTO;
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
                    "values('" + txtAd.Text + "','" + txtSoyad.Text + "','" + Convert.ToDateTime(dtpKayitTarihi.Text).ToString() + "')");

                lstPersonelListesi.Items.Clear();
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

            /*Data Grid View Listeleme */
            dtgPersonelListesi.Visible = false;

            //dtgPersonelListesi.DataSource = sonuc;
            //dtgPersonelListesi.Columns[0].Visible = false;
            //dtgPersonelListesi.Columns[2].Width = 57;


            foreach (PersonelDTO personel in sonuc)
            {
                ListViewItem personeller = new ListViewItem(personel.Id.ToString());
                personeller.SubItems.Add(personel.Adi);
                personeller.SubItems.Add(personel.Soyadi);
                personeller.SubItems.Add(personel.KayitTarihi.ToShortDateString());

                lstPersonelListesi.Items.Add(personeller);
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
                     
            try
            {
                /*data grid view veri seçme */
                //var SeciliPersonel = (PersonelDTO)dtgPersonelListesi.SelectedRows[0].DataBoundItem;

                var SeciliPersonel = lstPersonelListesi.SelectedItems[0].SubItems[0].Text.ToString();
                personelService = new PersonelService();

                personelService.delete("delete from Personel where Id= " + SeciliPersonel + "");

                lblHata.ForeColor = Color.Blue;    
                lblHata.Text = "Silme Başarılı";
                lstPersonelListesi.Items.Clear();
                PersonelListele();
            }
            catch (Exception)
            {
                lblHata.ForeColor = Color.Red;
                lblHata.Text = "Silme Başarısız";
            }
        }
    }
}

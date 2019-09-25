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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            IPersonelService personelService = new PersonelService();

           var sonuc=  personelService.PersonelListesi("select * from Personel");

            
            dtgPersonelListesi.DataSource = sonuc;
            dtgPersonelListesi.Columns[0].Visible = false;
            dtgPersonelListesi.Columns[2].Width = 57;

            txtAd.Text = sonuc[0].Adi;
        }
    }
}

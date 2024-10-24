using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gorselSinavProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLOGRENCIs.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TBLOGRENCI ekle = new TBLOGRENCI();
            ekle.AD = txtAd.Text;
            ekle.SOYAD = txtSoyad.Text;
            db.TBLOGRENCIs.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Eklendi.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var sil = db.TBLOGRENCIs.Find(id);
            db.TBLOGRENCIs.Remove(sil);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Silindi.");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var gncl = db.TBLOGRENCIs.Find(id);
            gncl.AD = txtAd.Text;
            gncl.SOYAD = txtSoyad.Text;
            gncl.FOTOGRAF = txtFotograf.Text;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Güncelleme İşlemi Başarılı.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLDERS.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var sorgu = from item in db.TBLNOTs
                         select new
                         {
                             item.NOTID,
                             item.TBLOGRENCI.AD,
                             item.SINAV1,
                             item.SINAV2,
                             item.SINAV3,
                             item.TBLDER.DERSAD
                         };
            dataGridView1.DataSource = sorgu.ToList();
        }
    }
}

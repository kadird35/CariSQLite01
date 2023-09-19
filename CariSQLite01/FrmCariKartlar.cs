using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariSQLite01
{
    public partial class FrmCariKartlar : Form
    {
        int? prm_id = null;
        public bool Kaydedildi = false;
       // public FrmKaydet(int? id = null)
        public FrmCariKartlar()
        {
            InitializeComponent();
            KartListele();
        }

        void KartListele()
        {
            string sql1 = "SELECT " +
                         "carikrt.id," +
                         "carikrt.Ckod," +
                         "carikrt.Cisim," +
                         "carikrt.tip,"+
                         "ctip.ctip_adi," +
                         "carikrt.Adres"+
                         " from carikrt,ctip" +
                         " WHERE carikrt.tip = ctip.id"+
                         " ORDER BY carikrt.Ckod";
                        
            dataGridView1.DataSource = CRUD.Listele(sql1);
        }

        private void FrmCariKartlar_Load(object sender, EventArgs e)
        {

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            txtCkod.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (prm_id == null)
            {
                string sql = "Insert into carikrt(Ckod,Cisim,tip,Adres)" +
                             " Values('" + txtCkod.Text + 
                             "','" + txtCisim.Text + "','" 
                                   + cmbTip.Text + "','" + txtAdres.Text + "')";               
                
                if (CRUD.ESG(sql))
                {
                    Kaydedildi = true;
                    MessageBox.Show("Ekleme İşlemi Başarılı");
                }
            }

            else
            {
                string sql = "Update carikrt set Ckod='" + txtCkod.Text + 
                             "',Cisim='" + txtCisim.Text + 
                             "',tip='" + cmbTip.Text + 
                             "',Adres='" + txtAdres.Text + "' Where id='" + prm_id + "'";
                if (CRUD.ESG(sql))
                {
                    Kaydedildi = true;
                    MessageBox.Show("Güncelleme İşlemi Başarılı");
                }

            }

            KartListele();
            txtCkod.Text = "";
            txtCisim.Text = "";
            cmbTip.Text = "";
            txtAdres.Text = "";
            groupBox1.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            txtCkod.Enabled = false;
            txtCisim.Focus();

            int seciliid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            txtCkod.Text = dataGridView1.CurrentRow.Cells["Ckod"].Value.ToString();
            txtCisim.Text = dataGridView1.CurrentRow.Cells["Cisim"].Value.ToString();
            cmbTip.Text = dataGridView1.CurrentRow.Cells["tip"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
            if (Kaydedildi)
            {
                KartListele();
            }


        }

        private void FrmCariKartlar_FormClosing(object sender, FormClosingEventArgs e)
        {
    
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Kayıt Silinecek Onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                int seciliid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                string sql = "Delete From carikrt Where id='" + seciliid + "'";
                if (CRUD.ESG(sql))
                {
                    KartListele();
                }
            }
        }
    }
}

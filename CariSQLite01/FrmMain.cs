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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Listele();
        }
        

     void Listele()
    {
        string sql = "SELECT "+
                     "carikrt.Ckod,"+
                     "carikrt.Cisim,"+
                     "ctip.ctip_adi,"+
                     "carikrt.Top_borc,"+
                     "carikrt.Top_alacak,sum(carikrt.Top_borc-carikrt.Top_alacak) as Bakiye from carikrt,ctip"+
                     " WHERE carikrt.tip = ctip.id"+
                     " GROUP BY carikrt.Id"+
                     " ORDER BY carikrt.Ckod";
        dataGridView1.DataSource = CRUD.Listele(sql);
    }

        private void btnCariKartlar_Click(object sender, EventArgs e)
        {
            FrmCariKartlar frmCariKartlar = new FrmCariKartlar();
            frmCariKartlar.ShowDialog();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FrmRaporlar frmRaporlar = new FrmRaporlar();
            frmRaporlar.ShowDialog();
        }

        private void btnHareketler_Click(object sender, EventArgs e)
        {
            FrmHareketler frmHareketler = new FrmHareketler();
            frmHareketler.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}

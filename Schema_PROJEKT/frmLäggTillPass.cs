using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schema_PROJEKT
{
    public partial class frmLäggTillPass : Form
    {
        public frmLäggTillPass(List<clsPass> passLista)
        {
            InitializeComponent();

            this.passLista = passLista;
        }

        List<clsPass> passLista;

        public TimeOnly Starttid
        {
            get { return new TimeOnly(dtpStarttid.Value.Hour, dtpStarttid.Value.Minute); }
        }
        public TimeOnly Sluttid
        {
            get { return new TimeOnly(dtpSluttid.Value.Hour, dtpSluttid.Value.Minute); }
        }
        public string Namn
        {
            get { return tbxNamn.Text; }
        }
        public string Övrigt
        {
            get { return tbxÖvrigt.Text; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (clsPass pass in passLista)
            {
                if (Starttid.IsBetween(pass.Starttid, pass.Sluttid) || Sluttid.IsBetween(pass.Starttid, pass.Sluttid))
                {
                    MessageBox.Show("Ett pass överlappar med den valda tiden", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
        }
        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dtpStarttid_ValueChanged(object sender, EventArgs e)
        {
            KollaOK();
        }
        private void dtpSluttid_ValueChanged(object sender, EventArgs e)
        {
            KollaOK();
        }
        private void tbxNamn_TextChanged(object sender, EventArgs e)
        {
            KollaOK();
        }
        private void KollaOK()
        {
            if (TimeOnly.FromDateTime(dtpStarttid.Value) < TimeOnly.FromDateTime(dtpSluttid.Value) && tbxNamn.Text != "")
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        
    }
}

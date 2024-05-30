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
    public partial class frmRedigeraPass : Form
    {
        public frmRedigeraPass(List<clsPass> passLista, int redigeratIndex)
        {
            InitializeComponent();

            this.passLista = passLista;
            this.redigeratIndex = redigeratIndex;
            redigeratPass = passLista[redigeratIndex];

            dtpStarttid.Value = dtpStarttid.MinDate.Add(redigeratPass.Starttid.ToTimeSpan());
            dtpSluttid.Value = dtpSluttid.MinDate.Add(redigeratPass.Sluttid.ToTimeSpan());
            tbxNamn.Text = redigeratPass.Namn;
            tbxÖvrigt.Text = redigeratPass.Övrigt;
        }

        List<clsPass> passLista;
        int redigeratIndex;
        clsPass redigeratPass;

        public TimeOnly Starttid
        {
            get { return TimeOnly.FromDateTime(dtpStarttid.Value); }
        }
        public TimeOnly Sluttid
        {
            get { return TimeOnly.FromDateTime(dtpSluttid.Value); }
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
                if ((Starttid.IsBetween(pass.Starttid, pass.Sluttid) || Sluttid.IsBetween(pass.Starttid, pass.Sluttid))
                    && passLista.IndexOf(pass) != redigeratIndex)
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

        private void btnRaderaPass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Vill du ta bort passet {redigeratPass.Namn}?", "Ta bort sal", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DialogResult = DialogResult.No;
            }
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

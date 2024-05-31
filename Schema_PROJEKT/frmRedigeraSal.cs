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
    public partial class frmRedigeraSal : Form
    {
        public frmRedigeraSal(List<clsSal> salLista, int redigeratIndex)
        {
            InitializeComponent();

            this.salLista = salLista;
            this.redigeratIndex = redigeratIndex;
            redigeradSal = salLista[redigeratIndex];

            tbxSalNamn.Text = redigeradSal.Namn;
            nudAntalPlatser.Value = redigeradSal.Platser;
            tbxÖvrigt.Text = redigeradSal.Övrigt;
        }

        List<clsSal> salLista;
        int redigeratIndex;
        clsSal redigeradSal;

        public string SalNamn
        {
            get { return tbxSalNamn.Text; }
        }
        public int AntalPlatser
        {
            get { return (int)nudAntalPlatser.Value; }
        }
        public string Övrigt
        {
            get { return tbxÖvrigt.Text; }
        }

        private void btnRaderaSal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Vill du ta bort salen {redigeradSal.Namn}?", "Ta bort sal", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DialogResult = DialogResult.No;
            }
        }

        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (clsSal sal in salLista) //Kollar om salen redan finns i listan
            {
                if (sal.Namn == tbxSalNamn.Text && salLista.IndexOf(sal) != redigeratIndex)
                {
                    MessageBox.Show("En annan sal med det namnet finns redan", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxSalNamn.Text.Contains(',') || tbxSalNamn.Text.Contains(';') || tbxSalNamn.Text.Contains('.'))
                {
                    MessageBox.Show("Namnet kan inte innehålla , eller ; eller .", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tbxÖvrigt.Text.Contains(',') || tbxÖvrigt.Text.Contains(';') || tbxÖvrigt.Text.Contains('.'))
                {
                    MessageBox.Show("Övrigt kan inte innehålla , eller ; eller .", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }


        private void tbxSalNamn_TextChanged(object sender, EventArgs e)
        {
            if (tbxSalNamn.Text == "")
            {
                btnOK.Enabled = false;
            }
            else
            {
                btnOK.Enabled = true;
            }
        }
    }
}

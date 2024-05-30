using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schema_PROJEKT
{
    public partial class frmLäggTillSal : Form
    {
        public frmLäggTillSal(List<clsSal> salLista)
        {
            InitializeComponent();

            this.salLista = salLista;
        }

        List<clsSal> salLista;

        public string SalNamn
        {
            get
            {
                return tbxSalNamn.Text;
            }
        }
        public int Platser
        {
            get
            {
                return (int)nudPlatser.Value;
            }
        }
        public string Övrigt
        {
            get
            {
                return tbxÖvrigt.Text;
            }
        }

        private void tbxNySal_TextChanged(object sender, EventArgs e)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (clsSal sal in salLista) //Kollar om salen redan finns i listan
            {
                if (sal.Namn == tbxSalNamn.Text)
                {
                    MessageBox.Show("En sal med det namnet finns redan", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}

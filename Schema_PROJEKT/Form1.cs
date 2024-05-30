using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Schema_PROJEKT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Ladda data
            StreamReader sr = new StreamReader("C:\\Programfiler\\schema.txt");

            string rad = sr.ReadLine();
            while (rad != null)
            {
                //Laddar sal
                salLista.Add(new clsSal(rad.Split(',')[0], int.Parse(rad.Split(',')[1]), rad.Split(';')[0].Split(',')[2]));

                //F�r varje dag
                foreach (string sDag in rad.Split(";").TakeLast(rad.Split(";").Count() - 1))
                {
                    //L�gger till dagLista
                    salLista.Last().DagLista[DateOnly.Parse(sDag.Split('.')[0])] = new List<clsPass>();

                    //F�r varje pass
                    foreach (string sPass in sDag.Split('.').TakeLast(sDag.Split('.').Count() - 1))
                    {
                        //L�gger till passet
                        salLista.Last().DagLista[DateOnly.Parse(sDag.Split('.')[0])].Add(
                            new clsPass(TimeOnly.Parse(sPass.Split(',')[0]), TimeOnly.Parse(sPass.Split(',')[1]), sPass.Split(',')[2], sPass.Split(',')[3]));
                    }
                }

                rad = sr.ReadLine(); 
            }
            sr.Close();
            UppdateraBox();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Pen penna = new Pen(Color.Black, 2);
            SolidBrush bakgrundPensel = new SolidBrush(Color.DarkGray);
            SolidBrush passPensel = new SolidBrush(Color.LightBlue);
            SolidBrush valdPensel = new SolidBrush(Color.Blue);

            Graphics g = e.Graphics;

            g.FillRectangle(bakgrundPensel, schemaVy);
            g.DrawRectangle(penna, schemaVy);

            //Rita timlinjer
            if (cbxV�ljSal.SelectedIndex != -1 && salLista[cbxV�ljSal.SelectedIndex]
                .DagLista.Keys.Contains(DateOnly.FromDateTime(dtpDatum.Value)))
            {

                if (antalTimmar > 0)
                {
                    for (int i = 0; i <= antalTimmar; i++)
                    {
                        g.DrawLine(penna, schemaVy.X - 10, schemaVy.Y + i * (schemaVy.Height / antalTimmar), schemaVy.X, schemaVy.Y + i * (schemaVy.Height / antalTimmar));
                    }

                    //Rita pass
                    int j = 0;
                    foreach (clsPass pass in salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)])
                    {
                        Rectangle passVy = new Rectangle(schemaVy.X,
                            (int)Math.Ceiling(Minuter(pass.Starttid.AddHours(-tidigasteTimmen)) / (double)(antalTimmar * 60) * schemaVy.Height) + schemaVy.Y, schemaVy.Width,
                            (int)Math.Ceiling((pass.Sluttid - pass.Starttid).TotalMinutes * ((double)schemaVy.Height / (antalTimmar * 60))));

                        if (j != passIndex)
                        {
                            g.FillRectangle(passPensel, passVy);
                        }
                        else
                        {
                            g.FillRectangle(valdPensel, passVy);
                        }
                        g.DrawRectangle(penna, passVy);

                        j++;
                    }
                }
            }
        }

        private Rectangle schemaVy = new Rectangle(570, 35, 180, 390);

        int tidigasteTimmen = 24;
        int senasteTimmen = 0;
        int antalTimmar;
        List<Label> schemaInfo = new List<Label>();

        private List<clsSal> salLista = new List<clsSal>();
        private int passIndex = 0;

        private void btnL�ggTillSal_Click(object sender, EventArgs e)
        {
            frmL�ggTillSal frmNySal = new frmL�ggTillSal(salLista);
            if (frmNySal.ShowDialog() == DialogResult.OK) //L�gger till sal
            {
                salLista.Add(new clsSal(frmNySal.SalNamn, frmNySal.Platser, frmNySal.�vrigt));
                salLista.Sort((x, y) => x.Namn.CompareTo(y.Namn));
                UppdateraBox();
            }
            frmNySal.Dispose();

            
        }
        private void btnRedigeraSal_Click(object sender, EventArgs e)
        {
            frmRedigeraSal frmRedigeraSal = new frmRedigeraSal(salLista, cbxV�ljSal.SelectedIndex);
            DialogResult svar = frmRedigeraSal.ShowDialog();
            switch (svar)
            {
                case DialogResult.No:
                    for (int i = 0; i < salLista.Count; i++) //Tar bort salen fr�n salLista
                    {
                        if (salLista[i].Namn == (string)cbxV�ljSal.SelectedItem)
                        {
                            salLista.RemoveAt(i);
                            break;
                        }
                    }
                    UppdateraBox();

                    break;

                case DialogResult.OK:
                    salLista[cbxV�ljSal.SelectedIndex].Namn = frmRedigeraSal.SalNamn;
                    salLista[cbxV�ljSal.SelectedIndex].Platser = frmRedigeraSal.AntalPlatser;
                    salLista[cbxV�ljSal.SelectedIndex].�vrigt = frmRedigeraSal.�vrigt;

                    salLista.Sort((x, y) => x.Namn.CompareTo(y.Namn));

                    UppdateraBox(); //Om infon �ndrades ska den visade uppdateras

                    cbxV�ljSal.SelectedItem = frmRedigeraSal.SalNamn;

                    UppdateraSalinfo();

                    break;

                case DialogResult.Cancel:
                    break;
            }
            frmRedigeraSal.Dispose();
        }

        private void cbxV�ljSal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UppdateraSalinfo();

            passIndex = 0;
            UppdateraSchema();
        }
        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            passIndex = 0;
            UppdateraSchema();
        }

        private void btnL�ggTillPass_Click(object sender, EventArgs e)
        {
            TimeOnly valdStarttid;
            //Om salen inte har n�gon passlista skapas en 
            if (!salLista[cbxV�ljSal.SelectedIndex]
                .DagLista.Keys.Contains(DateOnly.FromDateTime(dtpDatum.Value)))
            {
                salLista[cbxV�ljSal.SelectedIndex]
                    .DagLista[DateOnly.FromDateTime(dtpDatum.Value)] = new List<clsPass>();
            }
            else //Annars finns pass och starttiden sparas f�r att kunna �ndra passIndex senare
            {
                valdStarttid = salLista[cbxV�ljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex].Starttid;
            }

            frmL�ggTillPass frmL�ggTillPass = new frmL�ggTillPass(salLista[cbxV�ljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)]);
            if (frmL�ggTillPass.ShowDialog() == DialogResult.OK)
            {
                salLista[cbxV�ljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Add(
                    new clsPass(frmL�ggTillPass.Starttid, frmL�ggTillPass.Sluttid, frmL�ggTillPass.Namn, frmL�ggTillPass.�vrigt));

                salLista[cbxV�ljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)]
                    .Sort((x, y) => x.Starttid.CompareTo(y.Starttid));

                //V�lj r�tt pass efter att indexet �ndrats
                int i = 0;
                foreach (clsPass pass in salLista[cbxV�ljSal.SelectedIndex]
                    .DagLista[DateOnly.FromDateTime(dtpDatum.Value)])
                {
                    if (pass.Starttid == valdStarttid)
                    {
                        passIndex = i;
                    }
                    i++;
                }
                UppdateraSchema();
            }
            else
            {
                salLista[cbxV�ljSal.SelectedIndex]
                   .DagLista.Remove(DateOnly.FromDateTime(dtpDatum.Value));
            }
            frmL�ggTillPass.Dispose();
        }
        private void btnRedigeraPass_Click(object sender, EventArgs e)
        {
            frmRedigeraPass frmRedigeraPass = new frmRedigeraPass(salLista[cbxV�ljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)], passIndex);
            DialogResult svar = frmRedigeraPass.ShowDialog();
            switch (svar)
            {
                case DialogResult.OK:
                    salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .Starttid = frmRedigeraPass.Starttid;
                    salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .Sluttid = frmRedigeraPass.Sluttid;
                    salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .Namn = frmRedigeraPass.Namn;
                    salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .�vrigt = frmRedigeraPass.�vrigt;

                    salLista[cbxV�ljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)]
                    .Sort((x, y) => x.Starttid.CompareTo(y.Starttid));

                    //V�lj r�tt pass efter redigering
                    int i = 0;
                    foreach (clsPass pass in salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)])
                    {
                        if (pass.Starttid == frmRedigeraPass.Starttid)
                        {
                            passIndex = i;
                            break;
                        }
                        i++;
                    }

                    UppdateraSchema();
                    break;

                case DialogResult.Cancel:
                    break;

                case DialogResult.No:
                    salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)]
                        .RemoveAt(passIndex);

                    passIndex = 0;
                    UppdateraSchema();

                    break;
            }
            frmRedigeraPass.Dispose();
        }


        private void UppdateraBox()
        {
            string valdSal = (string)cbxV�ljSal.SelectedItem;

            cbxV�ljSal.Items.Clear();
            foreach (clsSal sal in salLista)
            {
                cbxV�ljSal.Items.Add(sal.Namn);
            }

            if (cbxV�ljSal.Items.Contains(valdSal))
            {
                cbxV�ljSal.SelectedItem = valdSal;
            }
            else if (cbxV�ljSal.Items.Count > 0)
            {
                cbxV�ljSal.SelectedIndex = 0;
                btnRedigeraSal.Enabled = true;
                btnL�ggTillPass.Enabled = true;

                UppdateraSalinfo();
                UppdateraSchema();
            }
            else
            {
                tbxPlatser.Text = "";
                tbx�vrigt.Text = "";

                btnRedigeraSal.Enabled = false;
                btnL�ggTillPass.Enabled = false;

                UppdateraSchema();
            }
        }
        private void UppdateraSalinfo()
        {
            tbxPlatser.Text = salLista[cbxV�ljSal.SelectedIndex].Platser.ToString();

            tbx�vrigt.Text = salLista[cbxV�ljSal.SelectedIndex].�vrigt;
        }

        private void UppdateraSchema()
        {
            //Tar bort gammal info
            for (int i = schemaInfo.Count - 1; i >= 0; i--)
            {
                Controls.Remove(schemaInfo[i]);
                schemaInfo.RemoveAt(i);
            }

            //Tar bort gammalt valt info
            tbxStarttid.Text = "";
            tbxSluttid.Text = "";
            tbxNamnPass.Text = "";
            tbx�vrigtPass.Text = "";

            antalTimmar = -24;
            if (cbxV�ljSal.SelectedIndex != -1)
            {
                if (salLista[cbxV�ljSal.SelectedIndex]
                    .DagLista.ContainsKey(DateOnly.FromDateTime(dtpDatum.Value)))
                {
                    tidigasteTimmen = 24;
                    senasteTimmen = 0;
                    foreach (clsPass pass in salLista[cbxV�ljSal.SelectedIndex]
                    .DagLista[DateOnly.FromDateTime(dtpDatum.Value)])
                    {
                        if (tidigasteTimmen > pass.Starttid.Hour)
                        {
                            tidigasteTimmen = pass.Starttid.Hour;
                        }
                        if (senasteTimmen < pass.Sluttid.Hour + 1)
                        {
                            senasteTimmen = pass.Sluttid.Hour + 1;
                        }
                    }
                    antalTimmar = senasteTimmen - tidigasteTimmen;

                    //Skriver ut info p� schemat
                    foreach (clsPass pass in salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)])
                    {
                        int h�jd = (int)Math.Ceiling((pass.Sluttid - pass.Starttid).TotalMinutes * ((double)schemaVy.Height / (antalTimmar * 60)));
                        if (h�jd > 30)
                        {
                            int mittX = schemaVy.X + schemaVy.Width / 2;
                            int mittY = (int)Math.Ceiling(Minuter(pass.Starttid.AddHours(-tidigasteTimmen)) / (double)(antalTimmar * 60) * schemaVy.Height) + schemaVy.Y
                                + h�jd / 2;


                            schemaInfo.Add(new Label());
                            schemaInfo.Last().Text = pass.Starttid.ToString() + " - " + pass.Sluttid.ToString();
                            schemaInfo.Last().Location = new Point(mittX - schemaInfo.Last().Size.Width / 2,
                                mittY - schemaInfo.Last().Height);
                            Controls.Add(schemaInfo.Last());

                            schemaInfo.Add(new Label());
                            schemaInfo.Last().Text = pass.Namn;
                            schemaInfo.Last().Location = new Point(mittX - schemaInfo.Last().Size.Width / 2,
                                mittY);
                            Controls.Add(schemaInfo.Last());
                        }
                    }

                    //Skriver valda passets info
                    if (salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Count > 0)
                    {
                        clsPass valtPass = salLista[cbxV�ljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex];
                        tbxStarttid.Text = valtPass.Starttid.ToString();
                        tbxSluttid.Text = valtPass.Sluttid.ToString();
                        tbxNamnPass.Text = valtPass.Namn;
                        tbx�vrigtPass.Text = valtPass.�vrigt;
                    }
                }
            }

            KollaSchemaKnappar();

            Invalidate();
        }

        private void btnUpp_Click(object sender, EventArgs e)
        {
            passIndex--;
            UppdateraSchema();
        }
        private void btnNed_Click(object sender, EventArgs e)
        {
            passIndex++;
            UppdateraSchema();
        }

        private void KollaSchemaKnappar()
        {
            btnRedigeraPass.Enabled = false;
            btnUpp.Enabled = false;
            btnNed.Enabled = false;

            if (cbxV�ljSal.SelectedIndex != -1 &&
                salLista[cbxV�ljSal.SelectedIndex].DagLista.ContainsKey(DateOnly.FromDateTime(dtpDatum.Value))
                && salLista[cbxV�ljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Count > 0)
            {
                btnRedigeraPass.Enabled = true;

                //Kolla f�r pilknapparna
                if (passIndex != 0)
                {
                    btnUpp.Enabled = true;
                }
                if (passIndex != salLista[cbxV�ljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Count - 1)
                {
                    btnNed.Enabled = true;
                }
            }
        }


        private int Minuter(TimeOnly tid)
        {
            return tid.Hour * 60 + tid.Minute;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Spara data
            StreamWriter sw = new StreamWriter("C:\\Programfiler\\schema.txt");
            

            foreach (clsSal sal in salLista)
            {
                //Sparar sal
                sw.Write(sal.Namn + ",");
                sw.Write(sal.Platser + ",");
                sw.Write(sal.�vrigt);

                foreach (DateOnly dag in sal.DagLista.Keys)
                {
                    //Sparar dag
                    sw.Write(";" + dag);

                    foreach (clsPass pass in sal.DagLista[dag])
                    {
                        //Sparar pass
                        sw.Write("." + pass.Starttid + ",");
                        sw.Write(pass.Sluttid + ",");
                        sw.Write(pass.Namn + ",");
                        sw.Write(pass.�vrigt);
                    }
                }

                sw.WriteLine();
            }

            sw.Close();
        }
    }
}
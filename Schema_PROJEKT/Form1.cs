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

                //För varje dag
                foreach (string sDag in rad.Split(";").TakeLast(rad.Split(";").Count() - 1))
                {
                    //Lägger till dagLista
                    salLista.Last().DagLista[DateOnly.Parse(sDag.Split('.')[0])] = new List<clsPass>();

                    //För varje pass
                    foreach (string sPass in sDag.Split('.').TakeLast(sDag.Split('.').Count() - 1))
                    {
                        //Lägger till passet
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
            if (cbxVäljSal.SelectedIndex != -1 && salLista[cbxVäljSal.SelectedIndex]
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
                    foreach (clsPass pass in salLista[cbxVäljSal.SelectedIndex]
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

        private void btnLäggTillSal_Click(object sender, EventArgs e)
        {
            frmLäggTillSal frmNySal = new frmLäggTillSal(salLista);
            if (frmNySal.ShowDialog() == DialogResult.OK) //Lägger till sal
            {
                salLista.Add(new clsSal(frmNySal.SalNamn, frmNySal.Platser, frmNySal.Övrigt));
                salLista.Sort((x, y) => x.Namn.CompareTo(y.Namn));
                UppdateraBox();
            }
            frmNySal.Dispose();

            
        }
        private void btnRedigeraSal_Click(object sender, EventArgs e)
        {
            frmRedigeraSal frmRedigeraSal = new frmRedigeraSal(salLista, cbxVäljSal.SelectedIndex);
            DialogResult svar = frmRedigeraSal.ShowDialog();
            switch (svar)
            {
                case DialogResult.No:
                    for (int i = 0; i < salLista.Count; i++) //Tar bort salen från salLista
                    {
                        if (salLista[i].Namn == (string)cbxVäljSal.SelectedItem)
                        {
                            salLista.RemoveAt(i);
                            break;
                        }
                    }
                    UppdateraBox();

                    break;

                case DialogResult.OK:
                    salLista[cbxVäljSal.SelectedIndex].Namn = frmRedigeraSal.SalNamn;
                    salLista[cbxVäljSal.SelectedIndex].Platser = frmRedigeraSal.AntalPlatser;
                    salLista[cbxVäljSal.SelectedIndex].Övrigt = frmRedigeraSal.Övrigt;

                    salLista.Sort((x, y) => x.Namn.CompareTo(y.Namn));

                    UppdateraBox(); //Om infon ändrades ska den visade uppdateras

                    cbxVäljSal.SelectedItem = frmRedigeraSal.SalNamn;

                    UppdateraSalinfo();

                    break;

                case DialogResult.Cancel:
                    break;
            }
            frmRedigeraSal.Dispose();
        }

        private void cbxVäljSal_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void btnLäggTillPass_Click(object sender, EventArgs e)
        {
            TimeOnly valdStarttid;
            //Om salen inte har någon passlista skapas en 
            if (!salLista[cbxVäljSal.SelectedIndex]
                .DagLista.Keys.Contains(DateOnly.FromDateTime(dtpDatum.Value)))
            {
                salLista[cbxVäljSal.SelectedIndex]
                    .DagLista[DateOnly.FromDateTime(dtpDatum.Value)] = new List<clsPass>();
            }
            else //Annars finns pass och starttiden sparas för att kunna ändra passIndex senare
            {
                valdStarttid = salLista[cbxVäljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex].Starttid;
            }

            frmLäggTillPass frmLäggTillPass = new frmLäggTillPass(salLista[cbxVäljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)]);
            if (frmLäggTillPass.ShowDialog() == DialogResult.OK)
            {
                salLista[cbxVäljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Add(
                    new clsPass(frmLäggTillPass.Starttid, frmLäggTillPass.Sluttid, frmLäggTillPass.Namn, frmLäggTillPass.Övrigt));

                salLista[cbxVäljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)]
                    .Sort((x, y) => x.Starttid.CompareTo(y.Starttid));

                //Välj rätt pass efter att indexet ändrats
                int i = 0;
                foreach (clsPass pass in salLista[cbxVäljSal.SelectedIndex]
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
                salLista[cbxVäljSal.SelectedIndex]
                   .DagLista.Remove(DateOnly.FromDateTime(dtpDatum.Value));
            }
            frmLäggTillPass.Dispose();
        }
        private void btnRedigeraPass_Click(object sender, EventArgs e)
        {
            frmRedigeraPass frmRedigeraPass = new frmRedigeraPass(salLista[cbxVäljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)], passIndex);
            DialogResult svar = frmRedigeraPass.ShowDialog();
            switch (svar)
            {
                case DialogResult.OK:
                    salLista[cbxVäljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .Starttid = frmRedigeraPass.Starttid;
                    salLista[cbxVäljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .Sluttid = frmRedigeraPass.Sluttid;
                    salLista[cbxVäljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .Namn = frmRedigeraPass.Namn;
                    salLista[cbxVäljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex]
                        .Övrigt = frmRedigeraPass.Övrigt;

                    salLista[cbxVäljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)]
                    .Sort((x, y) => x.Starttid.CompareTo(y.Starttid));

                    //Välj rätt pass efter redigering
                    int i = 0;
                    foreach (clsPass pass in salLista[cbxVäljSal.SelectedIndex]
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
                    salLista[cbxVäljSal.SelectedIndex]
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
            string valdSal = (string)cbxVäljSal.SelectedItem;

            cbxVäljSal.Items.Clear();
            foreach (clsSal sal in salLista)
            {
                cbxVäljSal.Items.Add(sal.Namn);
            }

            if (cbxVäljSal.Items.Contains(valdSal))
            {
                cbxVäljSal.SelectedItem = valdSal;
            }
            else if (cbxVäljSal.Items.Count > 0)
            {
                cbxVäljSal.SelectedIndex = 0;
                btnRedigeraSal.Enabled = true;
                btnLäggTillPass.Enabled = true;

                UppdateraSalinfo();
                UppdateraSchema();
            }
            else
            {
                tbxPlatser.Text = "";
                tbxÖvrigt.Text = "";

                btnRedigeraSal.Enabled = false;
                btnLäggTillPass.Enabled = false;

                UppdateraSchema();
            }
        }
        private void UppdateraSalinfo()
        {
            tbxPlatser.Text = salLista[cbxVäljSal.SelectedIndex].Platser.ToString();

            tbxÖvrigt.Text = salLista[cbxVäljSal.SelectedIndex].Övrigt;
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
            tbxÖvrigtPass.Text = "";

            antalTimmar = -24;
            if (cbxVäljSal.SelectedIndex != -1)
            {
                if (salLista[cbxVäljSal.SelectedIndex]
                    .DagLista.ContainsKey(DateOnly.FromDateTime(dtpDatum.Value)))
                {
                    tidigasteTimmen = 24;
                    senasteTimmen = 0;
                    foreach (clsPass pass in salLista[cbxVäljSal.SelectedIndex]
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

                    //Skriver ut info på schemat
                    foreach (clsPass pass in salLista[cbxVäljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)])
                    {
                        int höjd = (int)Math.Ceiling((pass.Sluttid - pass.Starttid).TotalMinutes * ((double)schemaVy.Height / (antalTimmar * 60)));
                        if (höjd > 30)
                        {
                            int mittX = schemaVy.X + schemaVy.Width / 2;
                            int mittY = (int)Math.Ceiling(Minuter(pass.Starttid.AddHours(-tidigasteTimmen)) / (double)(antalTimmar * 60) * schemaVy.Height) + schemaVy.Y
                                + höjd / 2;


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
                    if (salLista[cbxVäljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Count > 0)
                    {
                        clsPass valtPass = salLista[cbxVäljSal.SelectedIndex]
                        .DagLista[DateOnly.FromDateTime(dtpDatum.Value)][passIndex];
                        tbxStarttid.Text = valtPass.Starttid.ToString();
                        tbxSluttid.Text = valtPass.Sluttid.ToString();
                        tbxNamnPass.Text = valtPass.Namn;
                        tbxÖvrigtPass.Text = valtPass.Övrigt;
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

            if (cbxVäljSal.SelectedIndex != -1 &&
                salLista[cbxVäljSal.SelectedIndex].DagLista.ContainsKey(DateOnly.FromDateTime(dtpDatum.Value))
                && salLista[cbxVäljSal.SelectedIndex]
                .DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Count > 0)
            {
                btnRedigeraPass.Enabled = true;

                //Kolla för pilknapparna
                if (passIndex != 0)
                {
                    btnUpp.Enabled = true;
                }
                if (passIndex != salLista[cbxVäljSal.SelectedIndex].DagLista[DateOnly.FromDateTime(dtpDatum.Value)].Count - 1)
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
                sw.Write(sal.Övrigt);

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
                        sw.Write(pass.Övrigt);
                    }
                }

                sw.WriteLine();
            }

            sw.Close();
        }
    }
}
namespace Schema_PROJEKT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLäggTillSal = new Button();
            lblVäljSal = new Label();
            cbxVäljSal = new ComboBox();
            btnRedigeraSal = new Button();
            dtpDatum = new DateTimePicker();
            lblVäljDag = new Label();
            lblAntalPlatser = new Label();
            tbxPlatser = new TextBox();
            lblÖvrigt = new Label();
            tbxÖvrigt = new TextBox();
            btnLäggTillPass = new Button();
            btnRedigeraPass = new Button();
            tbxSluttid = new TextBox();
            tbxStarttid = new TextBox();
            lblStarttid = new Label();
            lblSluttid = new Label();
            lblNamn = new Label();
            tbxNamnPass = new TextBox();
            tbxÖvrigtPass = new TextBox();
            label1 = new Label();
            btnUpp = new Button();
            btnNed = new Button();
            SuspendLayout();
            // 
            // btnLäggTillSal
            // 
            btnLäggTillSal.Location = new Point(30, 82);
            btnLäggTillSal.Name = "btnLäggTillSal";
            btnLäggTillSal.Size = new Size(82, 23);
            btnLäggTillSal.TabIndex = 0;
            btnLäggTillSal.Text = "Lägg till sal";
            btnLäggTillSal.UseVisualStyleBackColor = true;
            btnLäggTillSal.Click += btnLäggTillSal_Click;
            // 
            // lblVäljSal
            // 
            lblVäljSal.AutoSize = true;
            lblVäljSal.Location = new Point(30, 35);
            lblVäljSal.Name = "lblVäljSal";
            lblVäljSal.Size = new Size(45, 15);
            lblVäljSal.TabIndex = 1;
            lblVäljSal.Text = "Välj sal:";
            // 
            // cbxVäljSal
            // 
            cbxVäljSal.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxVäljSal.FormattingEnabled = true;
            cbxVäljSal.Location = new Point(30, 53);
            cbxVäljSal.Name = "cbxVäljSal";
            cbxVäljSal.Size = new Size(121, 23);
            cbxVäljSal.Sorted = true;
            cbxVäljSal.TabIndex = 3;
            cbxVäljSal.SelectionChangeCommitted += cbxVäljSal_SelectionChangeCommitted;
            // 
            // btnRedigeraSal
            // 
            btnRedigeraSal.Enabled = false;
            btnRedigeraSal.Location = new Point(30, 273);
            btnRedigeraSal.Name = "btnRedigeraSal";
            btnRedigeraSal.Size = new Size(82, 23);
            btnRedigeraSal.TabIndex = 4;
            btnRedigeraSal.Text = "Redigera sal";
            btnRedigeraSal.UseVisualStyleBackColor = true;
            btnRedigeraSal.Click += btnRedigeraSal_Click;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(187, 53);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(175, 23);
            dtpDatum.TabIndex = 5;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // lblVäljDag
            // 
            lblVäljDag.AutoSize = true;
            lblVäljDag.Location = new Point(187, 35);
            lblVäljDag.Name = "lblVäljDag";
            lblVäljDag.Size = new Size(66, 15);
            lblVäljDag.TabIndex = 6;
            lblVäljDag.Text = "Välj datum:";
            // 
            // lblAntalPlatser
            // 
            lblAntalPlatser.AutoSize = true;
            lblAntalPlatser.Location = new Point(30, 122);
            lblAntalPlatser.Name = "lblAntalPlatser";
            lblAntalPlatser.Size = new Size(76, 15);
            lblAntalPlatser.TabIndex = 7;
            lblAntalPlatser.Text = "Antal platser:";
            // 
            // tbxPlatser
            // 
            tbxPlatser.Location = new Point(30, 140);
            tbxPlatser.Name = "tbxPlatser";
            tbxPlatser.ReadOnly = true;
            tbxPlatser.Size = new Size(100, 23);
            tbxPlatser.TabIndex = 8;
            // 
            // lblÖvrigt
            // 
            lblÖvrigt.AutoSize = true;
            lblÖvrigt.Location = new Point(30, 181);
            lblÖvrigt.Name = "lblÖvrigt";
            lblÖvrigt.Size = new Size(43, 15);
            lblÖvrigt.TabIndex = 9;
            lblÖvrigt.Text = "Övrigt:";
            // 
            // tbxÖvrigt
            // 
            tbxÖvrigt.Location = new Point(30, 199);
            tbxÖvrigt.Multiline = true;
            tbxÖvrigt.Name = "tbxÖvrigt";
            tbxÖvrigt.ReadOnly = true;
            tbxÖvrigt.Size = new Size(121, 59);
            tbxÖvrigt.TabIndex = 10;
            // 
            // btnLäggTillPass
            // 
            btnLäggTillPass.Enabled = false;
            btnLäggTillPass.Location = new Point(187, 82);
            btnLäggTillPass.Name = "btnLäggTillPass";
            btnLäggTillPass.Size = new Size(90, 23);
            btnLäggTillPass.TabIndex = 11;
            btnLäggTillPass.Text = "Lägg till pass";
            btnLäggTillPass.UseVisualStyleBackColor = true;
            btnLäggTillPass.Click += btnLäggTillPass_Click;
            // 
            // btnRedigeraPass
            // 
            btnRedigeraPass.Enabled = false;
            btnRedigeraPass.Location = new Point(463, 387);
            btnRedigeraPass.Name = "btnRedigeraPass";
            btnRedigeraPass.Size = new Size(87, 23);
            btnRedigeraPass.TabIndex = 12;
            btnRedigeraPass.Text = "Redigera pass";
            btnRedigeraPass.UseVisualStyleBackColor = true;
            btnRedigeraPass.Click += btnRedigeraPass_Click;
            // 
            // tbxSluttid
            // 
            tbxSluttid.Location = new Point(489, 140);
            tbxSluttid.Name = "tbxSluttid";
            tbxSluttid.ReadOnly = true;
            tbxSluttid.Size = new Size(61, 23);
            tbxSluttid.TabIndex = 13;
            // 
            // tbxStarttid
            // 
            tbxStarttid.Location = new Point(397, 140);
            tbxStarttid.Name = "tbxStarttid";
            tbxStarttid.ReadOnly = true;
            tbxStarttid.Size = new Size(61, 23);
            tbxStarttid.TabIndex = 14;
            // 
            // lblStarttid
            // 
            lblStarttid.AutoSize = true;
            lblStarttid.Location = new Point(397, 122);
            lblStarttid.Name = "lblStarttid";
            lblStarttid.Size = new Size(48, 15);
            lblStarttid.TabIndex = 15;
            lblStarttid.Text = "Starttid:";
            // 
            // lblSluttid
            // 
            lblSluttid.AutoSize = true;
            lblSluttid.Location = new Point(489, 122);
            lblSluttid.Name = "lblSluttid";
            lblSluttid.Size = new Size(44, 15);
            lblSluttid.TabIndex = 16;
            lblSluttid.Text = "Sluttid:";
            // 
            // lblNamn
            // 
            lblNamn.AutoSize = true;
            lblNamn.Location = new Point(450, 181);
            lblNamn.Name = "lblNamn";
            lblNamn.Size = new Size(43, 15);
            lblNamn.TabIndex = 17;
            lblNamn.Text = "Namn:";
            // 
            // tbxNamnPass
            // 
            tbxNamnPass.Location = new Point(450, 199);
            tbxNamnPass.Name = "tbxNamnPass";
            tbxNamnPass.ReadOnly = true;
            tbxNamnPass.Size = new Size(100, 23);
            tbxNamnPass.TabIndex = 18;
            // 
            // tbxÖvrigtPass
            // 
            tbxÖvrigtPass.Location = new Point(429, 252);
            tbxÖvrigtPass.Multiline = true;
            tbxÖvrigtPass.Name = "tbxÖvrigtPass";
            tbxÖvrigtPass.ReadOnly = true;
            tbxÖvrigtPass.Size = new Size(121, 59);
            tbxÖvrigtPass.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(429, 234);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 19;
            label1.Text = "Övrigt:";
            // 
            // btnUpp
            // 
            btnUpp.Enabled = false;
            btnUpp.Location = new Point(489, 317);
            btnUpp.Name = "btnUpp";
            btnUpp.Size = new Size(61, 23);
            btnUpp.TabIndex = 21;
            btnUpp.Text = "↑";
            btnUpp.UseVisualStyleBackColor = true;
            btnUpp.Click += btnUpp_Click;
            // 
            // btnNed
            // 
            btnNed.Enabled = false;
            btnNed.Location = new Point(489, 346);
            btnNed.Name = "btnNed";
            btnNed.Size = new Size(61, 23);
            btnNed.TabIndex = 22;
            btnNed.Text = "↓";
            btnNed.UseVisualStyleBackColor = true;
            btnNed.Click += btnNed_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(btnNed);
            Controls.Add(btnUpp);
            Controls.Add(tbxÖvrigtPass);
            Controls.Add(label1);
            Controls.Add(tbxNamnPass);
            Controls.Add(lblNamn);
            Controls.Add(lblSluttid);
            Controls.Add(lblStarttid);
            Controls.Add(tbxStarttid);
            Controls.Add(tbxSluttid);
            Controls.Add(btnRedigeraPass);
            Controls.Add(btnLäggTillPass);
            Controls.Add(tbxÖvrigt);
            Controls.Add(lblÖvrigt);
            Controls.Add(tbxPlatser);
            Controls.Add(lblAntalPlatser);
            Controls.Add(lblVäljDag);
            Controls.Add(dtpDatum);
            Controls.Add(btnRedigeraSal);
            Controls.Add(cbxVäljSal);
            Controls.Add(lblVäljSal);
            Controls.Add(btnLäggTillSal);
            Name = "Form1";
            Text = "Schema25";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLäggTillSal;
        private Label lblVäljSal;
        private ComboBox cbxVäljSal;
        private Button btnRedigeraSal;
        private DateTimePicker dtpDatum;
        private Label lblVäljDag;
        private Label lblAntalPlatser;
        private TextBox tbxPlatser;
        private Label lblÖvrigt;
        private TextBox tbxÖvrigt;
        private Button btnLäggTillPass;
        private Button btnRedigeraPass;
        private TextBox tbxSluttid;
        private TextBox tbxStarttid;
        private Label lblStarttid;
        private Label lblSluttid;
        private Label lblNamn;
        private TextBox tbxNamnPass;
        private TextBox tbxÖvrigtPass;
        private Label label1;
        private Button btnUpp;
        private Button btnNed;
    }
}
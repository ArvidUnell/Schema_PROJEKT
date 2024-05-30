namespace Schema_PROJEKT
{
    partial class frmLäggTillPass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtpStarttid = new DateTimePicker();
            label1 = new Label();
            dtpSluttid = new DateTimePicker();
            lblSluttid = new Label();
            lblNamn = new Label();
            tbxNamn = new TextBox();
            lblÖvrigt = new Label();
            tbxÖvrigt = new TextBox();
            btnOK = new Button();
            btnAvbryt = new Button();
            SuspendLayout();
            // 
            // dtpStarttid
            // 
            dtpStarttid.CustomFormat = "HH:mm";
            dtpStarttid.Format = DateTimePickerFormat.Custom;
            dtpStarttid.Location = new Point(12, 27);
            dtpStarttid.Name = "dtpStarttid";
            dtpStarttid.ShowUpDown = true;
            dtpStarttid.Size = new Size(85, 23);
            dtpStarttid.TabIndex = 0;
            dtpStarttid.ValueChanged += dtpStarttid_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Starttid:";
            // 
            // dtpSluttid
            // 
            dtpSluttid.CustomFormat = "HH:mm";
            dtpSluttid.Format = DateTimePickerFormat.Custom;
            dtpSluttid.Location = new Point(180, 27);
            dtpSluttid.Name = "dtpSluttid";
            dtpSluttid.ShowUpDown = true;
            dtpSluttid.Size = new Size(85, 23);
            dtpSluttid.TabIndex = 2;
            dtpSluttid.ValueChanged += dtpSluttid_ValueChanged;
            // 
            // lblSluttid
            // 
            lblSluttid.AutoSize = true;
            lblSluttid.Location = new Point(180, 9);
            lblSluttid.Name = "lblSluttid";
            lblSluttid.Size = new Size(44, 15);
            lblSluttid.TabIndex = 3;
            lblSluttid.Text = "Sluttid:";
            // 
            // lblNamn
            // 
            lblNamn.AutoSize = true;
            lblNamn.Location = new Point(12, 53);
            lblNamn.Name = "lblNamn";
            lblNamn.Size = new Size(43, 15);
            lblNamn.TabIndex = 4;
            lblNamn.Text = "Namn:";
            // 
            // tbxNamn
            // 
            tbxNamn.Location = new Point(12, 71);
            tbxNamn.Name = "tbxNamn";
            tbxNamn.Size = new Size(100, 23);
            tbxNamn.TabIndex = 5;
            tbxNamn.TextChanged += tbxNamn_TextChanged;
            // 
            // lblÖvrigt
            // 
            lblÖvrigt.AutoSize = true;
            lblÖvrigt.Location = new Point(137, 53);
            lblÖvrigt.Name = "lblÖvrigt";
            lblÖvrigt.Size = new Size(43, 15);
            lblÖvrigt.TabIndex = 6;
            lblÖvrigt.Text = "Övrigt:";
            // 
            // tbxÖvrigt
            // 
            tbxÖvrigt.Location = new Point(137, 71);
            tbxÖvrigt.Multiline = true;
            tbxÖvrigt.Name = "tbxÖvrigt";
            tbxÖvrigt.Size = new Size(128, 59);
            tbxÖvrigt.TabIndex = 7;
            // 
            // btnOK
            // 
            btnOK.Enabled = false;
            btnOK.Location = new Point(12, 136);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnAvbryt
            // 
            btnAvbryt.Location = new Point(190, 136);
            btnAvbryt.Name = "btnAvbryt";
            btnAvbryt.Size = new Size(75, 23);
            btnAvbryt.TabIndex = 9;
            btnAvbryt.Text = "Avbryt";
            btnAvbryt.UseVisualStyleBackColor = true;
            btnAvbryt.Click += btnAvbryt_Click;
            // 
            // frmLäggTillPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 171);
            Controls.Add(btnAvbryt);
            Controls.Add(btnOK);
            Controls.Add(tbxÖvrigt);
            Controls.Add(lblÖvrigt);
            Controls.Add(tbxNamn);
            Controls.Add(lblNamn);
            Controls.Add(lblSluttid);
            Controls.Add(dtpSluttid);
            Controls.Add(label1);
            Controls.Add(dtpStarttid);
            Name = "frmLäggTillPass";
            Text = "Lägg till pass";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpStarttid;
        private Label label1;
        private DateTimePicker dtpSluttid;
        private Label lblSluttid;
        private Label lblNamn;
        private TextBox tbxNamn;
        private Label lblÖvrigt;
        private TextBox tbxÖvrigt;
        private Button btnOK;
        private Button btnAvbryt;
    }
}
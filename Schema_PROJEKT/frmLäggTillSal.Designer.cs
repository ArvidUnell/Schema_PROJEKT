namespace Schema_PROJEKT
{
    partial class frmLäggTillSal
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
            tbxSalNamn = new TextBox();
            lblNySalNamn = new Label();
            btnOK = new Button();
            btnAvbryt = new Button();
            lblPlatser = new Label();
            nudPlatser = new NumericUpDown();
            lblÖvrigt = new Label();
            tbxÖvrigt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudPlatser).BeginInit();
            SuspendLayout();
            // 
            // tbxSalNamn
            // 
            tbxSalNamn.Location = new Point(12, 27);
            tbxSalNamn.Name = "tbxSalNamn";
            tbxSalNamn.Size = new Size(100, 23);
            tbxSalNamn.TabIndex = 0;
            tbxSalNamn.TextChanged += tbxNySal_TextChanged;
            // 
            // lblNySalNamn
            // 
            lblNySalNamn.AutoSize = true;
            lblNySalNamn.Location = new Point(12, 9);
            lblNySalNamn.Name = "lblNySalNamn";
            lblNySalNamn.Size = new Size(43, 15);
            lblNySalNamn.TabIndex = 1;
            lblNySalNamn.Text = "Namn:";
            // 
            // btnOK
            // 
            btnOK.Enabled = false;
            btnOK.Location = new Point(12, 136);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnAvbryt
            // 
            btnAvbryt.Location = new Point(190, 136);
            btnAvbryt.Name = "btnAvbryt";
            btnAvbryt.Size = new Size(75, 23);
            btnAvbryt.TabIndex = 3;
            btnAvbryt.Text = "Avbryt";
            btnAvbryt.UseVisualStyleBackColor = true;
            btnAvbryt.Click += btnAvbryt_Click;
            // 
            // lblPlatser
            // 
            lblPlatser.AutoSize = true;
            lblPlatser.Location = new Point(145, 9);
            lblPlatser.Name = "lblPlatser";
            lblPlatser.Size = new Size(76, 15);
            lblPlatser.TabIndex = 4;
            lblPlatser.Text = "Antal platser:";
            // 
            // nudPlatser
            // 
            nudPlatser.Location = new Point(145, 28);
            nudPlatser.Name = "nudPlatser";
            nudPlatser.Size = new Size(120, 23);
            nudPlatser.TabIndex = 5;
            // 
            // lblÖvrigt
            // 
            lblÖvrigt.AutoSize = true;
            lblÖvrigt.Location = new Point(12, 53);
            lblÖvrigt.Name = "lblÖvrigt";
            lblÖvrigt.Size = new Size(105, 15);
            lblÖvrigt.TabIndex = 6;
            lblÖvrigt.Text = "Övrig information:";
            // 
            // tbxÖvrigt
            // 
            tbxÖvrigt.Location = new Point(12, 71);
            tbxÖvrigt.Multiline = true;
            tbxÖvrigt.Name = "tbxÖvrigt";
            tbxÖvrigt.Size = new Size(253, 59);
            tbxÖvrigt.TabIndex = 7;
            // 
            // frmLäggTillSal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 171);
            Controls.Add(tbxÖvrigt);
            Controls.Add(lblÖvrigt);
            Controls.Add(nudPlatser);
            Controls.Add(lblPlatser);
            Controls.Add(btnAvbryt);
            Controls.Add(btnOK);
            Controls.Add(lblNySalNamn);
            Controls.Add(tbxSalNamn);
            Name = "frmLäggTillSal";
            Text = "Lägg till sal";
            ((System.ComponentModel.ISupportInitialize)nudPlatser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxSalNamn;
        private Label lblNySalNamn;
        private Button btnOK;
        private Button btnAvbryt;
        private Label lblPlatser;
        private NumericUpDown nudPlatser;
        private Label lblÖvrigt;
        private TextBox tbxÖvrigt;
    }
}
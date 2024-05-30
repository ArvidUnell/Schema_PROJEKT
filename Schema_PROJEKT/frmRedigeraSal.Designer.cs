namespace Schema_PROJEKT
{
    partial class frmRedigeraSal
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
            lblNySalNamn = new Label();
            tbxSalNamn = new TextBox();
            nudAntalPlatser = new NumericUpDown();
            lblPlatser = new Label();
            lblÖvrigt = new Label();
            tbxÖvrigt = new TextBox();
            btnOK = new Button();
            btnAvbryt = new Button();
            btnRaderaSal = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAntalPlatser).BeginInit();
            SuspendLayout();
            // 
            // lblNySalNamn
            // 
            lblNySalNamn.AutoSize = true;
            lblNySalNamn.Location = new Point(12, 9);
            lblNySalNamn.Name = "lblNySalNamn";
            lblNySalNamn.Size = new Size(43, 15);
            lblNySalNamn.TabIndex = 2;
            lblNySalNamn.Text = "Namn:";
            // 
            // tbxSalNamn
            // 
            tbxSalNamn.Location = new Point(12, 27);
            tbxSalNamn.Name = "tbxSalNamn";
            tbxSalNamn.Size = new Size(100, 23);
            tbxSalNamn.TabIndex = 3;
            tbxSalNamn.TextChanged += tbxSalNamn_TextChanged;
            // 
            // nudAntalPlatser
            // 
            nudAntalPlatser.Location = new Point(145, 28);
            nudAntalPlatser.Name = "nudAntalPlatser";
            nudAntalPlatser.Size = new Size(120, 23);
            nudAntalPlatser.TabIndex = 4;
            // 
            // lblPlatser
            // 
            lblPlatser.AutoSize = true;
            lblPlatser.Location = new Point(145, 9);
            lblPlatser.Name = "lblPlatser";
            lblPlatser.Size = new Size(76, 15);
            lblPlatser.TabIndex = 5;
            lblPlatser.Text = "Antal platser:";
            // 
            // lblÖvrigt
            // 
            lblÖvrigt.AutoSize = true;
            lblÖvrigt.Location = new Point(12, 53);
            lblÖvrigt.Name = "lblÖvrigt";
            lblÖvrigt.Size = new Size(105, 15);
            lblÖvrigt.TabIndex = 7;
            lblÖvrigt.Text = "Övrig information:";
            // 
            // tbxÖvrigt
            // 
            tbxÖvrigt.Location = new Point(12, 71);
            tbxÖvrigt.Multiline = true;
            tbxÖvrigt.Name = "tbxÖvrigt";
            tbxÖvrigt.Size = new Size(253, 59);
            tbxÖvrigt.TabIndex = 8;
            // 
            // btnOK
            // 
            btnOK.Enabled = false;
            btnOK.Location = new Point(12, 136);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 9;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnAvbryt
            // 
            btnAvbryt.Location = new Point(93, 136);
            btnAvbryt.Name = "btnAvbryt";
            btnAvbryt.Size = new Size(75, 23);
            btnAvbryt.TabIndex = 10;
            btnAvbryt.Text = "Avbryt";
            btnAvbryt.UseVisualStyleBackColor = true;
            btnAvbryt.Click += btnAvbryt_Click;
            // 
            // btnRaderaSal
            // 
            btnRaderaSal.Location = new Point(190, 136);
            btnRaderaSal.Name = "btnRaderaSal";
            btnRaderaSal.Size = new Size(75, 23);
            btnRaderaSal.TabIndex = 11;
            btnRaderaSal.Text = "Radera sal";
            btnRaderaSal.UseVisualStyleBackColor = true;
            btnRaderaSal.Click += btnRaderaSal_Click;
            // 
            // frmRedigeraSal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 171);
            Controls.Add(btnRaderaSal);
            Controls.Add(btnAvbryt);
            Controls.Add(btnOK);
            Controls.Add(tbxÖvrigt);
            Controls.Add(lblÖvrigt);
            Controls.Add(lblPlatser);
            Controls.Add(nudAntalPlatser);
            Controls.Add(tbxSalNamn);
            Controls.Add(lblNySalNamn);
            Name = "frmRedigeraSal";
            Text = "Redigera sal";
            ((System.ComponentModel.ISupportInitialize)nudAntalPlatser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNySalNamn;
        private TextBox tbxSalNamn;
        private NumericUpDown nudAntalPlatser;
        private Label lblPlatser;
        private Label lblÖvrigt;
        private TextBox tbxÖvrigt;
        private Button btnOK;
        private Button btnAvbryt;
        private Button btnRaderaSal;
    }
}
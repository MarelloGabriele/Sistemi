namespace LabGaraNuoto
{
    partial class FrmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.picBox = new System.Windows.Forms.PictureBox();
            this.txtA1 = new System.Windows.Forms.TextBox();
            this.txtA2 = new System.Windows.Forms.TextBox();
            this.txtA3 = new System.Windows.Forms.TextBox();
            this.txtA4 = new System.Windows.Forms.TextBox();
            this.lblAtleti = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEsito = new System.Windows.Forms.Label();
            this.lblEliminati = new System.Windows.Forms.Label();
            this.btnAvvia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Image = ((System.Drawing.Image)(resources.GetObject("picBox.Image")));
            this.picBox.Location = new System.Drawing.Point(14, 50);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(630, 630);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // txtA1
            // 
            this.txtA1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA1.Location = new System.Drawing.Point(39, 15);
            this.txtA1.Name = "txtA1";
            this.txtA1.ReadOnly = true;
            this.txtA1.Size = new System.Drawing.Size(115, 23);
            this.txtA1.TabIndex = 1;
            // 
            // txtA2
            // 
            this.txtA2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA2.Location = new System.Drawing.Point(190, 15);
            this.txtA2.Name = "txtA2";
            this.txtA2.ReadOnly = true;
            this.txtA2.Size = new System.Drawing.Size(115, 23);
            this.txtA2.TabIndex = 2;
            // 
            // txtA3
            // 
            this.txtA3.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA3.Location = new System.Drawing.Point(355, 15);
            this.txtA3.Name = "txtA3";
            this.txtA3.ReadOnly = true;
            this.txtA3.Size = new System.Drawing.Size(115, 23);
            this.txtA3.TabIndex = 3;
            // 
            // txtA4
            // 
            this.txtA4.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA4.Location = new System.Drawing.Point(510, 15);
            this.txtA4.Name = "txtA4";
            this.txtA4.ReadOnly = true;
            this.txtA4.Size = new System.Drawing.Size(115, 23);
            this.txtA4.TabIndex = 4;
            // 
            // lblAtleti
            // 
            this.lblAtleti.AutoSize = true;
            this.lblAtleti.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtleti.Location = new System.Drawing.Point(674, 20);
            this.lblAtleti.Name = "lblAtleti";
            this.lblAtleti.Size = new System.Drawing.Size(45, 16);
            this.lblAtleti.TabIndex = 5;
            this.lblAtleti.Text = "[Atleti]";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.Location = new System.Drawing.Point(674, 331);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(62, 16);
            this.lblTurno.TabIndex = 6;
            this.lblTurno.Text = "[lblTurno]";
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStato.Location = new System.Drawing.Point(674, 359);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(60, 16);
            this.lblStato.TabIndex = 7;
            this.lblStato.Text = "[lblStato]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEsito);
            this.groupBox1.Location = new System.Drawing.Point(650, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 290);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BATTERIA FINALISTI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEliminati);
            this.groupBox2.Location = new System.Drawing.Point(842, 390);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 290);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ELIMINATI";
            // 
            // lblEsito
            // 
            this.lblEsito.AutoSize = true;
            this.lblEsito.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsito.Location = new System.Drawing.Point(24, 30);
            this.lblEsito.Name = "lblEsito";
            this.lblEsito.Size = new System.Drawing.Size(59, 16);
            this.lblEsito.TabIndex = 10;
            this.lblEsito.Text = "[lblEsito]";
            // 
            // lblEliminati
            // 
            this.lblEliminati.AutoSize = true;
            this.lblEliminati.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEliminati.Location = new System.Drawing.Point(26, 30);
            this.lblEliminati.Name = "lblEliminati";
            this.lblEliminati.Size = new System.Drawing.Size(80, 16);
            this.lblEliminati.TabIndex = 8;
            this.lblEliminati.Text = "[lblEliminati]";
            // 
            // btnAvvia
            // 
            this.btnAvvia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvvia.Location = new System.Drawing.Point(970, 12);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(116, 46);
            this.btnAvvia.TabIndex = 10;
            this.btnAvvia.Text = "AVVIA";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 700);
            this.Controls.Add(this.btnAvvia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblAtleti);
            this.Controls.Add(this.txtA4);
            this.Controls.Add(this.txtA3);
            this.Controls.Add(this.txtA2);
            this.Controls.Add(this.txtA1);
            this.Controls.Add(this.picBox);
            this.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gara Nuoto";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.TextBox txtA1;
        private System.Windows.Forms.TextBox txtA2;
        private System.Windows.Forms.TextBox txtA3;
        private System.Windows.Forms.TextBox txtA4;
        private System.Windows.Forms.Label lblAtleti;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEsito;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblEliminati;
        private System.Windows.Forms.Button btnAvvia;
    }
}


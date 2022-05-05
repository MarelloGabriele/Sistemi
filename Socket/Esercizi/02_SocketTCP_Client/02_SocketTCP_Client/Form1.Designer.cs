namespace _02_SocketTCP_Client
{
    partial class Form1
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
            this.txtMsgRicevuti = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMsgInvio = new System.Windows.Forms.TextBox();
            this.btnInvia = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMsgRicevuti
            // 
            this.txtMsgRicevuti.Location = new System.Drawing.Point(51, 398);
            this.txtMsgRicevuti.Margin = new System.Windows.Forms.Padding(6);
            this.txtMsgRicevuti.Multiline = true;
            this.txtMsgRicevuti.Name = "txtMsgRicevuti";
            this.txtMsgRicevuti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgRicevuti.Size = new System.Drawing.Size(886, 617);
            this.txtMsgRicevuti.TabIndex = 9;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Enabled = false;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(955, 198);
            this.btnStop.Margin = new System.Windows.Forms.Padding(6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(382, 112);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "DISCONNETTITI";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStart.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnStart.Location = new System.Drawing.Point(955, 42);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(382, 112);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "CONNETTITI";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudServerPort);
            this.groupBox2.Location = new System.Drawing.Point(541, 40);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(400, 112);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PORT";
            // 
            // nudServerPort
            // 
            this.nudServerPort.Location = new System.Drawing.Point(14, 38);
            this.nudServerPort.Margin = new System.Windows.Forms.Padding(6);
            this.nudServerPort.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.nudServerPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudServerPort.Name = "nudServerPort";
            this.nudServerPort.Size = new System.Drawing.Size(374, 31);
            this.nudServerPort.TabIndex = 0;
            this.nudServerPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Location = new System.Drawing.Point(37, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(450, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInvia);
            this.groupBox3.Controls.Add(this.txtMsgInvio);
            this.groupBox3.Location = new System.Drawing.Point(37, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(892, 174);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MESSAGGIO DA INVIARE";
            // 
            // txtMsgInvio
            // 
            this.txtMsgInvio.Location = new System.Drawing.Point(14, 48);
            this.txtMsgInvio.Name = "txtMsgInvio";
            this.txtMsgInvio.Size = new System.Drawing.Size(854, 31);
            this.txtMsgInvio.TabIndex = 0;
            // 
            // btnInvia
            // 
            this.btnInvia.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnInvia.Location = new System.Drawing.Point(614, 104);
            this.btnInvia.Name = "btnInvia";
            this.btnInvia.Size = new System.Drawing.Size(254, 64);
            this.btnInvia.TabIndex = 1;
            this.btnInvia.Text = "INVIA";
            this.btnInvia.UseVisualStyleBackColor = false;
            this.btnInvia.Click += new System.EventHandler(this.btnInvia_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(9, 41);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(410, 31);
            this.txtServerIP.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1756, 1164);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtMsgRicevuti);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "SOCKET CLIENT TCP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMsgRicevuti;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudServerPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInvia;
        private System.Windows.Forms.TextBox txtMsgInvio;
        private System.Windows.Forms.TextBox txtServerIP;
    }
}


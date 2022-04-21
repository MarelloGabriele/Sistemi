namespace _01_SocketUDP_Client
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.btnAttivaDisattiva = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIPServer);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP SERVER";
            // 
            // txtIPServer
            // 
            this.txtIPServer.Location = new System.Drawing.Point(7, 30);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(172, 20);
            this.txtIPServer.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudServerPort);
            this.groupBox2.Location = new System.Drawing.Point(217, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PORT SERVER";
            // 
            // nudServerPort
            // 
            this.nudServerPort.Location = new System.Drawing.Point(7, 30);
            this.nudServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudServerPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudServerPort.Name = "nudServerPort";
            this.nudServerPort.Size = new System.Drawing.Size(120, 20);
            this.nudServerPort.TabIndex = 0;
            this.nudServerPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // btnAttivaDisattiva
            // 
            this.btnAttivaDisattiva.Location = new System.Drawing.Point(12, 83);
            this.btnAttivaDisattiva.Name = "btnAttivaDisattiva";
            this.btnAttivaDisattiva.Size = new System.Drawing.Size(151, 64);
            this.btnAttivaDisattiva.TabIndex = 2;
            this.btnAttivaDisattiva.Text = "ATTIVA CLIENT";
            this.btnAttivaDisattiva.UseVisualStyleBackColor = true;
            this.btnAttivaDisattiva.Click += new System.EventHandler(this.btnAttivaDisattiva_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 193);
            this.Controls.Add(this.btnAttivaDisattiva);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "CLIENT UDP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudServerPort;
        private System.Windows.Forms.Button btnAttivaDisattiva;
        private System.Windows.Forms.Timer timer1;
    }
}


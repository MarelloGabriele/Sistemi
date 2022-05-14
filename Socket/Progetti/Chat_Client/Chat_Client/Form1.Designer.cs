namespace Chat_Client
{
    partial class frmChat
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
            this.gbChat = new System.Windows.Forms.GroupBox();
            this.txtInviaMsg = new System.Windows.Forms.TextBox();
            this.btnInviaMsg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListaUtenti = new System.Windows.Forms.DataGridView();
            this.dgvChat = new System.Windows.Forms.DataGridView();
            this.btnFile = new System.Windows.Forms.Button();
            this.gbChat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChat)).BeginInit();
            this.SuspendLayout();
            // 
            // gbChat
            // 
            this.gbChat.Controls.Add(this.btnFile);
            this.gbChat.Controls.Add(this.dgvChat);
            this.gbChat.Controls.Add(this.btnInviaMsg);
            this.gbChat.Controls.Add(this.txtInviaMsg);
            this.gbChat.Location = new System.Drawing.Point(258, 13);
            this.gbChat.Name = "gbChat";
            this.gbChat.Size = new System.Drawing.Size(478, 583);
            this.gbChat.TabIndex = 0;
            this.gbChat.TabStop = false;
            this.gbChat.Text = "Nome Utente";
            // 
            // txtInviaMsg
            // 
            this.txtInviaMsg.Location = new System.Drawing.Point(7, 557);
            this.txtInviaMsg.Name = "txtInviaMsg";
            this.txtInviaMsg.Size = new System.Drawing.Size(358, 20);
            this.txtInviaMsg.TabIndex = 0;
            // 
            // btnInviaMsg
            // 
            this.btnInviaMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInviaMsg.Location = new System.Drawing.Point(419, 557);
            this.btnInviaMsg.Name = "btnInviaMsg";
            this.btnInviaMsg.Size = new System.Drawing.Size(53, 20);
            this.btnInviaMsg.TabIndex = 1;
            this.btnInviaMsg.Text = "INVIA";
            this.btnInviaMsg.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListaUtenti);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 583);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista Utenti Disponibili";
            // 
            // dgvListaUtenti
            // 
            this.dgvListaUtenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaUtenti.Location = new System.Drawing.Point(7, 20);
            this.dgvListaUtenti.Name = "dgvListaUtenti";
            this.dgvListaUtenti.ReadOnly = true;
            this.dgvListaUtenti.Size = new System.Drawing.Size(226, 557);
            this.dgvListaUtenti.TabIndex = 0;
            // 
            // dgvChat
            // 
            this.dgvChat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChat.Location = new System.Drawing.Point(7, 20);
            this.dgvChat.Name = "dgvChat";
            this.dgvChat.ReadOnly = true;
            this.dgvChat.Size = new System.Drawing.Size(465, 531);
            this.dgvChat.TabIndex = 2;
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(372, 557);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(41, 20);
            this.btnFile.TabIndex = 3;
            this.btnFile.Text = "FILE";
            this.btnFile.UseVisualStyleBackColor = true;
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 608);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmChat";
            this.Text = "CHAT";
            this.gbChat.ResumeLayout(false);
            this.gbChat.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUtenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbChat;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.DataGridView dgvChat;
        private System.Windows.Forms.Button btnInviaMsg;
        private System.Windows.Forms.TextBox txtInviaMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListaUtenti;
    }
}


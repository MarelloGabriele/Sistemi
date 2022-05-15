namespace Chat_Client
{
    partial class frmLoadFile
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
            this.btnWebcam = new System.Windows.Forms.Button();
            this.btnImg = new System.Windows.Forms.Button();
            this.btnZip = new System.Windows.Forms.Button();
            this.btnTxt = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWebcam
            // 
            this.btnWebcam.Location = new System.Drawing.Point(58, 54);
            this.btnWebcam.Name = "btnWebcam";
            this.btnWebcam.Size = new System.Drawing.Size(60, 60);
            this.btnWebcam.TabIndex = 0;
            this.btnWebcam.Text = "button1";
            this.btnWebcam.UseVisualStyleBackColor = true;
            // 
            // btnImg
            // 
            this.btnImg.Location = new System.Drawing.Point(124, 54);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(60, 60);
            this.btnImg.TabIndex = 1;
            this.btnImg.Text = "button2";
            this.btnImg.UseVisualStyleBackColor = true;
            // 
            // btnZip
            // 
            this.btnZip.Location = new System.Drawing.Point(190, 54);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(60, 60);
            this.btnZip.TabIndex = 2;
            this.btnZip.Text = "button3";
            this.btnZip.UseVisualStyleBackColor = true;
            // 
            // btnTxt
            // 
            this.btnTxt.Location = new System.Drawing.Point(256, 54);
            this.btnTxt.Name = "btnTxt";
            this.btnTxt.Size = new System.Drawing.Size(60, 60);
            this.btnTxt.TabIndex = 3;
            this.btnTxt.Text = "button4";
            this.btnTxt.UseVisualStyleBackColor = true;
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(322, 54);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(60, 60);
            this.btnVideo.TabIndex = 4;
            this.btnVideo.Text = "button5";
            this.btnVideo.UseVisualStyleBackColor = true;
            // 
            // frmLoadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 206);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.btnTxt);
            this.Controls.Add(this.btnZip);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.btnWebcam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLoadFile";
            this.Text = "CARICA FILE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWebcam;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Button btnTxt;
        private System.Windows.Forms.Button btnVideo;
    }
}
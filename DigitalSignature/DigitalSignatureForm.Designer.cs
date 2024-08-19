namespace DigitalSignature
{
    partial class DigitalSignatureForm
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
            this.lbxAvailableCerts = new System.Windows.Forms.ListBox();
            this.lblChooseCert = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnUploadDocument = new System.Windows.Forms.Button();
            this.lblChosenDocument = new System.Windows.Forms.Label();
            this.btnSignDocument = new System.Windows.Forms.Button();
            this.btnVerifySignature = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxAvailableCerts
            // 
            this.lbxAvailableCerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAvailableCerts.FormattingEnabled = true;
            this.lbxAvailableCerts.HorizontalScrollbar = true;
            this.lbxAvailableCerts.ItemHeight = 20;
            this.lbxAvailableCerts.Location = new System.Drawing.Point(12, 40);
            this.lbxAvailableCerts.Name = "lbxAvailableCerts";
            this.lbxAvailableCerts.Size = new System.Drawing.Size(970, 204);
            this.lbxAvailableCerts.TabIndex = 0;
            // 
            // lblChooseCert
            // 
            this.lblChooseCert.AutoSize = true;
            this.lblChooseCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseCert.Location = new System.Drawing.Point(8, 12);
            this.lblChooseCert.Name = "lblChooseCert";
            this.lblChooseCert.Size = new System.Drawing.Size(147, 20);
            this.lblChooseCert.TabIndex = 1;
            this.lblChooseCert.Text = "Izaberite sertifikat:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Files|*.pdf;*.txt;*.docx;*.doc";
            // 
            // btnUploadDocument
            // 
            this.btnUploadDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadDocument.Location = new System.Drawing.Point(12, 262);
            this.btnUploadDocument.Name = "btnUploadDocument";
            this.btnUploadDocument.Size = new System.Drawing.Size(263, 44);
            this.btnUploadDocument.TabIndex = 2;
            this.btnUploadDocument.Text = "Izaberite dokument";
            this.btnUploadDocument.UseVisualStyleBackColor = true;
            this.btnUploadDocument.Click += new System.EventHandler(this.btnUploadDocument_Click);
            // 
            // lblChosenDocument
            // 
            this.lblChosenDocument.AutoSize = true;
            this.lblChosenDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChosenDocument.Location = new System.Drawing.Point(292, 274);
            this.lblChosenDocument.Name = "lblChosenDocument";
            this.lblChosenDocument.Size = new System.Drawing.Size(276, 20);
            this.lblChosenDocument.TabIndex = 3;
            this.lblChosenDocument.Text = "Trenutno nemate izabrani dokument";
            // 
            // btnSignDocument
            // 
            this.btnSignDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignDocument.Location = new System.Drawing.Point(205, 347);
            this.btnSignDocument.Name = "btnSignDocument";
            this.btnSignDocument.Size = new System.Drawing.Size(259, 47);
            this.btnSignDocument.TabIndex = 4;
            this.btnSignDocument.Text = "Potpišite dokument";
            this.btnSignDocument.UseVisualStyleBackColor = true;
            this.btnSignDocument.Click += new System.EventHandler(this.btnSignDocument_Click);
            // 
            // btnVerifySignature
            // 
            this.btnVerifySignature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifySignature.Location = new System.Drawing.Point(492, 347);
            this.btnVerifySignature.Name = "btnVerifySignature";
            this.btnVerifySignature.Size = new System.Drawing.Size(259, 47);
            this.btnVerifySignature.TabIndex = 5;
            this.btnVerifySignature.Text = "Proverite digitalni potpis";
            this.btnVerifySignature.UseVisualStyleBackColor = true;
            this.btnVerifySignature.Click += new System.EventHandler(this.btnVerifySignature_Click);
            // 
            // DigitalSignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 425);
            this.Controls.Add(this.btnVerifySignature);
            this.Controls.Add(this.btnSignDocument);
            this.Controls.Add(this.lblChosenDocument);
            this.Controls.Add(this.btnUploadDocument);
            this.Controls.Add(this.lblChooseCert);
            this.Controls.Add(this.lbxAvailableCerts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DigitalSignatureForm";
            this.Text = "Digitalno potpisivanje dokumenata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxAvailableCerts;
        private System.Windows.Forms.Label lblChooseCert;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnUploadDocument;
        private System.Windows.Forms.Label lblChosenDocument;
        private System.Windows.Forms.Button btnSignDocument;
        private System.Windows.Forms.Button btnVerifySignature;
    }
}


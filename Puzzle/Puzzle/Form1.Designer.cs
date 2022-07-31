namespace Puzzle {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.thumbnailPicBox = new System.Windows.Forms.PictureBox();
            this.importButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbnailPicBox
            // 
            this.thumbnailPicBox.Location = new System.Drawing.Point(33, 94);
            this.thumbnailPicBox.Name = "thumbnailPicBox";
            this.thumbnailPicBox.Size = new System.Drawing.Size(286, 380);
            this.thumbnailPicBox.TabIndex = 0;
            this.thumbnailPicBox.TabStop = false;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(33, 35);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(132, 32);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Import Image";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.jpe;*.jpeg;*.jpg;*.bmp;*.png)|*.jpe;*.jpeg;*.jpg;*.bmp;*.png|All f" +
    "iles (*.*)|*.*";
            this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.InitialDirectory = "\"c:\\\\\"";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1779, 825);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.thumbnailPicBox);
            this.Name = "Form1";
            this.Text = "Puzzle";
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbnailPicBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}


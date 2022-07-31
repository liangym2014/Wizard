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
            this.openButton = new System.Windows.Forms.Button();
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
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(33, 35);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(132, 32);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Import Image";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
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
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.thumbnailPicBox);
            this.Name = "Form1";
            this.Text = "Puzzle";
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbnailPicBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}


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
            this.thumbnailpb = new System.Windows.Forms.PictureBox();
            this.importButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLP = new System.Windows.Forms.TableLayoutPanel();
            this.nextElementpb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailpb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextElementpb)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbnailpb
            // 
            this.thumbnailpb.Location = new System.Drawing.Point(33, 94);
            this.thumbnailpb.Name = "thumbnailpb";
            this.thumbnailpb.Size = new System.Drawing.Size(286, 380);
            this.thumbnailpb.TabIndex = 0;
            this.thumbnailpb.TabStop = false;
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.importButton.Location = new System.Drawing.Point(33, 35);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(132, 32);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Import Image";
            this.importButton.UseVisualStyleBackColor = false;
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
            // tableLP
            // 
            this.tableLP.AutoSize = true;
            this.tableLP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLP.ColumnCount = 1;
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 750F));
            this.tableLP.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLP.Location = new System.Drawing.Point(489, 35);
            this.tableLP.Margin = new System.Windows.Forms.Padding(0);
            this.tableLP.Name = "tableLP";
            this.tableLP.RowCount = 1;
            this.tableLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 750F));
            this.tableLP.Size = new System.Drawing.Size(750, 750);
            this.tableLP.TabIndex = 0;
            // 
            // nextElementpb
            // 
            this.nextElementpb.Location = new System.Drawing.Point(115, 553);
            this.nextElementpb.Name = "nextElementpb";
            this.nextElementpb.Size = new System.Drawing.Size(50, 50);
            this.nextElementpb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextElementpb.TabIndex = 2;
            this.nextElementpb.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 825);
            this.Controls.Add(this.nextElementpb);
            this.Controls.Add(this.tableLP);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.thumbnailpb);
            this.Name = "Form1";
            this.Text = "Puzzle";
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailpb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextElementpb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbnailpb;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLP;
        private System.Windows.Forms.PictureBox nextElementpb;
    }
}


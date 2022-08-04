namespace Puzzle {
    partial class PuzzleForm {
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
            this.nextPieceLabel = new System.Windows.Forms.Label();
            this.easyOption = new System.Windows.Forms.RadioButton();
            this.intermediateOption = new System.Windows.Forms.RadioButton();
            this.hardOption = new System.Windows.Forms.RadioButton();
            this.levelGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailpb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextElementpb)).BeginInit();
            this.levelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // thumbnailpb
            // 
            this.thumbnailpb.Location = new System.Drawing.Point(33, 205);
            this.thumbnailpb.Name = "thumbnailpb";
            this.thumbnailpb.Size = new System.Drawing.Size(286, 380);
            this.thumbnailpb.TabIndex = 0;
            this.thumbnailpb.TabStop = false;
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.importButton.Location = new System.Drawing.Point(33, 146);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(132, 32);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Import Image";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.tiff;*.jpeg;*.jpg;*.bmp;*.png;*.gif)|*.jpe;*.jpeg;*.jpg;*.bmp;*.pn" +
    "g|All files (*.*)|*.*";
            this.openFileDialog.FilterIndex = 0;
            this.openFileDialog.InitialDirectory = "\"c:\\\\\"";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // tableLP
            // 
            this.tableLP.BackColor = System.Drawing.SystemColors.Control;
            this.tableLP.ColumnCount = 1;
            this.tableLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 750F));
            this.tableLP.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLP.Location = new System.Drawing.Point(559, 35);
            this.tableLP.Margin = new System.Windows.Forms.Padding(0);
            this.tableLP.Name = "tableLP";
            this.tableLP.RowCount = 1;
            this.tableLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 750F));
            this.tableLP.Size = new System.Drawing.Size(750, 750);
            this.tableLP.TabIndex = 0;
            // 
            // nextElementpb
            // 
            this.nextElementpb.Location = new System.Drawing.Point(33, 708);
            this.nextElementpb.Name = "nextElementpb";
            this.nextElementpb.Size = new System.Drawing.Size(50, 50);
            this.nextElementpb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextElementpb.TabIndex = 2;
            this.nextElementpb.TabStop = false;
            // 
            // nextPieceLabel
            // 
            this.nextPieceLabel.AutoSize = true;
            this.nextPieceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextPieceLabel.Location = new System.Drawing.Point(29, 669);
            this.nextPieceLabel.Name = "nextPieceLabel";
            this.nextPieceLabel.Size = new System.Drawing.Size(90, 20);
            this.nextPieceLabel.TabIndex = 3;
            this.nextPieceLabel.Text = "Next Piece";
            // 
            // easyOption
            // 
            this.easyOption.AutoSize = true;
            this.easyOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyOption.Location = new System.Drawing.Point(27, 25);
            this.easyOption.Name = "easyOption";
            this.easyOption.Size = new System.Drawing.Size(67, 24);
            this.easyOption.TabIndex = 4;
            this.easyOption.TabStop = true;
            this.easyOption.Text = "Easy";
            this.easyOption.UseVisualStyleBackColor = true;
            this.easyOption.CheckedChanged += new System.EventHandler(this.easyOption_CheckedChanged);
            // 
            // intermediateOption
            // 
            this.intermediateOption.AutoSize = true;
            this.intermediateOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intermediateOption.Location = new System.Drawing.Point(27, 52);
            this.intermediateOption.Name = "intermediateOption";
            this.intermediateOption.Size = new System.Drawing.Size(122, 24);
            this.intermediateOption.TabIndex = 5;
            this.intermediateOption.TabStop = true;
            this.intermediateOption.Text = "Intermediate";
            this.intermediateOption.UseVisualStyleBackColor = true;
            this.intermediateOption.CheckedChanged += new System.EventHandler(this.intermediateOption_CheckedChanged);
            // 
            // hardOption
            // 
            this.hardOption.AutoSize = true;
            this.hardOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardOption.Location = new System.Drawing.Point(27, 79);
            this.hardOption.Name = "hardOption";
            this.hardOption.Size = new System.Drawing.Size(67, 24);
            this.hardOption.TabIndex = 6;
            this.hardOption.TabStop = true;
            this.hardOption.Text = "Hard";
            this.hardOption.UseVisualStyleBackColor = true;
            this.hardOption.CheckedChanged += new System.EventHandler(this.hardOption_CheckedChanged);
            // 
            // levelGroupBox
            // 
            this.levelGroupBox.Controls.Add(this.easyOption);
            this.levelGroupBox.Controls.Add(this.hardOption);
            this.levelGroupBox.Controls.Add(this.intermediateOption);
            this.levelGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelGroupBox.Location = new System.Drawing.Point(33, 12);
            this.levelGroupBox.Name = "levelGroupBox";
            this.levelGroupBox.Size = new System.Drawing.Size(200, 113);
            this.levelGroupBox.TabIndex = 7;
            this.levelGroupBox.TabStop = false;
            this.levelGroupBox.Text = "Level";
            // 
            // PuzzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1518, 825);
            this.Controls.Add(this.levelGroupBox);
            this.Controls.Add(this.nextPieceLabel);
            this.Controls.Add(this.nextElementpb);
            this.Controls.Add(this.tableLP);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.thumbnailpb);
            this.Name = "PuzzleForm";
            this.Text = "Puzzle";
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailpb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextElementpb)).EndInit();
            this.levelGroupBox.ResumeLayout(false);
            this.levelGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbnailpb;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLP;
        private System.Windows.Forms.PictureBox nextElementpb;
        private System.Windows.Forms.Label nextPieceLabel;
        private System.Windows.Forms.RadioButton easyOption;
        private System.Windows.Forms.RadioButton intermediateOption;
        private System.Windows.Forms.RadioButton hardOption;
        private System.Windows.Forms.GroupBox levelGroupBox;
    }
}


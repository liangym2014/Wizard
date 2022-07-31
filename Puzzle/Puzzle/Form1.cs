using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Puzzle {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void importButton_Click(object sender, EventArgs e) {
            string filename = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filename = openFileDialog.FileName;
            }
            else
                return;
            // If the image is square, display it in width * width;
            // otherwise, display it in width * height.
            int width = 300, height = 200;
            Bitmap bm;
            try {
                bm = new Bitmap(filename);

                if (bm.Width == bm.Height)
                    height = width;
                else if (bm.Width < bm.Height)
                    (width, height) = (height, width);

                thumbnailPicBox.Width = width;
                thumbnailPicBox.Height = height;
                thumbnailPicBox.Image = bm;
                thumbnailPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch {
                MessageBox.Show("Invalid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PuzzleProcess p = new PuzzleProcess(ref bm);
        }
    }
}

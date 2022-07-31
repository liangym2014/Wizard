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

        private void openButton_Click(object sender, EventArgs e) {
            string filename = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filename = openFileDialog.FileName;
            }
            else
                return;
            // If the image is square, display it in edge1 * edge1;
            // otherwise, display it in edge1 * edge2 or edge2 * edge1.
            int edge1 = 300, edge2 = 200;
            try {
                Bitmap bm = new Bitmap(filename);
                int h = bm.Height, w = bm.Width;
                if(h == w){
                    thumbnailPicBox.Height = edge1;
                    thumbnailPicBox.Width = edge1;
                }
                else if(h > w){
                    thumbnailPicBox.Height = edge1;
                    thumbnailPicBox.Width = edge2;
                }
                else{
                    thumbnailPicBox.Height = edge2;
                    thumbnailPicBox.Width = edge1;
                }
                thumbnailPicBox.Image = bm;
                thumbnailPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch{
                MessageBox.Show("Invalid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

        }
    }
}

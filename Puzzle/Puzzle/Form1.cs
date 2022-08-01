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

                thumbnailpb.Width = width;
                thumbnailpb.Height = height;
                thumbnailpb.Image = bm;
                thumbnailpb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch {
                MessageBox.Show("Invalid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PuzzleProcess p = new PuzzleProcess(ref bm);
            float pieceSize = Convert.ToSingle(p.getPieceSize());
            List<element> pieces = p.getElements();
            // clear the controls and styles in table
            tableLP.Controls.Clear();
            tableLP.RowStyles.Clear();
            tableLP.ColumnStyles.Clear();

            // set table size, number of rows and columns
            tableLP.Height = Convert.ToInt32(2.5 * height);
            tableLP.Width = Convert.ToInt32(2.5 * width);
            tableLP.RowCount = Convert.ToInt32(tableLP.Height / pieceSize);
            tableLP.ColumnCount = Convert.ToInt32(tableLP.Width / pieceSize);

            // set column style
            for(int j = 0; j < tableLP.Width; j ++)
                tableLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, pieceSize));

            int i = 0;
            for (int r = 0; r < tableLP.RowCount; r ++) {
                tableLP.RowStyles.Add(new RowStyle(SizeType.Absolute, pieceSize));  // set row column style
                for (int c = 0; c < tableLP.ColumnCount; c++) {
                    PictureBox pb = new PictureBox();
                    pb.Image = pieces[i ++].image; // load pieces into table
                    tableLP.Controls.Add(pb, c, r);
                }
            }
        }
    }
}

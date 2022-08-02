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
        private PuzzleProcess p;
        private int idx;
        public Form1() {
            InitializeComponent();
            nextElementpb.MouseDown += nextElementpb_MouseDown;
            // test picturebox
            destinationpb.AllowDrop = true;
            destinationpb.DragEnter += destinationpb_DragEnter;
            destinationpb.DragDrop += destinationpb_DragDrop;
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

            p = new PuzzleProcess(ref bm);
            int pieceSize = p.getPieceSize();

            // clear the controls and styles in table
            tableLP.Controls.Clear();
            tableLP.RowStyles.Clear();
            tableLP.ColumnStyles.Clear();

            // set table size, number of rows and columns
            tableLP.Height = Convert.ToInt32(2.5 * height);
            tableLP.Width = Convert.ToInt32(2.5 * width);
            tableLP.RowCount = tableLP.Height / pieceSize;
            tableLP.ColumnCount = tableLP.Width / pieceSize;

            // set column style
            for(int j = 0; j < tableLP.Width; j ++)
                tableLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, pieceSize));

            // add picturebox to each cell
            for (int r = 0; r < tableLP.RowCount; r ++) {
                tableLP.RowStyles.Add(new RowStyle(SizeType.Absolute, pieceSize));  // set row column style
                for (int c = 0; c < tableLP.ColumnCount; c++) {
                    PictureBox pb = new PictureBox();
                    pb.BorderStyle = BorderStyle.FixedSingle; // display cell border
                    pb.Margin = Padding.Empty;  // no space between cells
                    pb.Tag = -1;  // initiliaze tag as -1
                    tableLP.Controls.Add(pb, c, r);
                }
            }

            // initialize nextElementpb size
            nextElementpb.Height = pieceSize;
            nextElementpb.Width = pieceSize;

            // display the 1st piece
            element ele = p.getNextPiece().First<element>();
            nextElementpb.Image = ele.image;
            nextElementpb.Tag = ele.index; // store the index of piece
        }

        private void nextElementpb_Click(object sender, EventArgs e) {
            foreach (element piece in p.getNextPiece()) {
                nextElementpb.Image = piece.image;
                nextElementpb.Tag = piece.index;
            }
        }

        private void nextElementpb_MouseDown(object sender, MouseEventArgs e) {
            var img = nextElementpb.Image;
            if (img == null) return;  // return after the last piece
            if (e.Button == MouseButtons.Left) {
                nextElementpb.DoDragDrop(img, DragDropEffects.Move);  // move the piece in nextElementpb
                idx = (int)nextElementpb.Tag;  // transfer the index via idx
                Debug.WriteLine("source:" + idx);
                foreach (element piece in p.getNextPiece()){ 
                    nextElementpb.Image = piece.image;
                    nextElementpb.Tag = piece.index;
                }
            }
        }
        private void destinationpb_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        private void destinationpb_DragDrop(object sender, DragEventArgs e) {
            destinationpb.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            destinationpb.Tag = idx;
            Debug.WriteLine("dest:" + idx);
        }
    }
}

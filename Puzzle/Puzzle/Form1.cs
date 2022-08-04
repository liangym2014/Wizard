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
        private int idx; // the index of piece in source PB
        private int count = 0; // the number of filled cells in table
        private int rows, cols;  // the number of rows and columns of table
        private Point src;  // source location of dragdrop operation
        private int pieceSize;
        List<element> elements;
        public Form1() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // maximize window
            nextElementpb.MouseDown += src_MouseDown;
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
            pieceSize = p.ElementSize;
            elements = p.Elements;
            //clear counter
            count = 0;

            // clear the controls and styles in table
            tableLP.Controls.Clear();
            tableLP.RowStyles.Clear();
            tableLP.ColumnStyles.Clear();

            // set table size, number of rows and columns
            tableLP.Height = Convert.ToInt32(2.5 * height);
            tableLP.Width = Convert.ToInt32(2.5 * width);

            // set location
            tableLP.Location = (tableLP.Height < tableLP.Width)? new Point(600, 94): new Point(600, 35);

            // set the number of rows and cols
            rows = tableLP.Height / pieceSize;
            cols = tableLP.Width / pieceSize;
            tableLP.RowCount = rows;
            tableLP.ColumnCount = cols;

            // set column style
            for (int j = 0; j < cols; j++)
                tableLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, pieceSize));

            // add row style and cells
            for (int r = 0; r < rows; r++) {
                tableLP.RowStyles.Add(new RowStyle(SizeType.Absolute, pieceSize));  // set row column style
                for (int c = 0; c < cols; c++) {
                    tableLP.Controls.Add(configureCell(), c, r);
                }
            }

            // initialize nextElementpb size
            nextElementpb.Height = pieceSize;
            nextElementpb.Width = pieceSize;

            // display the 1st piece
            displayNextElement();
        }

        /// <summary>
        /// Return a cell with specific configuration.
        /// </summary>
        /// <returns></returns>
        private PictureBox configureCell() {
            PictureBox pb = new PictureBox();
            pb.Height = pieceSize;  // set height and width
            pb.Width = pieceSize;
            pb.BorderStyle = BorderStyle.FixedSingle; // display cell border
            pb.Margin = Padding.Empty;  // no space between cells
            pb.Padding = Padding.Empty;
            pb.Tag = -1;
            pb.AllowDrop = true;
            pb.MouseDown += src_MouseDown;
            pb.DragEnter += dest_DragEnter;
            pb.DragDrop += dest_DragDrop;
            return pb;
        }

        /// <summary>
        /// fill nextElement PB with next piece of puzzle
        /// </summary>
        private void displayNextElement() {
            if (count < elements.Count) {
                nextElementpb.Image = elements[count].image;
                nextElementpb.Tag = elements[count].index;
                //Debug.WriteLine("new element id:" + nextElementpb.Tag.ToString());
            }
            else{
                nextElementpb.Image = null;
                nextElementpb.Tag = -1;
            }
        }

        /// <summary>
        /// Enable drag for source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void src_MouseDown(object sender, MouseEventArgs e) {
            PictureBox source = (PictureBox)sender;
            var img = source.Image;
            if (img == null)
                return;

            if (e.Button == MouseButtons.Left) {
                if (source.Parent == tableLP) // source is in table
                    src = new Point(source.Location.X, source.Location.Y);
                else
                    src = new Point(-1, -1);  // source is nextElement PB

                idx = (int)source.Tag;
                //Debug.WriteLine("src:" + src.X.ToString() + ", " + src.Y.ToString() + ",\tmouse down idx:" + idx.ToString());

                // DoDragDrop invokes DragEnter and DragDrop, then return to MouseDown method
                source.DoDragDrop(img, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// Enable drag effect for destination.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dest_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// Enable drop for destination.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dest_DragDrop(object sender, DragEventArgs e) {
            PictureBox dest = sender as PictureBox;
            //int c = (int)(dest.Location.X / pieceSize), r = (int)(dest.Location.Y / pieceSize);
            //Debug.WriteLine("table location:" + c.ToString() + ", " + r.ToString());

            Bitmap src_img = e.Data.GetData(DataFormats.Bitmap) as Bitmap;

            if (src.X < 0) { // bitmap is from nextElement PB
                if (dest.Image == null) {
                    dest.Image = src_img;
                    dest.Tag = idx;
                    ++ count;
                    //Debug.WriteLine("cells filled:" + count.ToString() + ", dest.Tag:" + idx.ToString() + "\n");
                    displayNextElement();
                }
            }
            else { // bitmap is from a cell, swap source and destination
/*                Debug.WriteLine("swap: (" + ((int)(src.X / pieceSize)).ToString() + ", " + ((int)(src.Y / pieceSize)).ToString()
                 + ") -> (" + c.ToString() + ", " + r.ToString() + ")");*/
                PictureBox source = tableLP.GetChildAtPoint(new Point(src.X, src.Y)) as PictureBox;
                swapPictureBox(src_img, ref source, ref dest);
            }

            // check matching when all cells are filled
            if (count == (rows * cols)) {
                if (!checkMatch())
                    MessageBox.Show("Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Congratulation!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }

        /// <summary>
        /// Return the result of checking the puzzle.
        /// </summary>
        /// <returns></returns>
        private bool checkMatch() {
            int i = 0;
            for (int r = 0; r < rows; r ++) {
                for (int c = 0; c < cols; c ++) {
                    var pb = tableLP.GetControlFromPosition(c, r);
                    if ((int)pb.Tag != i)
                        return false;
                    i ++;
                }
            }
            return true;
        }

        /// <summary>
        /// Swap the bitmap and index between two PBs.
        /// </summary>
        /// <param name="src_bitmap"></param>
        /// <param name="dest"></param>
        /// <param name="src"></param>
        private void swapPictureBox(Bitmap src_bitmap, ref PictureBox src, ref PictureBox dest) {
            (src.Image, dest.Image) = (dest.Image, src_bitmap);
            (src.Tag, dest.Tag) = (dest.Tag, idx);
        }
    }
}

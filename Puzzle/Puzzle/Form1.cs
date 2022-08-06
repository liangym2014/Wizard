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
    /// <summary>
    /// Define a struct containing a bitmap and an index to represent a piece of puzzle.
    /// </summary>
    public struct element {
        public Bitmap image;
        public int index;
        public element(Bitmap img, int idx) {
            image = img;
            index = idx;
        }
    };

    public partial class PuzzleForm : Form {
        private int idx; // the index of piece in source PB
        private int count = 0; // the number of filled cells in table
        private int rows, cols;  // the number of rows and columns of table
        private Point src;  // source location of dragdrop operation
        private int pieceSize = 0;
        private List<element> elements;

        public PuzzleForm() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // maximize window
            nextElementpb.MouseDown += new MouseEventHandler(src_MouseDown);
        }

        /// <summary>
        /// Import image, initialize table and next element PB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importButton_Click(object sender, EventArgs e) {
            string filename = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filename = openFileDialog.FileName;
            }
            else
                return;

            // If the image is square, display it in width * width;
            // otherwise, display it in width * height.
            int width = 360, height = 240;
            Bitmap bm;
            try {
                bm = new Bitmap(filename);
            }
            catch {
                nextElementpb.Image = null;
                nextElementpb.BorderStyle = BorderStyle.None;
                thumbnailpb.Image = null;
                thumbnailpb.BorderStyle = BorderStyle.None;
                tableLP.Controls.Clear();
                tableLP.BackColor = SystemColors.Control;
                MessageBox.Show("Invalid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bm.Width == bm.Height)
                height = width;
            else if (bm.Width < bm.Height)
                (width, height) = (height, width);

            thumbnailpb.Width = width;
            thumbnailpb.Height = height;
            thumbnailpb.Image = bm;
            thumbnailpb.SizeMode = PictureBoxSizeMode.StretchImage;
            thumbnailpb.BorderStyle = BorderStyle.FixedSingle;

            // clear the controls and styles in table
            tableLP.Controls.Clear();
            tableLP.RowStyles.Clear();
            tableLP.ColumnStyles.Clear();

            //clear counter
            count = 0;

            // set table height, width and piecesize
            if (pieceSize == 0) {
                MessageBox.Show("Choose a Level", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            height *= 3;
            width *= 3;
            tableLP.Height = height;
            tableLP.Width = width;

            // set background color
            tableLP.BackColor = Color.White;

            // set location
            tableLP.Location = (tableLP.Height <= tableLP.Width) ? new Point(450, 110) : new Point(600, 35);

            // set the number of rows and cols
            rows = tableLP.Height / pieceSize;
            cols = tableLP.Width / pieceSize;
            tableLP.RowCount = rows;
            tableLP.ColumnCount = cols;

            // set column style
            for (int j = 0; j < cols; j++)
                tableLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, pieceSize));

            // set row style and add cells
            for (int r = 0; r < rows; r++) {
                tableLP.RowStyles.Add(new RowStyle(SizeType.Absolute, pieceSize));  // set row column style
                for (int c = 0; c < cols; c++) {
                    tableLP.Controls.Add(configureCell(), c, r);
                }
            }

            // initialize nextElementpb size
            nextElementpb.Height = pieceSize;
            nextElementpb.Width = pieceSize;
            nextElementpb.BorderStyle = BorderStyle.FixedSingle;

            // get pieces of the puzzle
            elements = new List<element>();
            cutImage(ref bm, ref height, ref width, ref pieceSize);

            // shuffle pieces
            shuffleElements();

            // display the 1st piece
            displayNextElement();

        }

        /// <summary>
        /// Set piece size when easy radio button is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void easyOption_CheckedChanged(object sender, EventArgs e) {
            pieceSize = 360;
        }

        /// <summary>
        /// Set piece size when intermediate radio button is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intermediateOption_CheckedChanged(object sender, EventArgs e) {
            pieceSize = 180;
        }

        /// <summary>
        /// Set piece size when hard radio button is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hardOption_CheckedChanged(object sender, EventArgs e) {
            pieceSize = 90;
        }

        /// <summary>
        /// Return a cell with specific configuration.
        /// </summary>
        /// <returns></returns>
        private PictureBox configureCell() {
            PictureBox pb = new PictureBox();
            pb.Height = pieceSize;  // set height and width
            pb.Width = pieceSize;
            //pb.BorderStyle = BorderStyle.FixedSingle; // display cell border
            pb.Margin = Padding.Empty;  // no space between cells
            pb.Padding = Padding.Empty;
            pb.Tag = -1;
            pb.AllowDrop = true;
            pb.MouseDown += new MouseEventHandler(src_MouseDown);
            pb.DragEnter += new DragEventHandler(dest_DragEnter);
            pb.DragDrop += new DragEventHandler(dest_DragDrop);
            return pb;
        }

        /// <summary>
        /// Construct a puzzle with the imported bitmap Image. Resize the image into width * height. Divide it into pieces.
        /// </summary>
        /// <param name="bm"></param>
        public void cutImage(ref Bitmap bm, ref int height, ref int width, ref int edge) {
            // turn the imported Image into the desired size
            bm = new Bitmap(bm.GetThumbnailImage(width, height, new Image.GetThumbnailImageAbort(delegate { return false; }), new IntPtr(0)));

            // divide the Image into small pieces
            int i = 0;
            for (int r = 0, rlim = height / edge; r < rlim; r++) {
                for (int c = 0, clim = width / edge; c < clim; c++) {
                    int x = c * edge, y = r * edge;
                    Bitmap p = bm.Clone(new Rectangle(x, y, edge, edge), bm.PixelFormat);
                    elements.Add(new element(p, i++));
                }
            }
        }

        /// <summary>
        /// Return shuffled puzzle pieces.
        /// </summary>
        /// <returns></returns>
        public void shuffleElements() {
            Random rand = new Random();
            elements = elements.OrderBy(_ => rand.Next()).ToList();
        }

        /// <summary>
        /// fill nextElement PB with next piece of puzzle
        /// </summary>
        private void displayNextElement() {
            if (count < elements.Count) {
                nextElementpb.Image = elements[count].image;
                nextElementpb.Tag = elements[count].index;
            }
            else {
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
                    src = source.Location;
                else
                    src = new Point(-1, -1);  // source is nextElement PB

                idx = (int)source.Tag;
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
            Bitmap src_img = e.Data.GetData(DataFormats.Bitmap) as Bitmap;

            if (src.X < 0) { // bitmap is from nextElement PB
                if (dest.Image == null) {
                    dest.Image = src_img;
                    dest.Tag = idx;
                    ++ count;
                    displayNextElement();
                }
            }
            else { // bitmap is from a cell, swap source and destination
                PictureBox source = tableLP.GetChildAtPoint(src) as PictureBox;
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Puzzle {
    struct element {
        public Bitmap image;
        public int index;
        public element(Bitmap img, int idx) {
            image = img;
            index = idx;
        }
    };

    internal class PuzzleProcess {
        private int width = 750, height = 500;
        private List<element> elements;
        private int elementSize = 50;  // the edge of each piece

        public PuzzleProcess(ref Bitmap bm) {
            if (bm.Width == bm.Height)
                height = width;
            else if (bm.Width < bm.Height)
                (width, height) = (height, width);
            // turn the imported Image into the desired size
            Bitmap tnb = new Bitmap(bm.GetThumbnailImage(width, height, new Image.GetThumbnailImageAbort(delegate { return false; }), new IntPtr(0)));

            // divide the Image into small pieces
            elements = new List<element>();
            int i = 0;
            for (int r = 0, rlim = height / elementSize; r < rlim; r++) {
                for (int c = 0, clim = width / elementSize; c < clim; c++) {
                    elements.Add(new element(cutImage(ref tnb, c * elementSize, r * elementSize, elementSize), i++));
                }
            }
        }

        /// <summary>
        /// Return the bitmap pieces divided from the overeall Image.
        /// </summary>
        /// <param name="overall"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="edge"></param>
        /// <returns></returns>
        private Bitmap cutImage(ref Bitmap overall, int x, int y, int edge) {
            return overall.Clone(new Rectangle(x, y, edge, edge), overall.PixelFormat);
        }

        /// <summary>
        /// Return pieces of the Puzzle.
        /// </summary>
        /// <returns></returns>
        public List<element> getElements() {
            return elements;
        }

        /// <summary>
        /// Return the size of piece.
        /// </summary>
        /// <returns></returns>
        public int getPieceSize() {
            return elementSize;
        }
    }
}
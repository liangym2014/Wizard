using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Puzzle {
    internal class PuzzleProcess {
        private Graphics g;
        private int width = 600, height = 400;
        public PuzzleProcess(ref Bitmap bm) {
            if (bm.Width == bm.Height)
                height = width;
            else if (bm.Width < bm.Height)
                (width, height) = (height, width);
            g = Graphics.FromImage(bm.GetThumbnailImage(width, height, new Image.GetThumbnailImageAbort(delegate { return false; }), new IntPtr(0)));
        }
    }
}

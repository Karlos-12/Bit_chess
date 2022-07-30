using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitchess
{
    internal class movetake
    {
        public int indx { get; set; }
        public int nx { get; set; }
        public int ny { get; set; }
        public bool move { get; set; }

        public movetake(int indx, int nx, int ny, bool move)
        {
            this.indx = indx;
            this.nx = nx;
            this.ny = ny;
            this.move = move;
        }
    }
}

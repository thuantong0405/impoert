using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoclick.Model
{
    class Pointer
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Delay { get; set; }
        public Pointer(int id,int type,int x,int y,int delay = 1000)
        {
            this.ID = id;
            this.Type = type;
            this.X = x;
            this.Y = y;
            this.Delay = delay;
        }
        public Pointer()
        {
            
        }

    }
}

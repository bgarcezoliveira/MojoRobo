using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojoRobo.Common.Models
{
    public class BoardPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XBlock { get; set; }
        public int YBlock { get; set; }
        public string Direction { get; set; }

        public override string ToString()
        {
            return $"Positon {XBlock},{YBlock} Facing {Direction}";
        }
    }
}

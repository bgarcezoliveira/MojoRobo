using System.ComponentModel;
using System.Linq;
using MojoRobo.Common.Enums;

namespace MojoRobo.Common.Models
{
    public class BoardPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XBlock { get; set; }
        public int YBlock { get; set; }
        public InternalDirections Direction { get; set; }

        public override string ToString()
        {
            return $"Positon ({XBlock},{YBlock}) Facing {GetDirectionName()}";
        }

        public BoardPosition Clone()
        {
            return new BoardPosition()
            {
                Direction = this.Direction,
                X = this.X,
                Y = this.Y,
                XBlock = this.XBlock,
                YBlock = this.YBlock
            };
        }

        //TODO: move this into utilities class
        private string GetDirectionName()
        {
            var type = typeof(InternalDirections);
            var memInfo = type.GetMember(Direction.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }
    }
}

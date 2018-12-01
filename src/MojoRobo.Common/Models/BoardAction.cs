using MojoRobo.Common.Enums;

namespace MojoRobo.Common.Models
{
    public class BoardAction
    {
        public CommandTypes CommandType { get; set; }
        public BoardPosition Position { get; set; }
    }
}

using MojoRobo.Common.Enums;

namespace MojoRobo.Common.Models
{
    public class BoardAction
    {
        public CommandTypes CommandType { get; set; }
        public BoardPosition Position { get; set; }
        public bool IsExecutable { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", 
                                CommandType.ToString(), 
                                Position != null ? Position.ToString() : string.Empty, 
                                !IsExecutable ? "[ignored]" : string.Empty);
        }

        public string ToStringRegister()
        {
            if (CommandType  == CommandTypes.PLACE)
            {
                return ToString();
            }

            return $"{CommandType.ToString()}";
        }
    }
}

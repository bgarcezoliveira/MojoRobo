using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;

namespace MojoRobo.Core
{
    public class RobotStatus : IRobotStatus
    {
        #region Properties
        private bool IsPlaced { get; set; }
        private BoardPosition Position { get; set; }
        #endregion

        #region Constructor
        public RobotStatus() { }

        #endregion

        #region Interface
        public string Report()
        {
            return IsPlaced ? "Robot in " + Position.ToString() :
                                "Robot has not been placed";
        }

        public void Update(bool isPlaced, BoardPosition position = null)
        {
            Position = position;
            IsPlaced = isPlaced;
        }
        #endregion
    }
}

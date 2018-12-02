using MojoRobo.Common.Interfaces;
using System;
using System.Drawing;
using MojoRobo.Core.Interfaces;
using MojoRobo.Common.Enums;
using System.ComponentModel;

namespace MojoRobo.Core
{
    public class UIRobotManager : IUIRobotManager
    {
        #region Properties
        IRobotStatus RobotStatus { get; set; }
        #endregion

        #region Constructor
        public UIRobotManager(IRobotStatus robotStatus)
        {
            RobotStatus = robotStatus ?? throw new ArgumentNullException(nameof(robotStatus));
        }
        #endregion

        #region Interface
        public void Update(bool visible)
        {
            var panel = RobotStatus.GetRobotPanel();
            var position = RobotStatus.GetPosition();
            panel.Location = new Point(position.X, position.Y);
            panel.Visible = visible;

            Directions dir = (Directions)Enum.Parse(typeof(Directions), GetDirectionName(position.Direction));

            switch(dir)
            {
                case Directions.EAST:
                    panel.BackgroundImage = RobotStatus.GetImages()[0];
                    break;
                case Directions.NORTH:
                    panel.BackgroundImage = RobotStatus.GetImages()[1];
                    break;
                case Directions.SOUTH:
                    panel.BackgroundImage = RobotStatus.GetImages()[2];
                    break;
                case Directions.WEST:
                    panel.BackgroundImage = RobotStatus.GetImages()[3];
                    break;
            }
        }
        #endregion

        #region Private
        private string GetDirectionName(InternalDirections direction)
        {
            var type = typeof(InternalDirections);
            var memInfo = type.GetMember(direction.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }
        #endregion
    }
}

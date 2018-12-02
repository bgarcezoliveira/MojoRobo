using System;
using System.Collections.Generic;
using System.Linq;
using MojoRobo.Common.Constants;
using MojoRobo.Common.Enums;
using MojoRobo.Common.Interfaces;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;

namespace MojoRobo.Core
{
    public class ActionsValidationManager : IActionsValidationManager
    {
        #region Properties
        private IRobotStatus RobotStatus { get; set; } 
        private IBoardStatus BoardStatus { get; set; }
        #endregion

        #region Constructor
        public ActionsValidationManager(IRobotStatus robotStatus,
                                        IBoardStatus boardStatus)
        {
            RobotStatus = robotStatus ?? throw new ArgumentNullException(nameof(robotStatus));
            BoardStatus = boardStatus ?? throw new ArgumentNullException(nameof(boardStatus));
        }

        #endregion

        #region Interface
        public void ValidateActions(IEnumerable<BoardAction> actions)
        {
            bool isRobotPlaced = RobotStatus.GetIsPlaced();
            foreach (var action in actions)
            {
                if (action.CommandType != CommandTypes.PLACE && !isRobotPlaced)
                {
                    action.IsExecutable = false;
                }

                if (action.CommandType == CommandTypes.PLACE)
                {
                    isRobotPlaced = true;
                }
            }
        }

        public void ValidateAction(BoardAction action)
        {
            if (action.CommandType == CommandTypes.MOVE)
            {
                var xBoundaries = BoardStatus.GetXBoundaries();
                var yBoundaries = BoardStatus.GetYBoundaries();

                action.IsExecutable = !(action.Position.X < xBoundaries.Min || action.Position.X > xBoundaries.Max) &&
                                      !(action.Position.Y < yBoundaries.Min || action.Position.Y > yBoundaries.Max);
            }
        }

        //TODO: move error messages to resource file
        public IEnumerable<string> ValidatePlaceInput(string XBlock, string YBlock, string F)
        {
            List<string> errorList = new List<string>();

            if (string.IsNullOrEmpty(XBlock))
            {
                errorList.Add("X is empty");
            }
            else if (!int.TryParse(XBlock, out int x))
            {
                errorList.Add("X is invalid. Please provide an integer value");
            }
            else if (x < 1 || x > Globals.BlockCount)
            {
                errorList.Add("X is out of bounds");
            }

            if (string.IsNullOrEmpty(YBlock))
            {
                errorList.Add("Y is empty");
            }
            else if (!int.TryParse(YBlock, out int y))
            {
                errorList.Add("Y is invalid. Please provide an integer value");
            }
            else if (y < 1 || y > Globals.BlockCount)
            {
                errorList.Add("Y is out of bounds");
            }

            if (string.IsNullOrEmpty(F))
            {
                errorList.Add("F is empty");
            }
            else if (!char.TryParse(F, out char f))
            {
                errorList.Add("F is invalid. Please provide an char value");
            }
            else if (!typeof(Directions)
                        .GetEnumValues()
                        .Cast<Directions>()
                        .Any(d => ((char)d).ToString().ToLower() == f.ToString().ToLower()))
            {
                errorList.Add("F is an unrecognised direction");
            }

            return errorList.Count == 0 ? null : errorList;
        }
        #endregion
    }
}

using System;
using System.ComponentModel;
using System.Linq;
using MojoRobo.BL.Interfaces;
using MojoRobo.Common.Constants;
using MojoRobo.Common.Enums;
using MojoRobo.Common.Interfaces;
using MojoRobo.Common.Models;

namespace MojoRobo.BL
{
    public class CommandsLogic : ICommandsLogic
    {
        #region Properties
        private IBoardStatus BoardStatus { get; set; }
        private IRobotStatus RobotStatus { get; set; }
        #endregion

        #region Constructor
        public CommandsLogic(IBoardStatus boardStatus,
                            IRobotStatus robotStatus)
        {
            BoardStatus = boardStatus ?? throw new ArgumentNullException(nameof(boardStatus));
            RobotStatus = robotStatus ?? throw new ArgumentNullException(nameof(robotStatus));
        }

        #endregion

        #region Interface
        public BoardPosition GetLeftPosition()
        {
            BoardPosition position = RobotStatus.GetPosition();
            if (position != null)
            {
                char[] sequence = GetDirectionSequence(RobotStatus.GetDirectionOrigin());
                char currDirection = (char)position.Direction;
                int currIndex = sequence.ToList().IndexOf(currDirection);
                int nextIndex = currIndex - 1;
                nextIndex = nextIndex < 0 ? Globals.DirectionsSequenceOrigin : nextIndex;
                char nextDirection = sequence[nextIndex];
                position.Direction = (InternalDirections)nextDirection;
            }
            return position;
        }

        public BoardPosition GetMovePosition()
        {
            BoardPosition position = RobotStatus.GetPosition();
            BoardPosition pos = null;
            if (position != null)
            {
                Tuple<int, char> moveInfo = GetMoveInfo(position.Direction);
                int blockSize = BoardStatus.GetBlockSize();
                int offset = BoardStatus.GetOffset();
                int boardHeight = BoardStatus.GetBoardDimension().Height;

                pos = position.Clone();

                switch (moveInfo.Item2)
                {
                    case 'X':
                        int XBlock = position.XBlock + moveInfo.Item1;
                        int xBlock = (position.XBlock - 1) + moveInfo.Item1;
                        pos.XBlock = XBlock;
                        pos.X = (xBlock * blockSize) + offset;
                        break;
                    case 'Y':
                        int YBlock = position.YBlock + moveInfo.Item1;
                        pos.YBlock = YBlock;
                        pos.Y = boardHeight - (YBlock * blockSize) + offset;
                        break;
                }
            }
            return pos;
        }

        public BoardPosition GetPlacePosition(int XBlock, int YBlock, char F)
        {
            int xBlock = XBlock - 1;
            int yBlock = YBlock;
            int blockSize = BoardStatus.GetBlockSize();
            int offset = BoardStatus.GetOffset();
            int boardHeight = BoardStatus.GetBoardDimension().Height;

            BoardPosition position = new BoardPosition() {
                XBlock = XBlock,
                YBlock = YBlock,
                Direction = GetInternalDirection(F),
                X = (xBlock * blockSize) + offset,
                Y = boardHeight - (yBlock * blockSize) + offset
            };

            RobotStatus.SetDirectionOrigin(F);

            return position;
        }

        public BoardPosition GetRightPosition()
        {
            BoardPosition position = RobotStatus.GetPosition();
            if (position != null)
            {
                char[] sequence = GetDirectionSequence(RobotStatus.GetDirectionOrigin());
                char currDirection = (char)position.Direction;
                int currIndex = sequence.ToList().IndexOf(currDirection);
                int nextIndex = currIndex + 1;
                nextIndex = nextIndex == sequence.Length ? Globals.DirectionsSequenceOrigin : nextIndex;
                char nextDirection = sequence[nextIndex];
                position.Direction = (InternalDirections)nextDirection;
            }
            return position;
        }
        #endregion

        #region Private
        private InternalDirections GetInternalDirection(char F)
        {
            switch(F)
            {
                case 'N':
                    return InternalDirections.NORTH2;
                case 'E':
                    return InternalDirections.EAST2;
                case 'W':
                    return InternalDirections.WEST2;
                case 'S':
                    return InternalDirections.SOUTH2;
                default:
                    return InternalDirections.NORTH2;
            }
        }

        private char[] GetDirectionSequence(char F)
        {
            switch (F)
            {
                case 'N':
                    return Globals.DirectionsSequenceNorth;
                case 'E':
                    return Globals.DirectionsSequenceEast;
                case 'W':
                    return Globals.DirectionsSequenceWest;
                case 'S':
                    return Globals.DirectionsSequenceSouth;
                default:
                    return null;
            }
        }

        private Tuple<int, char> GetMoveInfo(InternalDirections direction)
        {
            Directions dir = (Directions)Enum.Parse(typeof(Directions), GetDirectionName(direction));
            switch (dir)
            {
                case Directions.NORTH:
                    return new Tuple<int, char>(1, 'Y');
                case Directions.SOUTH:
                    return new Tuple<int, char>(-1, 'Y');
                case Directions.EAST:
                    return new Tuple<int, char>(1, 'X');
                case Directions.WEST:
                    return new Tuple<int, char>(-1, 'X');
                default:
                    return null;
            }
        }

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

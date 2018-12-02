using System;
using MojoRobo.BL.Interfaces;
using MojoRobo.Common.Enums;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;

namespace MojoRobo.Core
{
    public class ActionsTranslator : IActionsTranslator
    {
        #region Properties
        ICommandsLogic CommandsLogic { get; set; }
        #endregion

        #region Constructor
        public ActionsTranslator(ICommandsLogic commandsLogic)
        {
            CommandsLogic = commandsLogic ?? throw new ArgumentNullException(nameof(commandsLogic));
        }
        #endregion

        #region Interface
        public BoardAction TranslateAction(CommandTypes type, 
                                            int? X = null, 
                                            int? Y = null, 
                                            char? F = null)
        {
            return Translate(type, X, Y, F);
        }

        public BoardPosition TranslatePosition(CommandTypes type,
                                            int? X = null,
                                            int? Y = null,
                                            char? F = null)
        {
            return TranslateBoardPosition(type, X, Y, F);
        }
        #endregion

        #region Private
        private BoardAction Translate(CommandTypes type,
                                            int? XBlock = null,
                                            int? YBlock = null,
                                            char? F = null)
        {
            //INFO: all actions created as executable - validation further down the chain
            BoardAction ret = new BoardAction() { CommandType = type, IsExecutable = true };

            switch(type)
            {
                case CommandTypes.PLACE:
                    ret.Position = CommandsLogic.GetPlacePosition(XBlock.Value, YBlock.Value, F.Value);
                    break;
                case CommandTypes.MOVE:
                case CommandTypes.LEFT:
                case CommandTypes.RIGHT:
                case CommandTypes.REPORT:
                    ret.Position = null;
                    break;
            }

            return ret;
        }

        private BoardPosition TranslateBoardPosition(CommandTypes type,
                                            int? XBlock = null,
                                            int? YBlock = null,
                                            char? F = null)
        {
            BoardPosition ret = null;

            switch (type)
            {
                case CommandTypes.PLACE:
                    ret = CommandsLogic.GetPlacePosition(XBlock.Value, YBlock.Value, F.Value);
                    break;
                case CommandTypes.MOVE:
                    ret = CommandsLogic.GetMovePosition();
                    break;
                case CommandTypes.LEFT:
                    ret = CommandsLogic.GetLeftPosition();
                    break;
                case CommandTypes.RIGHT:
                    ret = CommandsLogic.GetRightPosition();
                    break;
                case CommandTypes.REPORT:
                    ret = null;
                    break;
            }

            return ret;
        }
        #endregion
    }
}

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MojoRobo.Common.Constants;
using MojoRobo.Common.Enums;
using MojoRobo.Common.Interfaces;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;

namespace MojoRobo.Core
{
    public class UIBoardManager : IUIBoardManager
    {
        #region Properties
        private IBoardStatus BoardStatus { get; set; }
        private IRobotStatus RobotStatus { get; set; }
        private IActionsManager ActionsManager { get; set; }
        private IActionsValidationManager ActionsValidationManager { get; set; }
        private IActionsTranslator ActionsTranslator { get; set; }
        private IActionsExecutionManager ActionsExecutionManager { get; set; }
        #endregion

        #region Constructor
        public UIBoardManager(IBoardStatus boardStatus,
                        IRobotStatus robotStatus,
                        IActionsManager actionsManager,
                        IActionsValidationManager actionsValidationManager,
                        IActionsExecutionManager actionsExecutionManager,
                        IActionsTranslator actionsTranslator)
        {
            BoardStatus = boardStatus ?? throw new ArgumentNullException(nameof(boardStatus));
            RobotStatus = robotStatus ?? throw new ArgumentNullException(nameof(robotStatus));
            ActionsManager = actionsManager ?? throw new ArgumentNullException(nameof(actionsManager));
            ActionsValidationManager = actionsValidationManager ?? throw new ArgumentNullException(nameof(actionsValidationManager));
            ActionsExecutionManager = actionsExecutionManager ?? throw new ArgumentNullException(nameof(actionsExecutionManager));
            ActionsTranslator = actionsTranslator ?? throw new ArgumentNullException(nameof(actionsTranslator));
        }
        #endregion

        #region Interface
        public void DrawGrid()
        {
            Graphics g = BoardStatus.GetBoardPanel().CreateGraphics();
            Pen p = new Pen(Color.Black, Globals.GridLineWeight);
            int blockSize = BoardStatus.GetBlockSize();

            for (int x = 0; x < Globals.BlockCount; x++)
            {
                for (int y = 0; y < Globals.BlockCount; y++)
                {
                    g.DrawRectangle(
                        Pens.Black,
                        x * blockSize,
                        y * blockSize,
                        blockSize,
                        blockSize);
                }
            }
            g.Dispose();
        }

        public void Place(string XBlock, string YBlock, string F)
        {
            var validationMsgs = ActionsValidationManager.ValidatePlaceInput(XBlock, YBlock, F);
            if (validationMsgs != null)
            {
                MessageBox.Show(string.Join(",\n", validationMsgs.ToArray()), 
                                "Unexpected input", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation);
                return;
            }

            int.TryParse(XBlock, out int xBlock);
            int.TryParse(YBlock, out int yBlock);
            char.TryParse(F, out char f);

            RegisterAction(CommandTypes.PLACE,
                            XBlock: xBlock,
                            YBlock: yBlock,
                            F: f);
        }

        public void Left()
        {
            RegisterAction(CommandTypes.LEFT);
        }

        public void Right()
        {
            RegisterAction(CommandTypes.RIGHT);
        }

        public void Move()
        {
            RegisterAction(CommandTypes.MOVE);
        }

        public void Execute()
        {
            ActionsExecutionManager.Execute();
        }
        #endregion

        #region Private
        private void RegisterAction(CommandTypes type, 
                                    int? XBlock = null, 
                                    int? YBlock = null, 
                                    char? F = null)
        {
            BoardAction action = ActionsTranslator.TranslateAction(type, XBlock, YBlock, F);
            ActionsManager.RegisterAction(action);
        }
        #endregion
    }
}

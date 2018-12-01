using MojoRobo.Common.Constants;
using MojoRobo.Core.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MojoRobo.Core
{
    public class UIManager : IUIManager
    {
        #region Properties
        private IBoardStatus BoardStatus { get; set; }
        private IActionsManager ActionsManager { get; set; }
        private IActionsValidationManager ActionsValidationManager { get; set; }
        #endregion

        #region Constructor
        public UIManager(IBoardStatus boardStatus,
                        IActionsManager actionsManager,
                        IActionsValidationManager actionsValidationManager)
        {
            BoardStatus = boardStatus ?? throw new ArgumentNullException(nameof(boardStatus));
            ActionsManager = actionsManager ?? throw new ArgumentNullException(nameof(actionsManager));
            ActionsValidationManager = actionsValidationManager ?? throw new ArgumentNullException(nameof(actionsValidationManager));
        }
        #endregion

        #region Interface
        public void DrawGrid(Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            Pen p = new Pen(Color.Black, UIGlobals.GridLineWeight);
            int blockSize = BoardStatus.GetBlockSize();

            for (int x = 0; x < UIGlobals.BlockCount; x++)
            {
                for (int y = 0; y < UIGlobals.BlockCount; y++)
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

        public void Place(string X, string Y, string F)
        {
            var validationMsgs = ActionsValidationManager.ValidatePlaceInput(X, Y, F);
            if (validationMsgs != null)
            {
                MessageBox.Show(string.Join(",\n", validationMsgs.ToArray()), 
                                "Unexpected input", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Exclamation);
                return;
            }

            int.TryParse(X, out int x);
            int.TryParse(Y, out int y);
            char.TryParse(F, out char f);
        }

        public void Left()
        {
            throw new NotImplementedException();
        }

        public void Right()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

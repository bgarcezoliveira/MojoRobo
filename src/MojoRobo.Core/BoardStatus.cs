using MojoRobo.Common.Constants;
using MojoRobo.Common.Interfaces;
using MojoRobo.Common.Models;
using System.Windows.Forms;

namespace MojoRobo.Core
{
    public class BoardStatus : IBoardStatus
    {
        #region Properties
        private int BlockSize { get; set; }
        private int Offset { get; set; }
        private Boundary XBoundaries { get; set; }
        private Boundary YBoundaries { get; set; }
        private Dimension BoardDimension { get; set; }
        private Dimension RobotDimension { get; set; }
        private Panel BoardPanel { get; set; }
        #endregion

        #region Constructor
        public BoardStatus()
        {

        }
        #endregion

        #region Interface
        public void Update(int boardPanelWidth, 
                            int boardPanelHeight, 
                            int roboPanelWidth, 
                            Panel boardPanel)
        {
            BlockSize = boardPanelWidth / Globals.BlockCount;
            Offset = (BlockSize / 2) - (roboPanelWidth / 2);
            XBoundaries = new Boundary() { Min = 0, Max = boardPanelWidth };
            YBoundaries = new Boundary() { Min = 0, Max = boardPanelHeight };
            BoardDimension = new Dimension() { Width = boardPanelWidth, Height = boardPanelHeight };
            RobotDimension = new Dimension() { Width = roboPanelWidth, Height = roboPanelWidth };
            BoardPanel = boardPanel;
        }

        public int GetBlockSize()
        {
            return BlockSize;
        }

        public int GetOffset()
        {
            return Offset;
        }

        public Boundary GetXBoundaries()
        {
            return XBoundaries;
        }

        public Boundary GetYBoundaries()
        {
            return YBoundaries;
        }

        public Dimension GetBoardDimension()
        {
            return BoardDimension;
        }

        public Dimension GetRobotDimension()
        {
            return RobotDimension;
        }

        public Panel GetBoardPanel()
        {
            return BoardPanel;
        }
        #endregion
    }
}

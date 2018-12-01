using MojoRobo.Common.Constants;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojoRobo.Core
{
    public class BoardStatus : IBoardStatus
    {
        #region Properties
        private int BlockSize { get; set; }
        private int Offset { get; set; }
        private Boundary XBoundaries { get; set; }
        private Boundary YBoundaries { get; set; }
        #endregion

        #region Constructor
        public BoardStatus()
        {

        }
        #endregion

        #region Interface
        public void Update(int boardPanelWidth, int boardPanelHeight, int roboPanelWidth)
        {
            BlockSize = boardPanelWidth / UIGlobals.BlockCount;
            Offset = (BlockSize / 2) - (roboPanelWidth / 2);
            XBoundaries = new Boundary() { Min = 0, Max = boardPanelWidth };
            YBoundaries = new Boundary() { Min = 0, Max = boardPanelHeight };
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
        #endregion
    }
}

using System.Windows.Forms;
using MojoRobo.Common.Models;

namespace MojoRobo.Common.Interfaces
{
    public interface IBoardStatus
    {
        int GetBlockSize();
        int GetOffset();
        Boundary GetXBoundaries();
        Boundary GetYBoundaries();
        Dimension GetBoardDimension();
        Dimension GetRobotDimension();
        Panel GetBoardPanel();
        void Update(int boardPanelWidth, 
                    int boardPanelHeight, 
                    int roboPanelWidth,
                    Panel boardPanel);
    }
}

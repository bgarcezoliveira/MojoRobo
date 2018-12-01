using MojoRobo.Common.Models;

namespace MojoRobo.Core.Interfaces
{
    public interface IBoardStatus
    {
        int GetBlockSize();
        int GetOffset();
        Boundary GetXBoundaries();
        Boundary GetYBoundaries();
        void Update(int boardPanelWidth, int boardPanelHeight, int roboPanelWidth);
    }
}

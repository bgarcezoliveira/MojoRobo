using System.Windows.Forms;

namespace MojoRobo.Core.Interfaces
{
    public interface IUIBoardManager
    {
        void DrawGrid();
        void Place(string XBlock, string YBlock, string F);
        void Left();
        void Right();
        void Move();
        void Execute();
    }
}

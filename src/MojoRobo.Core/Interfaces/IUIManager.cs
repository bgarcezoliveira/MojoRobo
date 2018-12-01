using System.Windows.Forms;

namespace MojoRobo.Core.Interfaces
{
    public interface IUIManager
    {
        void DrawGrid(Panel panel);
        void Place(string X, string Y, string F);
        void Left();
        void Right();
        void Move();
    }
}

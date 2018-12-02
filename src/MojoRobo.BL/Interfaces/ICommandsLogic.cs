using MojoRobo.Common.Models;

namespace MojoRobo.BL.Interfaces
{
    public interface ICommandsLogic
    {
        BoardPosition GetPlacePosition(int XBlock, int YBlock, char F);
        BoardPosition GetMovePosition();
        BoardPosition GetLeftPosition();
        BoardPosition GetRightPosition();
    }
}

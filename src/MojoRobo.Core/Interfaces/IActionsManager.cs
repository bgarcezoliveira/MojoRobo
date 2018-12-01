using MojoRobo.Common.Models;

namespace MojoRobo.Core.Interfaces
{
    public interface IActionsManager
    {
        void RegisterAction(BoardAction action);
        void ClearActions();
    }
}

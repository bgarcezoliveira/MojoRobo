using System.Collections.Generic;
using MojoRobo.Common.Models;

namespace MojoRobo.Core.Interfaces
{
    public interface IActionsManager
    {
        void RegisterAction(BoardAction action);
        void ClearActions();
        //INFO: positionValidation false by default as the UI enforces correct input
        IEnumerable<BoardAction> GetActions(bool validate = true);
    }
}

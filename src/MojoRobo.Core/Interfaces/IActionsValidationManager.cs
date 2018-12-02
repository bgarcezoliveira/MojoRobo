using System.Collections.Generic;
using MojoRobo.Common.Models;

namespace MojoRobo.Core.Interfaces
{
    public interface IActionsValidationManager
    {
        IEnumerable<string> ValidatePlaceInput(string XBlock, string YBlock, string F);
        void ValidateActions(IEnumerable<BoardAction> actions);
        void ValidateAction(BoardAction action);
    }
}

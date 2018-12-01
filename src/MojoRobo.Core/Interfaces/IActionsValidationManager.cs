using System.Collections.Generic;
using MojoRobo.Common.Models;

namespace MojoRobo.Core.Interfaces
{
    public interface IActionsValidationManager
    {
        IEnumerable<string> ValidatePlaceInput(string X, string Y, string F);
        bool ValidateActions(IEnumerable<BoardAction> actions);
    }
}

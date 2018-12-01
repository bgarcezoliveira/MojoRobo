using MojoRobo.Core.Interfaces;
using MojoRobo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojoRobo.Core
{
    public class ActionsManager : IActionsManager
    {
        #region Properties
        IActionsValidationManager ActionsValidationManager { get; set; }
        private List<BoardAction> Actions { get; set; }
        #endregion

        #region Constructor
        public ActionsManager(IActionsValidationManager actionValidationManager)
        {
            ActionsValidationManager = actionValidationManager ?? throw new ArgumentNullException(nameof(actionValidationManager));
            Actions = new List<BoardAction>();
        }
        #endregion

        #region Interface
        public void RegisterAction(BoardAction action)
        {
            Actions.Add(action);
        }

        public void ClearActions()
        {
            Actions.Clear();
        }
        #endregion

        #region Private
        private bool ValidateActions()
        {
            return ActionsValidationManager.ValidateActions(Actions);
        }
        #endregion
    }
}

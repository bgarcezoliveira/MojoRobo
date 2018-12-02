using System;
using System.Collections.Generic;
using MojoRobo.Core.Interfaces;
using MojoRobo.Common.Models;
using MojoRobo.Common.Interfaces;

namespace MojoRobo.Core
{
    public class ActionsManager : IActionsManager
    {
        #region Properties
        IActionsValidationManager ActionsValidationManager { get; set; }
        ILogger Logger { get; set; }
        public List<BoardAction> Actions { get; set; }
        #endregion

        #region Constructor
        public ActionsManager(IActionsValidationManager actionValidationManager,
                                ILogger logger)
        {
            ActionsValidationManager = actionValidationManager ?? throw new ArgumentNullException(nameof(actionValidationManager));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Actions = new List<BoardAction>();
        }
        #endregion

        #region Interface
        public void RegisterAction(BoardAction action)
        {
            Logger.LogRegisterAction(action);
            Actions.Add(action);
        }

        public void ClearActions()
        {
            Actions.Clear();
        }

        public IEnumerable<BoardAction> GetActions(bool validate = true)
        {
            if (validate)
            {
                ActionsValidationManager.ValidateActions(Actions);
            }

            return Actions;
        }
        #endregion
        
    }
}

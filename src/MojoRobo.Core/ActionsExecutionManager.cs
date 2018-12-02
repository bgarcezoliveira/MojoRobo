using System;
using System.Linq;
using System.Windows.Forms;
using MojoRobo.Common.Enums;
using MojoRobo.Common.Interfaces;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;

namespace MojoRobo.Core
{
    public class ActionsExecutionManager : IActionsExecutionManager
    {
        #region Properties
        private IActionsManager ActionsManager { get; set; }
        private IActionsValidationManager ActionsValidationManager { get; set; }
        private IActionsTranslator ActionsTranslator { get; set; }
        private IRobotStatus RobotStatus { get; set; }
        private IUIRobotManager UIRobotManager { get; set; }
        private ILogger Logger { get; set; }
        #endregion

        #region Constructor
        public ActionsExecutionManager(IActionsManager actionsManager,
                                        IActionsValidationManager actionsValidationManager,
                                        IActionsTranslator actionsTranslator,
                                        IRobotStatus robotStatus,
                                        IUIRobotManager uiRobotManager,
                                        ILogger logger)
        {
            ActionsManager = actionsManager ?? throw new ArgumentNullException(nameof(actionsManager));
            ActionsValidationManager = actionsValidationManager ?? throw new ArgumentNullException(nameof(actionsValidationManager));
            ActionsTranslator = actionsTranslator ?? throw new ArgumentNullException(nameof(actionsTranslator));
            RobotStatus = robotStatus ?? throw new ArgumentNullException(nameof(robotStatus));
            UIRobotManager = uiRobotManager ?? throw new ArgumentNullException(nameof(uiRobotManager));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Interface
        public void Execute()
        {
            var actions = ActionsManager.GetActions();

            if (actions.Count() == 0)
            {
                MessageBox.Show("No actions to execute",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            Logger.LogExecutionStart();

            foreach (var action in actions)
            {
                if (!action.IsExecutable)
                {
                    Logger.LogExecution(action);
                    continue;
                }

                if (action.CommandType == CommandTypes.PLACE)
                { 
                    if (!RobotStatus.GetIsPlaced())
                    {
                        RobotStatus.SetIsPlaced(true);
                    }
                }
                else if (action.Position == null)
                {
                    action.Position = ActionsTranslator.TranslatePosition(action.CommandType);

                    if (action.CommandType == CommandTypes.MOVE)
                    {
                        ActionsValidationManager.ValidateAction(action);

                        if (!action.IsExecutable)
                        {
                            Logger.LogExecution(action);
                            continue;
                        }
                    }
                }

                Logger.LogExecution(action);
                RobotStatus.Update(position: action.Position);
                UIRobotManager.Update();
            }

            ActionsManager.ClearActions();
            Logger.LogExecutionEnd();
        }
        #endregion
    }
}

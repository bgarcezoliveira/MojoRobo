using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using MojoRobo.BL;
using MojoRobo.BL.Interfaces;
using MojoRobo.Core;
using MojoRobo.Core.Interfaces;
using MojoRobo.Common.Interfaces;

namespace MojoRobo.UI
{
    static class Init
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var unityContainer = BuildContainer();
            Application.Run(unityContainer.Resolve<Form>());
        }

        static IUnityContainer BuildContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<Form, Board>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionsManager, ActionsManager>(new PerResolveLifetimeManager());
            container.RegisterType<IActionsValidationManager, ActionsValidationManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionsTranslator, ActionsTranslator>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionsExecutionManager, ActionsExecutionManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IBoardStatus, BoardStatus>(new PerResolveLifetimeManager());
            container.RegisterType<IRobotStatus, RobotStatus>(new PerResolveLifetimeManager());
            container.RegisterType<IUIBoardManager, UIBoardManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IUIRobotManager, UIRobotManager>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommandsLogic, CommandsLogic>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogger, Logger>(new PerResolveLifetimeManager());
            return container;
        }
    }
}

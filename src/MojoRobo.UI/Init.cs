using MojoRobo.Core;
using MojoRobo.Core.Interfaces;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

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
            container.RegisterType<IActionsManager, ActionsManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IActionsValidationManager, ActionsValidationManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IBoardStatus, BoardStatus>(new PerResolveLifetimeManager());
            container.RegisterType<IRobotStatus, RobotStatus>(new PerResolveLifetimeManager());
            container.RegisterType<IUIManager, UIManager>(new HierarchicalLifetimeManager());
            return container;
        }
    }
}

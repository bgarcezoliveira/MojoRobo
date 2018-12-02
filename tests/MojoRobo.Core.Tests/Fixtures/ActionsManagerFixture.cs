using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojoRobo.Common.Interfaces;
using MojoRobo.Core.Fakes;
using MojoRobo.Core.Interfaces;
using MojoRobo.Core.Interfaces.Fakes;

namespace MojoRobo.Core.Tests.Fixtures
{
    public class ActionsManagerFixture
    {
        private IActionsValidationManager _actionsValidationManager = null;
        private StubLogger _logger = null;
        private IRobotStatus _robotStatus = null;
        private IBoardStatus _boardStatus = null;

        public ActionsManagerFixture()
        {
            this._robotStatus = new StubRobotStatus();
            this._boardStatus = new StubBoardStatus();
        }

        public IActionsManager Build()
        {
            return new ActionsManager(_actionsValidationManager, _logger);
        }

        internal ActionsManagerFixture WithValidActionsValidationManager()
        {
            this._actionsValidationManager = new StubActionsValidationManager(_robotStatus, _boardStatus);
            return this;
        }

        internal ActionsManagerFixture WithValidLogger()
        {
            this._logger = new StubLogger();
            var shimLogger = new ShimLogger(this._logger);
            shimLogger.LogRegisterActionBoardAction = (action) => { }; 
            return this;
        }

    }
}

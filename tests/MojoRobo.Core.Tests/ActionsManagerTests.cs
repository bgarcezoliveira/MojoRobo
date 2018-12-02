using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojoRobo.Common.Enums;
using MojoRobo.Common.Models;
using MojoRobo.Core.Interfaces;
using MojoRobo.Core.Tests.Fixtures;
using System;
using System.Linq;

namespace MojoRobo.Core.Tests
{
    [TestClass]
    public class ActionsManagerTests
    {
        public IDisposable _context = null;

        [TestInitialize]
        public void TestInit()
        {
            _context = ShimsContext.Create();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _context.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ActionsManagerInit_WO_ActionValidationManager_Dependency()
        {
            var sut = new ActionsManagerFixture().Build();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ActionsManagerInit_WO_Logger_Dependency()
        {
            var sut = new ActionsManagerFixture()
                                .WithValidActionsValidationManager()
                                .Build();
        }

        [TestMethod]
        public void ActionsManagerInit_W_Dependenies()
        {
            var sut = new ActionsManagerFixture()
                                .WithValidActionsValidationManager()
                                .WithValidLogger()
                                .Build();

            Assert.IsNotNull(sut);
            Assert.IsInstanceOfType(sut, typeof(IActionsManager));
        }

        [TestMethod]
        public void ActionsManager_RegisterAction_NoValidation()
        {
            var sut = new ActionsManagerFixture()
                                .WithValidActionsValidationManager()
                                .WithValidLogger()
                                .Build();

            var input = new BoardAction()
            {
                CommandType =
                CommandTypes.LEFT,
                IsExecutable = true,
                Position = new BoardPosition()
                {
                    Direction = InternalDirections.NORTH1,
                    X = 0,
                    XBlock = 0,
                    Y = 1,
                    YBlock = 1
                }
            };

            sut.RegisterAction(input);

            int expectedCount = 1;

            Assert.AreEqual(sut.GetActions(validate: false).Count(), expectedCount);
        }
    }
}

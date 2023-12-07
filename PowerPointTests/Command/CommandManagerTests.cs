using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass]
    public class CommandManagerTests
    {
        Shapes _list = null;
        CommandManager _manager = null;
        PrivateObject _managerPrivate = null;

        [TestInitialize]
        public void Initialize()
        {
            _list = new Shapes();
            _manager = new CommandManager(_list);
            _managerPrivate = new PrivateObject(_manager);
        }

        [TestMethod]
        public void CommandManagerTest()
        {
            Assert.AreEqual(_list, _managerPrivate.GetFieldOrProperty("_list"));
        }

        [TestMethod]
        public void ExecuteTest()
        {
            _list.AddRandomShape(ShapeType.Circle, 800, 600);
            _manager.Execute(new MoveCommand
            {
                SelectShape = _list[0]
            });
            const int dx = 100;
            MoveCommand cmd = new MoveCommand
            {
                CombinePreviousCommand = true,
                SelectShape = _list[0],
                MoveX = dx
            };
            _manager.Execute(cmd);
            Assert.AreEqual(1, _list.Count);
            var undoStack = (Stack<ICommand>)_managerPrivate.GetFieldOrProperty("_undo");
            Assert.AreEqual(dx, ((MoveCommand)undoStack.Peek()).MoveX);
        }

        [TestMethod]
        public void CanUndoTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void UndoTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CanRedoTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void RedoTest()
        {
            Assert.Fail();
        }
    }
}
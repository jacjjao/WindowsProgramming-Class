using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            Assert.IsFalse(_manager.CanUndo());
            _manager.Execute(new MoveCommand
            {
            });
            Assert.IsTrue(_manager.CanUndo());
        }

        [TestMethod]
        public void UndoTest()
        {
            var undoStack = (Stack<ICommand>)_managerPrivate.GetFieldOrProperty("_undo");
            _manager.Undo();
            Assert.AreEqual(0, undoStack.Count);
            _manager.Execute(new MoveCommand());
            _manager.Undo();
            Assert.AreEqual(0, undoStack.Count);
        }

        [TestMethod]
        public void CanRedoTest()
        {
            Assert.IsFalse(_manager.CanRedo());
            var redoStack = (Stack<ICommand>)_managerPrivate.GetFieldOrProperty("_redo");
            redoStack.Push(new MoveCommand());
            Assert.IsTrue(_manager.CanRedo());
        }

        [TestMethod]
        public void RedoTest()
        {
            var redoStack = (Stack<ICommand>)_managerPrivate.GetFieldOrProperty("_redo");
            _manager.Redo();
            Assert.AreEqual(0, redoStack.Count);
            _manager.Execute(new MoveCommand());
            _manager.Undo();
            _manager.Redo();
            Assert.AreEqual(0, redoStack.Count);
        }
    }
}
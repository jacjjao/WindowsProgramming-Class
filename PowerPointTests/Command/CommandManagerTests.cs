using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerPoint.Tests
{
    [TestClass]
    public class CommandManagerTests
    {
        Page _list = null;
        CommandManager _manager = null;
        PrivateObject _managerPrivate = null;

        // test
        [TestInitialize]
        public void Initialize()
        {
            _list = new Page();
            _manager = new CommandManager(_list);
            _managerPrivate = new PrivateObject(_manager);
        }

        // test
        [TestMethod]
        public void CommandManagerTest()
        {
            Assert.AreEqual(_list, _managerPrivate.GetFieldOrProperty("_list"));
        }

        // test
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
                SelectShape = _list[0],
                MoveX = dx
            };
            var option = new ExecuteOption
            {
                CombineWithPreviousCommand = true,
                ResetDataBindings = true
            };
            _manager.Execute(cmd, option);
            Assert.AreEqual(1, _list.Count);
            var undoStack = (Stack<ICommand>)_managerPrivate.GetFieldOrProperty("_undo");
            Assert.AreEqual(dx, ((MoveCommand)undoStack.Peek()).MoveX);
        }

        // test
        [TestMethod]
        public void CanUndoTest()
        {
            Assert.IsFalse(_manager.IsCanUndo());
            _manager.Execute(new MoveCommand
            {
            });
            Assert.IsTrue(_manager.IsCanUndo());
        }

        // test
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

        // test
        [TestMethod]
        public void CanRedoTest()
        {
            Assert.IsFalse(_manager.IsCanRedo());
            var redoStack = (Stack<ICommand>)_managerPrivate.GetFieldOrProperty("_redo");
            redoStack.Push(new MoveCommand());
            Assert.IsTrue(_manager.IsCanRedo());
        }

        // test
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PowerPoint.Tests
{
    [TestClass]
    public class CommandManagerTests
    {
        Page _page = null;
        CommandManager _manager = null;
        PrivateObject _managerPrivate = null;

        // test
        [TestInitialize]
        public void Initialize()
        {
            _page = new Page();
            _manager = new CommandManager(_page);
            _managerPrivate = new PrivateObject(_manager);
        }

        // test
        [TestMethod]
        public void CommandManagerTest()
        {
            Assert.AreEqual(_page, _managerPrivate.GetFieldOrProperty("_page"));
        }

        // test
        [TestMethod]
        public void ExecuteTest()
        {
            _page.AddRandomShape(ShapeType.Circle, 800, 600);
            _manager.Execute(new MoveCommand
            {
                SelectShape = _page[0]
            });
            const int dx = 100;
            MoveCommand cmd = new MoveCommand
            {
                SelectShape = _page[0],
                MoveX = dx
            };
            var option = new ExecuteOption
            {
                CombineWithPreviousCommand = true,
                ResetDataBindings = true
            };
            _manager.Execute(cmd, option);
            Assert.AreEqual(1, _page.Count);
            var undoStack = (Stack<Tuple<Page, ICommand>>)_managerPrivate.GetFieldOrProperty("_undo");
            Assert.AreEqual(dx, ((MoveCommand)undoStack.Peek().Item2).MoveX);
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
            var undoStack = (Stack<Tuple<Page, ICommand>>)_managerPrivate.GetFieldOrProperty("_undo");
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
            var redoStack = (Stack<Tuple<Page, ICommand>>)_managerPrivate.GetFieldOrProperty("_redo");
            redoStack.Push(Tuple.Create(_page, (ICommand)new MoveCommand()));
            Assert.IsTrue(_manager.IsCanRedo());
        }

        // test
        [TestMethod]
        public void RedoTest()
        {
            var redoStack = (Stack<Tuple<Page, ICommand>>)_managerPrivate.GetFieldOrProperty("_redo");
            _manager.Redo();
            Assert.AreEqual(0, redoStack.Count);
            _manager.Execute(new MoveCommand());
            _manager.Undo();
            _manager.Redo();
            Assert.AreEqual(0, redoStack.Count);
        }
    }
}
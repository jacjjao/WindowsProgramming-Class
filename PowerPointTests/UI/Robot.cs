using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;

namespace PowerPointUITests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            // options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = targetAppPath;
            Process.Start(start);
            Thread.Sleep(1000);
            var processes = Process.GetProcessesByName(root);
            options.AddAdditionalCapability("appTopLevelWindow", processes[0].MainWindowHandle.ToString("x"));
            
            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void KeyInputString(string name, string str)
        {
            var element = _driver.FindElementByName(name);
            element.SendKeys(str);
        }

        // test
        public void MouseDownAndMoveThenUp(string elementName, int x, int y, int dx, int dy)
        {
            Actions action = new Actions(_driver);
            var element = _driver.FindElementByName(elementName);
            action
                .MoveToElement(element)
                .MoveByOffset(-element.Size.Width / 2, -element.Size.Height / 2)
                .MoveByOffset(x, y)
                .ClickAndHold()
                .MoveByOffset(dx, dy)
                .Release()
                .Perform();
        }

        // test
        public void Click(int x, int y)
        {
            var drawPanel = _driver.FindElementByName("DrawPanel");
            Actions action = new Actions(_driver);
            action
                .MoveToElement(drawPanel)
                .MoveByOffset(-drawPanel.Size.Width / 2, -drawPanel.Size.Height / 2)
                .MoveByOffset(x, y)
                .Click()
                .Perform();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(int rowIndex, string columnName)
        {
            _driver.FindElementByName($"{columnName} {rowIndex}").Click();
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertText(string name, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(name);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertToolStripButtonChecked(string name)
        {
            var element = _driver.FindElementByName(name);
            const string MAGIC_NUMBER_WHEN_BUTTON_IS_CHECKED = "1048724";
            Assert.AreEqual(MAGIC_NUMBER_WHEN_BUTTON_IS_CHECKED, element.GetAttribute("LegacyState"));
        }

        // test
        public void AssertToolStripButtonUnchecked(string name)
        {
            var element = _driver.FindElementByName(name);
            const string MAGIC_NUMBER_WHEN_BUTTON_IS_UNCHECKED = "1048576";
            Assert.AreEqual(MAGIC_NUMBER_WHEN_BUTTON_IS_UNCHECKED, element.GetAttribute("LegacyState"));
        }

        // test
        public void AssertDataGridViewShapeCells(string name, int rowIndex, string data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"形狀 Row {rowIndex}");
            Assert.AreEqual(data, rowDatas.Text);
        }

        // test
        public System.Drawing.Size GetElementSize(string name)
        {
            var element = _driver.FindElementByName(name);
            return element.Size;
        }

        // test
        private List<int> ParseInfo(string info)
        {
            var num = new StringBuilder();
            var result = new List<int>();
            foreach (char c in info)
            {
                if (!char.IsDigit(c))
                {
                    if (num.Length > 0)
                        result.Add(int.Parse(num.ToString()));
                    num.Clear();
                }
                else
                    num.Append(c);
            }
            return result;
        }

        // test
        private void AssertNearlyEqual(List<int> a, List<int> b)
        {
            Assert.IsTrue(a.Count > 0);
            Assert.AreEqual(a.Count, b.Count);
            const int epsilon = 2;
            for (int i = 0; i < a.Count; i++)
            {
                Assert.IsTrue(Math.Abs(a[i] - b[i]) <= epsilon);
            }
        }

        // 因為不明原因Robot移動滑鼠游標到指定的Coordinate有時會有1~2 pixels的小誤差
        public void AssertDataGridViewInfoCells(string name, int rowIndex, string data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資訊 Row {rowIndex}");
            AssertNearlyEqual(ParseInfo(data), ParseInfo(rowDatas.Text));
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
    }
}

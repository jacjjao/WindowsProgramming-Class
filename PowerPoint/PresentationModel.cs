using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public class PresentationModel
    {
        public delegate void CheckListChangedEventHandler();
        public event CheckListChangedEventHandler _checkListChanged;

        public const int TOOL_STRIP_BUTTON_COUNT = 4;

        public List<bool> CheckList
        {
            get;
        }

        public PowerPointModel Model
        {
            get;
        }

        public PresentationModel(PowerPointModel model)
        {
            Model = model;
            CheckList = new List<bool>(new bool[TOOL_STRIP_BUTTON_COUNT]);
        }

        /* 更新toolstrip button上的Checked屬性 */
        public ShapeType DoToolStripButtonClick(int index, ShapeType type)
        {
            for (int i = 0; i < CheckList.Count; i++)
            {
                if (i == index)
                {
                    CheckList[i] = !CheckList[i];
                }
                else
                {
                    CheckList[i] = false;
                }
            }
            type = CheckList[index] ? type : ShapeType.None;
            Model.State.SelectShapeType(type);
            DoListChange();
            return type;
        }

        /* add shape */
        public void AddShape(ShapeType type)
        {
            Model.AddShape(type);
        }

        /* remove at */
        public void RemoveAt(int index)
        {
            Model.RemoveAt(index);
        }

        /* get draw pen */
        public Pen GetDrawPen()
        {
            return Model.DrawPen;
        }

        /* 畫出所有形狀 */
        public void DrawAll(IGraphics graphics)
        {
            Model.DrawAll(graphics);
        }

        /* 在draw panel上按下滑鼠的event */
        public void DoMouseDown(MouseEventArgs e)
        {
            Model.DoMouseDown(e);
        }

        /* 滑鼠在draw panel移動時的event */
        public void DoMouseMove(MouseEventArgs e)
        {
            Model.DoMouseMove(e);
        }

        /* 在draw panel上放開滑鼠按鈕的event */
        public void DoMouseUp(MouseEventArgs e)
        {
            Model.DoMouseUp(e);
            for (int i = 0; i < CheckList.Count; i++)
            {
                CheckList[i] = false;
            }
            DoListChange();
        }

        /* fire event */
        private void DoListChange()
        {
            if (_checkListChanged != null)
            {
                _checkListChanged();
            }
        }
    }
}
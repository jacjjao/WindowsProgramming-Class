using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PresentationModel
    {
        public ShapeType SelectedShapeType
        {
            get;
            set;
        }

        public Pen DrawPen
        {
            get;
            set;
        }

        public List<bool> CheckList
        {
            get;
        }

        public PowerPointModel Model
        {
            get;
        }

        private Point _drawStartPos;
        private Point _drawEndPos;
        private bool _mousePressed = false;

        public PresentationModel(PowerPointModel model)
        {
            Model = model;
            SelectedShapeType = ShapeType.None;
            const float WIDTH = 1.0f;
            DrawPen = new Pen(Color.Red, WIDTH);
            CheckList = new List<bool>(new bool[Form1.TOOL_STRIP_BUTTON_COUNT]);
        }

        /* 更新toolstrip button上的Checked屬性 */
        public void DoToolStripButtonClick(int index, ShapeType type)
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
            SelectedShapeType = CheckList[index] ? type : ShapeType.None;
        }

        /* 畫出所有形狀 */
        public void DrawAll(Graphics graphics)
        {
            Model.DrawAll(graphics, DrawPen);
        }

        /* 在draw panel上放開滑鼠按鈕的event */
        public void DoMouseUp(MouseEventArgs e, List<ToolStripButton> list)
        {
            if (!_mousePressed)
                return;
            _mousePressed = false;
            _drawEndPos = e.Location;
            Model.ShapesList[Model.ShapesList.Count - 1] = Model.CreateShape(SelectedShapeType, _drawStartPos, _drawEndPos);
            SelectedShapeType = ShapeType.None;
            list.ForEach((button) => button.Checked = false);
        }

        /* 滑鼠在draw panel移動時的event */
        public void DoMouseMove(MouseEventArgs e)
        {
            if (!_mousePressed)
            {
                return;
            }
            _drawEndPos = e.Location;
            Model.ShapesList[Model.ShapesList.Count - 1] = Model.CreateShape(SelectedShapeType, _drawStartPos, _drawEndPos);
        }

        /* 在draw panel上按下滑鼠的event */
        public void DoMouseDown(MouseEventArgs e)
        {
            if (SelectedShapeType == ShapeType.None)
            {
                return;
            }
            _mousePressed = true;
            _drawStartPos = _drawEndPos = e.Location;
            Model.AddShape(SelectedShapeType, _drawStartPos, _drawEndPos);
        }
    }
}
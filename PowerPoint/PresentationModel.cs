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

        public readonly Model _model;

        private Point _drawStartPos;
        private Point _drawEndPos;
        private bool _mousePressed = false;

        public PresentationModel(Model model)
        {
            _model = model;
            SelectedShapeType = ShapeType.None;
            const float WIDTH = 1.0f;
            DrawPen = new Pen(Color.Red, WIDTH);
        }

        /* 更新toolstrip button上的Checked屬性 */
        public void DoToolStripButtonClick(object clickedButton, List<ToolStripButton> list, ShapeType type)
        {
            foreach (var button in list)
            {
                if (!button.Equals(clickedButton))
                {
                    button.Checked = false;
                }
                else
                {
                    button.Checked = !(button.Checked);
                    SelectedShapeType = button.Checked ? type : ShapeType.None;
                }
            }
        }

        /* 畫出所有形狀 */
        public void DrawAll(Graphics graphics)
        {
            for (int i = 0; i < _model.ShapesList.Count; i++)
            {
                _model.ShapesList[i].Draw(graphics, DrawPen);
            }
        }

        /* 在draw panel上放開滑鼠按鈕的event */
        public void DoMouseUp(MouseEventArgs e, List<ToolStripButton> list)
        {
            if (!_mousePressed)
                return;
            _mousePressed = false;
            _drawEndPos = e.Location;
            _model.ShapesList[_model.ShapesList.Count - 1] = _model.CreateShape(SelectedShapeType, _drawStartPos, _drawEndPos);
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
            _model.ShapesList[_model.ShapesList.Count - 1] = _model.CreateShape(SelectedShapeType, _drawStartPos, _drawEndPos);
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
            _model.AddShape(SelectedShapeType, _drawStartPos, _drawEndPos);
        }
    }
}
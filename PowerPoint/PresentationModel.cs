using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PresentationModel
    {
        public delegate void OnNewShapeAddedEventHandler(object sender, Shape shape);
        public event OnNewShapeAddedEventHandler _onNewShapeAdd;

        public delegate void ShouldUpdatedDataGridEventHandler(int index, Shape shape);
        public event ShouldUpdatedDataGridEventHandler _shouldUpdateDataGrid;

        public ShapeType SelectedShapeType
        {
            set;
            get;
        }

        public Pen DrawPen
        {
            set;
            get;
        }

        private readonly Model _model;

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
            _model.ShapesList.ForEach((shape) => shape.Draw(graphics, DrawPen));
        }

        /* 新增新的形狀並通知form要更新data grid */
        public void AddShape(ShapeType type)
        {
            var shape = _model.AddShape(type);
            if (_onNewShapeAdd != null)
            {
                _onNewShapeAdd.Invoke(this, shape);
            }
        }

        /* 刪除形狀 */
        public void RemoveShape(int index)
        {
            _model.ShapesList.RemoveAt(index);
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
            int last = _model.ShapesList.Count - 1;
            if (_shouldUpdateDataGrid != null)
            {
                _shouldUpdateDataGrid.Invoke(last, _model.ShapesList[last]);
            }
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
            int last = _model.ShapesList.Count - 1;
            if (_shouldUpdateDataGrid != null)
            {
                _shouldUpdateDataGrid.Invoke(last, _model.ShapesList[last]);
            }
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
            var shape = _model.AddShape(SelectedShapeType, _drawStartPos, _drawEndPos);
            if (_onNewShapeAdd != null)
            {
                _onNewShapeAdd.Invoke(this, shape);
            }
        }
    }
}
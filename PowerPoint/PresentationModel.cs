using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows;
using Point = System.Drawing.Point;

namespace PowerPoint
{
	public class PresentationModel
	{
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

		public delegate void OnNewShapeAdded(object sender, Shape shape);
		public event OnNewShapeAdded OnNewShapeAdd;

		public delegate void OnShapeRemoved(object sender, int index);
		public event OnShapeRemoved OnShapeRemove;

		private readonly Model _model;

		private Point _drawStartPos;
		private Point _drawEndPos;
		private bool _mousePressed = false;

		public PresentationModel(Model model)
		{
			SelectedShapeType = ShapeType.None;
			DrawPen = new Pen(Color.Red, 1.0f);
			_model = model;
		}

		public void OnToolStripButtonClick(object clickedButton, List<Tuple<ToolStripButton, ShapeType>> list)
        {
			foreach (var (button, shapeType) in list)
            {
				if (!clickedButton.Equals(button))
                {
					button.Checked = false;
                }
				else
                {
					button.Checked = !(button.Checked);
					SelectedShapeType = button.Checked ? shapeType : ShapeType.None;
				}
			}
		}

		public void DrawAll(System.Drawing.Graphics graphics)
        {
			_model.DrawAll(graphics, DrawPen);
        }

		public Shape AddShape(ShapeType type)
        {
			var shape = _model.AddShape(type);
            OnNewShapeAdd?.Invoke(this, shape);
            return shape;
        }

		private Shape AddShape()
        {
			var shape = _model.AddShape(SelectedShapeType, _drawStartPos, _drawEndPos);
			OnNewShapeAdd?.Invoke(this, shape);
			return shape;
		}

		public void RemoveShape(int index)
        {
			_model.ShapesList.RemoveAt(index);
			OnShapeRemove?.Invoke(this, index);
		}

		public void OnMouseUp(Point point)
		{
			if (!_mousePressed)
			{
				return;
			}
			_mousePressed = false;
			_drawEndPos = point;
			if (_model.ShapesList.Count > 0)
			{
				RemoveShape(_model.ShapesList.Count - 1);
			}
			AddShape();
		}

		public void OnMouseMove(Point point)
        {
			if (!_mousePressed)
            {
				return;
            }
			_drawEndPos = point;
			if (_model.ShapesList.Count > 0)
			{
				RemoveShape(_model.ShapesList.Count - 1);
			}
			AddShape();
		}

		public void OnMouseDown(Point point)
		{
			if (SelectedShapeType == ShapeType.None)
            {
				return;
            }
			_mousePressed = true;
			_drawStartPos = _drawEndPos = point;
			AddShape();
		}
	}
}
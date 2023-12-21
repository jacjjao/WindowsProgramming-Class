using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public class PresentationModel
    {
        public BindingList<NotifyBoolean> CheckList
        {
            get;
        }

        public PowerPointModel Model
        {
            get;
        }

        int _initialWidth = 0;
        int _initialHeight = 0;

        const float INITIAL_SCALE_VALUE = 1.0f;

        float _scaleX = INITIAL_SCALE_VALUE;
        public float DrawPanelScaleX
        {
            get
            {
                return _scaleX;
            }
        }
        public int CurrentDrawPanelWidth
        {
            set
            {
                _scaleX = (float)value / (float)_initialWidth;
            }
        }

        float _scaleY = INITIAL_SCALE_VALUE;
        public float DrawPanelScaleY
        {
            get
            {
                return _scaleY;
            }
        }
        public int CurrentDrawPanelHeight
        {
            set
            {
                _scaleY = (float)value / (float)_initialHeight;
            }
        }
        bool _sizeAssign = false;

        public PresentationModel(PowerPointModel model)
        {
            Model = model;
            CheckList = new BindingList<NotifyBoolean>()
            {
                new NotifyBoolean(),
                new NotifyBoolean(),
                new NotifyBoolean(),
                new NotifyBoolean(),
            };
        }

        /* 更新toolstrip button上的Checked屬性 */
        public ShapeType DoToolStripButtonClick(int index, ShapeType type)
        {
            for (int i = 0; i < CheckList.Count; i++)
            {
                if (i == index)
                {
                    CheckList[i].Value = !CheckList[i].Value;
                }
                else
                {
                    CheckList[i].Value = false;
                }
            }
            type = CheckList[index].Value ? type : ShapeType.None;
            Model.SelectedShape = type;
            return type;
        }

        /* transform mouse position */
        private Point TransformMousePosition(Point point)
        {
            point.X = (int)((float)point.X / DrawPanelScaleX);
            point.Y = (int)((float)point.Y / DrawPanelScaleY);
            return point;
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

        /* 在draw panel上按下滑鼠的event */
        public Cursor DoMouseDown(Point position)
        {
            return Model.DoMouseDown(TransformMousePosition(position));
        }

        /* 滑鼠在draw panel移動時的event */
        public Cursor DoMouseMove(Point position)
        {
            return Model.DoMouseMove(TransformMousePosition(position));
        }

        /* 在draw panel上放開滑鼠按鈕的event */
        public Cursor DoMouseUp(Point position)
        {
            const int THREE = 3;
            for (int i = 0; i < THREE; i++)
            {
                CheckList[i].Value = false;
            }
            return Model.DoMouseUp(TransformMousePosition(position));
        }

        /* keydown */
        public void DoKeyDown(KeyEventArgs e)
        {
            Model.DoKeyDown(e);
        }

        /* set state */
        public void SetState(IState state)
        {
            Model.State = state;
            for (int i = 0; i < Model.CurrentPage.Count; i++)
            {
                Model.CurrentPage[i].Selected = false;
            }
        }

        /* form resize時drawpanel的長寬要保持16:9 */
        private Point UpdateDrawPanelSize(int width, int height)
        {
            const float TARGET_ASPECT_RATIO = 16.0f / 9.0f;
            const int NINE = 9;
            const int SIXTEEN = 16;
            float aspectRatio = (float)width / (float)height;
            var result = new Point();
            if (aspectRatio < TARGET_ASPECT_RATIO)
            {
                result.X = width;
                result.Y = result.X * NINE / SIXTEEN;
            }
            else
            {
                result.Y = height;
                result.X = height * SIXTEEN / NINE;
            }
            return result;
        }

        /* form resize時drawpanel待在它的Container的中間 */
        private Point UpdateDrawPanelLocation(int containerWidth, int containerHeight, int panelWidth, int panelHeight)
        {
            const int TWO = 2;
            var location = new Point();
            location.X = containerWidth / TWO - panelWidth / TWO;
            location.Y = containerHeight / TWO - panelHeight / TWO;
            return location;
        }

        /* notify scaling change */
        private void NotifyScalingChange()
        {
            for (int i = 0; i < Model.CurrentPage.Count; i++)
            {
                Model.CurrentPage[i].ScaleX = DrawPanelScaleX;
                Model.CurrentPage[i].ScaleY = DrawPanelScaleY;
            }
        }

        /* update draw panel size and position */
        public void UpdateDrawPanelSizeAndPosition(DoubleBufferedPanel panel, int layoutWidth, int layoutHeight)
        {
            Point size = UpdateDrawPanelSize(layoutWidth, layoutHeight);
            panel.Width = size.X;
            panel.Height = size.Y;
            panel.Location = UpdateDrawPanelLocation(layoutWidth, layoutHeight, size.X, size.Y);
            if (!_sizeAssign)
            {
                _initialWidth = panel.Width;
                _initialHeight = panel.Height;
                _sizeAssign = true;
            }
            else
            {
                CurrentDrawPanelWidth = panel.Width;
                CurrentDrawPanelHeight = panel.Height;
            }
            NotifyScalingChange();
        }
    }
}
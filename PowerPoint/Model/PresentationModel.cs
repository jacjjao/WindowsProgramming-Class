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

        int _initWidth = 0;
        public int InitDrawPanelWidth
        {
            set
            {
                _initWidth = value;
            }
        }

        int _initHeight = 0;
        public int InitDrawPanelHeight
        {
            set
            {
                _initHeight = value;
            }
        }

        float _scaleX = 1.0f;
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
                _scaleX = (float)value / (float)_initWidth;
            }
        }

        float _scaleY = 1.0f;
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
                _scaleY = (float)value / (float)_initHeight;
            }
        }

        public PresentationModel(PowerPointModel model)
        {
            Model = model;
            CheckList = new BindingList<NotifyBoolean>()
            {
                new NotifyBoolean(),
                new NotifyBoolean(),
                new NotifyBoolean(),
                new NotifyBoolean(),
                new NotifyBoolean(),
                new NotifyBoolean(),
            };
        }

        /* form resize時drawpanel的長寬要保持16:9 */
        public Point UpdateDrawPanelSize(int width, int height)
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
        public Point UpdateDrawPanelLocation(int containerWidth, int containerHeight, int panelWidth, int panelHeight)
        {
            const int TWO = 2;
            var loc = new Point();
            loc.X = containerWidth / TWO - panelWidth / TWO;
            loc.Y = containerHeight / TWO - panelHeight / TWO;
            return loc;
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

        private Point TransFormMousePosition(Point point)
        {
            point.X = (int)((float)point.X / DrawPanelScaleX);
            point.Y = (int)((float)point.Y / DrawPanelScaleY);
            return point;
        }

        /* add shape */
        public void AddRandomShape(ShapeType type, int screenWidth, int screenHeight)
        {
            Model.AddRandomShape(type, screenWidth, screenHeight);
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
        public Cursor DoMouseDown(Point position)
        {
            return Model.DoMouseDown(TransFormMousePosition(position));
        }

        /* 滑鼠在draw panel移動時的event */
        public Cursor DoMouseMove(Point position)
        {
            return Model.DoMouseMove(TransFormMousePosition(position));
        }

        /* 在draw panel上放開滑鼠按鈕的event */
        public Cursor DoMouseUp(Point position)
        {
            const int THREE = 3;
            for (int i = 0; i < THREE; i++)
            {
                CheckList[i].Value = false;
            }
            return Model.DoMouseUp(TransFormMousePosition(position));
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
            for (int i = 0; i < Model.ShapeList.Count; i++)
            {
                Model.ShapeList[i].Selected = false;
            }
        }
    }
}
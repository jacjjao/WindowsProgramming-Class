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
        public Cursor DoMouseDown(MouseEventArgs e)
        {
            return Model.DoMouseDown(e);
        }

        /* 滑鼠在draw panel移動時的event */
        public Cursor DoMouseMove(MouseEventArgs e)
        {
            return Model.DoMouseMove(e);
        }

        /* 在draw panel上放開滑鼠按鈕的event */
        public Cursor DoMouseUp(MouseEventArgs e)
        {
            const int THREE = 3;
            for (int i = 0; i < THREE; i++)
            {
                CheckList[i].Value = false;
            }
            return Model.DoMouseUp(e);
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
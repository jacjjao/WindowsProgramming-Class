using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public class PresentationModel
    {
        public BindingList<NotifyBool> CheckList
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
            CheckList = new BindingList<NotifyBool>()
            {
                new NotifyBool(),
                new NotifyBool(),
                new NotifyBool(),
                new NotifyBool(),
            };
        }

        /* 更新toolstrip button上的Checked屬性 */
        public ShapeType DoToolStripButtonClick(int index, ShapeType type, IState state)
        {
            Model.State = state;
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
            Model.State.SetShapeType(type);
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
            const int THREE = 3;
            Model.DoMouseUp(e);
            for (int i = 0; i < THREE; i++)
            {
                CheckList[i].Value = false;
            }
        }

        public void DoKeyDown(KeyEventArgs e)
        {
            Model.DoKeyDown(e);
        }
    }
}
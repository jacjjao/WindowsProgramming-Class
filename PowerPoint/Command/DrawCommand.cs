using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pen = System.Drawing.Pen;
using Color = System.Drawing.Color;

namespace PowerPoint
{
    public class DrawCommand : ICommand
    {
        IGraphics _graphics;
        public IGraphics Graphics
        {
            get
            {
                return _graphics;
            }
            set
            {
                _graphics = value;
            }
        }

        Pen _drawPen;
        public Pen DrawPen
        {
            get
            {
                return _drawPen;
            }
            set
            {
                _drawPen = value;
            }
        }

        Color _clearColor = Color.Black;
        public Color ClearColor
        {
            get
            {
                return _clearColor;
            }
            set
            {
                _clearColor = value;
            }
        }


        public void Execute(Shapes list)
        {
            list.DrawAll(_drawPen, _graphics);
        }

        public void Unexecute(Shapes list)
        {
            _graphics.ClearAll(_clearColor);
        }
    }
}

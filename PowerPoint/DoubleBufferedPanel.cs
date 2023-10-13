using System.Windows.Forms;

namespace PowerPoint
{
    class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            ResizeRedraw = true;
            DoubleBuffered = true;
        }
    }
}

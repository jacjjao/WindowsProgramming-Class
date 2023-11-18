using System.Windows.Forms;

namespace PowerPoint
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            ResizeRedraw = true;
            DoubleBuffered = true;
        }
    }
}

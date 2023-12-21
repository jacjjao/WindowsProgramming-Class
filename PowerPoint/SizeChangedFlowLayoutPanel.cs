using System;
using System.Windows.Forms;

namespace PowerPoint
{
    class SizeChangedFlowLayoutPanel : FlowLayoutPanel
    {
        // on size changed
        public void CallSizeChangedEvent()
        {
            base.OnSizeChanged(EventArgs.Empty);
        }
    }
}

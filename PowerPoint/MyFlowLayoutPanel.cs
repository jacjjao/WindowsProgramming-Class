using System;
using System.Windows.Forms;

namespace PowerPoint
{
    class MyFlowLayoutPanel : FlowLayoutPanel
    {
        // on size changed
        public void DoSizeChanged()
        {
            base.OnSizeChanged(EventArgs.Empty);
        }
    }
}

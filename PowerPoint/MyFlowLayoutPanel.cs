using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    class MyFlowLayoutPanel : FlowLayoutPanel
    {
        // on size changed
        public void OnSizeChanged()
        {
            base.OnSizeChanged(EventArgs.Empty);
        }
    }
}

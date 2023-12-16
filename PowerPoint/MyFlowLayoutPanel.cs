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
        // on resize
        public void OnResize()
        {
            base.OnResize(EventArgs.Empty);
        }
    }
}

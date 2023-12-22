using System.Windows.Forms;

namespace PowerPoint
{
    public class SlideButton : CheckBox
    {
        public SlideButton() : base()
        {
            Appearance = Appearance.Button;
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
}

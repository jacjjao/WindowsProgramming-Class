﻿using System.Windows.Forms;

namespace PowerPoint
{
    class SlideButton : CheckBox
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

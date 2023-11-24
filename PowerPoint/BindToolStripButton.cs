using System.Windows.Forms;

namespace PowerPoint
{
    public class BindToolStripButton : ToolStripButton, IBindableComponent
    {
        private ControlBindingsCollection _dataBindings;

        private BindingContext _bindingContext;

        public BindToolStripButton()
        {
            _dataBindings = new ControlBindingsCollection(this);
            _bindingContext = new BindingContext();
        }

        public ControlBindingsCollection DataBindings
        {
            get
            {
                return _dataBindings;
            }
        }

        public BindingContext BindingContext
        {
            get
            {
                return _bindingContext;
            }
            set
            {
                _bindingContext = value;
            }
        }
    }
}

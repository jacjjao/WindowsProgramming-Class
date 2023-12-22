namespace PowerPoint
{
    public class ExecuteOption
    {
        bool _combineWithPreviousCommand = false;
        public bool CombineWithPreviousCommand
        {
            get
            {
                return _combineWithPreviousCommand;
            }
            set
            {
                _combineWithPreviousCommand = value;
            }
        }

        bool _resetDataBindings = false;
        public bool ResetDataBindings
        {
            get
            {
                return _resetDataBindings;
            }
            set
            {
                _resetDataBindings = value;
            }
        }
    }
}

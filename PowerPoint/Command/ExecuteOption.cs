namespace PowerPoint
{
    public class ExecuteOption
    {
        bool _saveCommand = true;
        public bool SaveCommand
        {
            get
            {
                return _saveCommand;
            }
            set
            {
                _saveCommand = value;
            }
        }

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

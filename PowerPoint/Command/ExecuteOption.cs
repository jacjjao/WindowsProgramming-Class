using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class ExecuteOption
    {
        public bool SaveCommand
        {
            get;
            set;
        } = true;

        public bool CombindWithPreviousCommand
        {
            get;
            set;
        } = false;

        public bool ResetDataBindings
        {
            get;
            set;
        } = false;
    }
}

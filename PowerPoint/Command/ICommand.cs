﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface ICommand
    {
        void Execute(Shapes list);

        void Unexecute(Shapes list);
    }
}

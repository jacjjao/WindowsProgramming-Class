using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IPageSaver
    {
        // save
        void Save(string fileContent);

        // load
        List<Page> Load();
    }
}

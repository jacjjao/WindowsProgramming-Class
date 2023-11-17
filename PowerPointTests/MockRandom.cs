using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointTests
{
    class MockRandom : PowerPoint.IRandom
    {
        int _index = 0;
        public List<int> value = new List<int> { 100, 50, 0, 0 };

        /* next */
        public int Next(int low, int High)
        {
            int v = value[_index++];
            _index %= value.Count;
            return v;
        }
    }
}

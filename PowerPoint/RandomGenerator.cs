using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class RandomGenerator : IRandom 
    {
        Random _random = new Random();

        /* next random number integer in range [low, high) */
        public int Next(int low, int high)
        {
            return _random.Next(low, high);
        }
    }
}

using System;

namespace PowerPoint
{
    public class RandomGenerator : IRandom
    {
        Random _random = new Random();

        /* next random number integer in range [low, high) */
        public int GetNext(int low, int high)
        {
            return _random.Next(low, high);
        }
    }
}

using System;

namespace RollingADie
{
    class Event1
    {
        // Count of rising event
        public int count = 0;

        /// <summary>
        /// Method for TwoSixes event
        /// </summary>
        public void Message()
        {
            Console.WriteLine("Two sixes in a row");
            count++;
        }
    }
}

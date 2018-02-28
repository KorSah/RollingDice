using System;
using System.Threading;

namespace RollingADie
{
    /// <summary>
    /// DiceRoll class describes dices
    /// </summary>
    class DiceRoll
    {
        // Delegate 
        public delegate void MyDel();

        // Event which rises after 2 six
        public event MyDel TwoSixes;

        // Event which rises when sum of 5 dices is equal or greater than 20
        public event MyDel DiceSum;

        // Random numbers for dices
        Random random = new Random();

        // Array for dices' numbers
        public readonly byte[] Dice;

        // Indexator for Dice member
        public byte this[int size]
        {
            get { return this.Dice[size]; }
            set { this.Dice[size] = value; }
        }

        //Constructor for initializing Dice
        public DiceRoll(int count)
        {
            this.Dice = new byte[count];
            for (int i = 0; i < count; i++)
            {
                // Initializing with random numbers
                this[i] = (byte)random.Next(1, 7);
            }
        }

        /// <summary>
        /// Method which roll dices and check conditions
        /// </summary>
        public void Roll()
        {
            int sum = this[0];
            int count = 1;
            Console.WriteLine(this[0]);

            for (int i = 1; i < this.Dice.Length; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(this[i]);

                int eventCount = 0;
                // When condition is true TwoSixes event rises
                if (this[i - 1] == this[i] && this[i] == 6)
                {
                    TwoSixes();
                    eventCount++;
                }

                // When condition is true DieSum event rises
                sum += this[i];
                count++;
                if (count == 5 && sum >= 20)
                {
                    DiceSum();
                    count = 0;
                    sum = 0;
                }
                if (count == 5 && sum < 20)
                {
                    count = 0;
                    sum = 0;
                }
            }
        }
    }
}

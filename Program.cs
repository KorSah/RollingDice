using System;

namespace RollingADie
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceRoll dice = new DiceRoll(50);
            Event1 event1 = new Event1();
            Event2 event2 = new Event2();
            dice.TwoSixes += event1.Message;
            dice.DiceSum += event2.Message;
            dice.Roll();
            Console.WriteLine("First event rose {0} times", event1.count);
        }
    }
}

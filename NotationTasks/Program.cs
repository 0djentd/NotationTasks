using System;

namespace NotationTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Note NOTE = new Note();
            NOTE.GetNoteName(24, 0);
            Console.WriteLine("Done!");
        }
    }
}

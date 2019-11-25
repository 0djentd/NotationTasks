using System;

namespace NotationTasks
{
    class Test
    {
        static void Main(string[] args)
        {
            Note NOTE = new Note();
            NOTE.ShowFreqTable();
            for (int i=48; i<60; i++)
            {
                Console.WriteLine(i + " " + NOTE.GetNoteName(i) + " " + NOTE.GetNoteNumber(NOTE.GetNoteName(i))) ;
            }
            Console.WriteLine(NOTE.GetNoteNumber('a', 1, 4));
            //Console.WriteLine(NOTE.GetNoteName(48, 0) + " " + NOTE.GetFreq('a', 2, 4) + " " + NOTE.GetNoteNumber('a', 0, 4)+" "+ NOTE.StringToNum("a004"));
        }
    }
}

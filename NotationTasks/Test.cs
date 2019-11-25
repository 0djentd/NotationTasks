using System;

namespace NotationTasks
{
    class Test
    {
        static void Main(string[] args)
        {
            Note NOTE = new Note();
            NOTE.ShowFreqTable();
            Console.WriteLine(NOTE.GetNoteName(48, 0) + " " + NOTE.GetFreq('a', 0, 4) + " " + NOTE.GetNoteNumber('a', 0, 4)+" "+ NOTE.StringToNum("a004"));
        }
    }
}

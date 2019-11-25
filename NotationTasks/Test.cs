using System;

namespace NotationTasks
{
    class Test
    {
        static void Main(string[] args)
        {
            NoteUtility noteUtility = new NoteUtility();
            noteUtility.ShowFreqTable();
            for (int i=1; i<88; i++)
            {
                Console.WriteLine(i + " " + noteUtility.GetNoteName(i) + " " + noteUtility.GetNoteNumber(noteUtility.GetNoteName(i)) + " " + noteUtility.GetFreq(noteUtility.GetNoteName(i)) + " " + noteUtility.GetFreq(i));
            }
            Console.WriteLine(noteUtility.GetNoteNumber('a', 1, 4));
        }
    }
}

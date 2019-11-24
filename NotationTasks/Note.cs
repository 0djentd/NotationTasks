using System;

namespace NotationTasks
{
    public class Note
    {
        private bool needConsole = true;
        private double referenceNoteFreq = 440;
        private double referenceNote = 49;
        private int accuracy = 2; 
        private bool needInit = true;
        private double[] freqTable = new double[88];
        private char[] noteNameTable = new char[7] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        private string[] noteNameTableSharps = new string[12] {"a", "a#", "b", "c", "c#", "d", "d#", "e", "f", "f#",  "g", "g#" };
        private string[] noteNameTableBemol = new string[12] {"a", "bb", "b", "c", "db", "d", "eb", "e", "f", "gb", "g", "ab" };

        private string[] accidentalStringTable = new string[] { "bb", "b", "-" ,"#", "##" };

        public void Init()
        {
            needInit = false;
            for (int i=0; i<freqTable.Length; i++)
            {
                if (accuracy > 6)
                {
                    freqTable[i] = Math.Pow(2, ((i-1 - referenceNote) / 12)) * referenceNoteFreq;
                }
                else
                {
                    freqTable[i] = Math.Round(Math.Pow(2, ((i - referenceNote) / 12)) * referenceNoteFreq, accuracy);
                }
                if (needConsole == true) Console.WriteLine("freqTable[" + i + "] ("+GetNoteName(i,0) +") = " + freqTable[i]);
            }
            
            if (needConsole == true) Console.WriteLine("Init() competed");
        }

        public int GetNoteNumber(char note, int octave, int accidental)
        {
            for (int i = 0; i<=noteNameTable.Length; i++)
            {
                if (note == noteNameTable[i])
                {
                    if (needConsole == true) Console.WriteLine("GetNoteNumber(name=" + note + ", accidental=" + accidental + ", octave = " + octave + ") = " + (i + 12*octave + accidental));
                    return i + 12 * octave + accidental;
                }
            }
            return 0;
        }

        public double GetFreq(char note, int accidental, int octave)
        {
            if (needInit == true) Init();
            if (needConsole == true) Console.WriteLine("GetFreq(name=" + note + ", accidental=" + accidental + ", octave = " + octave + ") = " + freqTable[GetNoteNumber(note, octave, accidental)]);
            return freqTable[GetNoteNumber(note, octave, accidental)];
        }
        public double GetFreq(char note, string accidental, int octave)
        {
            int accidentalInt = 0 ;
            bool foundAccidentalString = false;
            if (needInit == true) Init();
            for (int i=0; i<accidentalStringTable.Length; i++)
            {
                if (accidental == accidentalStringTable[i])
                {
                    accidentalInt = i - 2;
                    foundAccidentalString = true;
                }
            }
            if (foundAccidentalString == false)
            {
                if (needConsole == true) Console.WriteLine("accidentalStringTable is usless");
                accidentalInt = 0;
            }
            if (needConsole == true) Console.WriteLine("GetFreq(name=" + note + ", accidental=" + accidental + ", octave = " + octave + ") = " + freqTable[GetNoteNumber(note, octave, accidentalInt)]);
            return freqTable[GetNoteNumber(note, octave, accidentalInt)];
        }
        public string GetNoteName(int noteNumber, int accidental)
        {
            if (needInit == true) Init();
            if (accidental == -1)
            {
                if (needConsole == true) Console.WriteLine("GetNoteName(" + noteNumber + ") = " + (noteNameTableBemol[noteNumber % 12]) + (noteNumber / 12));
                return (noteNameTableBemol[noteNumber % 12]) + (noteNumber / 12);
            }
            else
            {
                if (needConsole == true) Console.WriteLine("GetNoteName(" + noteNumber + ") = " + (noteNameTableSharps[noteNumber % 12]) + (noteNumber / 12));
                return (noteNameTableSharps[noteNumber % 12]) + (noteNumber / 12);
            }
        }
    }
}

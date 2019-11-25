using System;

namespace NotationTasks
{
    public class Note
    {
        private double referenceNoteFreq = 440;
        private double referenceNote = 49;
        private int accuracy = 2; 
        private bool needInit = true;
        private double[] freqTable = new double[88];
        private char[] noteNameTable = new char[7] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        private string[] noteNameTableSharps = new string[12] {"a ", "a#", "b ", "c ", "c#", "d ", "d#", "e ", "f ", "f#",  "g ", "g#" };
        private string[] noteNameTableBemol = new string[12] {"a", "bb", "b", "c", "db", "d", "eb", "e", "f", "gb", "g", "ab" };
        private string[] accidentalStringTable = new string[] { "bb", "b", "-" ,"#", "##" };

        public void Init()
        {
            needInit = false;
            for (int i=1; i<freqTable.Length; i++)
            {
                if (accuracy > 6)
                {
                    freqTable[i] = Math.Pow(2, ((i - referenceNote + 1) / 12)) * referenceNoteFreq;
                }
                else
                {
                    freqTable[i] = Math.Round(Math.Pow(2, ((i - referenceNote + 1) / 12)) * referenceNoteFreq, accuracy);
                }
            }
            
        }

        public void ShowFreqTable()
        {
            if (needInit == true) Init();
            for (int i = 0; i < freqTable.Length; i++)
            {
                Console.WriteLine("freqTable [" + i + "] ["+GetNoteName(i,0)+"] = " + freqTable[i]+" Hz");
            }
        }

        public int GetNoteNumber(char note, int octave, int accidental)
        {
            for (int i = 0; i<=noteNameTable.Length; i++)
            {
                if (note == noteNameTable[i])
                {
                    return i + 12 * octave + accidental;
                }
            }
            return 0;
        }

        public double GetFreq(char note, int accidental, int octave)
        {
            if (needInit == true) Init();
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
                accidentalInt = 0;
            }
            return freqTable[GetNoteNumber(note, octave, accidentalInt)];
        }
        public string GetNoteName(int noteNumber, int accidental)
        {
            if (needInit == true) Init();
            if (accidental == -1)
            {
                return (noteNameTableBemol[noteNumber % 12]) + (noteNumber / 12);
            }
            else
            {
                return ((noteNameTableSharps[noteNumber % 12]) + (noteNumber / 12));
            }
        }

    }
}

using System;

namespace NotationTasks
{
    public class Note
    {
        private double referenceNoteFreq = 440;
        private double referenceNote = 49;
        private int accuracy = 4; 
        private bool needInit = true;
        private double[] freqTable = new double[88];
        private char[] noteNameTable = new char[7] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        private char[] noteNameTableSharp = new char[12] {'a', 'a', 'b', 'c', 'c', 'd', 'd', 'e', 'f', 'f',  'g', 'g' };
        private char[] noteNameTableFlat = new char[12] {'a', 'b', 'b', 'c', 'd', 'd', 'e', 'e', 'f', 'g', 'g', 'a' };
        private string[] accidentalsStringTable = new string[] { "bb", "b_", "__" ,"#_", "##" };

        // ab_4 a__4

        public void Init()
        {
            needInit = false;
            for (int i=0; i<freqTable.Length; i++)
            {
                if (accuracy > 6)
                {
                    freqTable[i] = Math.Pow(2, ((i - referenceNote ) / 12)) * referenceNoteFreq;
                }
                else
                {
                    freqTable[i] = Math.Round(Math.Pow(2, ((i - referenceNote ) / 12)) * referenceNoteFreq, accuracy);
                }
            }
            
        }

        public void ShowFreqTable()
        {
            if (needInit == true) Init();
            for (int i = 1; i < freqTable.Length; i++)
            {
                Console.WriteLine("freqTable [" + i + "] ["+GetNoteName(i)+"] = " + freqTable[i]+" Hz");
            }
        }

        public string GetNoteName(int noteNumber)
        {
            noteNumber--;
            if (needInit == true) Init();
            int noteNumberInOctave = noteNumber % 12;
            string noteName = Convert.ToString(noteNameTableSharp[noteNumberInOctave]);
            if (noteNumberInOctave == 1 | noteNumberInOctave == 4 | noteNumberInOctave == 6 | noteNumberInOctave == 9 | noteNumberInOctave == 11)
            {
                noteName += "#_";
            }
            else
            {
                noteName += "__";
            }
            return (noteName + (noteNumber / 12));
        }

        public int GetNoteNumber(string noteString)
        {
            for (int i = 0; i <= noteNameTableSharp.Length; i++)
            {
                if (noteString[0] == noteNameTableSharp[i])
                {
                    for (int x = 1; x < accidentalsStringTable.Length; x++)
                    {
                        if (noteString.Substring(1, 2) == accidentalsStringTable[x])
                        {
                            int accidentalInt = x - 2;
                            return i + (12 * Convert.ToInt32(noteString.Substring(3, 1))) + accidentalInt + 1;
                        }
                    }
                    return (i + 12 * Convert.ToInt32(noteString[3]));
                }
            }
            return 0;
        }
        public int GetNoteNumber(char note, int accidental, int octave)
        {
            string noteName = note.ToString() + accidentalsStringTable[accidental + 2] + octave;
            return GetNoteNumber(noteName);
        }
        public double GetFreq(string noteString)
        {
            if (needInit == true) Init();
            return freqTable[GetNoteNumber(noteString)];
        }

        /*
        public int GetNoteNumber(char note, string accidental, int octave)
        {
            for (int i = 0; i<=noteNameTable.Length; i++)
            {
                if (note == noteNameTable[i])
                {
                    for(int x=1; x<accidentalStringTable.Length; x++)
                    {
                        if (accidental == accidentalStringTable[x])
                        {
                            int accidentalInt = x - 2;
                            return i + 12 * octave + accidentalInt;
                        }
                    }
                    return i + 12 * octave;
                }
            }
            return 0;
        }
        public int GetNoteNumber(char note, int accidental, int octave)
        {
            return GetNoteNumber(note, accidentalStringTable[accidental + 2], octave);
        }



        public int StringToNum(string noteString)
        {
            return GetNoteNumber(noteString[0], noteString.Substring(1,2), noteString[3]);
        }

        public double GetFreq(string noteString)
        {
            if (needInit == true) Init();
            return freqTable[StringToNum(noteString)];
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
            return freqTable[GetNoteNumber(note, accidentalInt, octave)];
        }
        public double GetFreq(char note, int accidental, int octave)
        {
            return GetFreq(note, accidentalStringTable[accidental + 2], octave);
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

        public int Compare(string note1, string note2)
        {
            return (StringToNum(note2) - StringToNum(note2));
        }*/

    }
}

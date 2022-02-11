namespace NotationTasks
{
    // Base class for notes.
    class Note
    {
        private int pitch;
        private double freq;
        private int start;
        private int duration;
        private int tuplet;
        private int articulation;

        public int Pitch { get => pitch; set => pitch = value; }
        public double Freq { get => freq; set => freq = value; }
        public int Start { get => start; set => start = value; }
        public int Duration { get => duration; set => duration = value; }
        public int Tuplet { get => tuplet; set => tuplet = value; }
        public int Articulation { get => articulation; set => articulation = value; }
        public void Set(int setpitch, int start, int duration, int tuplet)
        {
            Pitch()=setpitch;
        }
    }
}

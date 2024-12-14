namespace PixMoodTracker
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class HourMoods
    {
        private Mood[] _moods;

        public IEnumerable<Mood> Moods => _moods;

        public HourMoods()
        {
            _moods = new Mood[12];
        }

        public void AddMood(MoodType type, int minute)
        {
            if (_moods[minute].IsFull == false)
            {
                _moods[minute].IsFull = true;
                _moods[minute].Type = type;
            }
        }

        public bool IsFull()
        {
            for (int i = 0; i < _moods.Length; i++)
            {
                if (_moods[i].IsFull == false)
                    return false;
            }
            return true;
        }
    }
}
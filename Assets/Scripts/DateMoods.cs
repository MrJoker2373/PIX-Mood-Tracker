namespace PixMoodTracker
{
    using System.Collections.Generic;

    public class DateMoods
    {
        private HourMoods[] _hours;

        public IEnumerable<HourMoods> Hours => _hours;

        public DateMoods()
        {
            _hours = new HourMoods[24];
            for (int i = 0; i < _hours.Length; i++)
                _hours[i] = new();
        }

        public void AddMood(MoodType type, int hour, int minute)
        {
            if (_hours[hour].IsFull() == false)
                _hours[hour].AddMood(type, minute);
        }

        public bool IsFull()
        {
            for (int i = 0; i < _hours.Length; i++)
            {
                if (_hours[i].IsFull() == false)
                    return false;
            }
            return true;
        }
    }
}
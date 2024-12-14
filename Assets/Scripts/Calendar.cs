namespace PixMoodTracker
{
    using System;
    using System.Linq;
    using UnityEngine;

    public class Calendar : MonoBehaviour
    {
        private CalendarGroup[] _groups;
        private DateMoods _date;

        private void Awake()
        {
            _groups = GetComponentsInChildren<CalendarGroup>();
            for (int i = 0; i < _groups.Length; i++)
                _groups[i].Initialize(i.ToString("00"));
            InitializeDate(DateTime.Now);
        }

        public void InitializeDate(DateTime date)
        {
            _date = new DateMoods();
            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 12; minute++)
                {
                    var key = date.ToString("dd.MM.yyyy") + hour.ToString("00") + minute.ToString("00");
                    if (PlayerPrefs.HasKey(key) == true)
                    {
                        var result = Mood.Parse(PlayerPrefs.GetString(key));
                        _date.AddMood(result, hour, minute);
                    }
                }
            }
            for (int i = 0; i < _groups.Length; i++)
                _groups[i].Refresh(_date.Hours.ElementAt(i).Moods.ToArray());
        }

        public void InitializeDays(DateTime lastDate, MoodType mood)
        {
            while (lastDate < DateTime.Now)
            {
                var key = lastDate.ToString("dd.MM.yyyy") + lastDate.Hour.ToString("00") + ((lastDate.Minute / 5) - 1).ToString("00");
                if (PlayerPrefs.HasKey(key) == false)
                    PlayerPrefs.SetString(key, mood.ToString());
                lastDate = lastDate.AddMinutes(5);
            }
            InitializeDate(DateTime.Now);
            for (int i = 0; i < _groups.Length; i++)
                _groups[i].Refresh(_date.Hours.ElementAt(i).Moods.ToArray());
        }
    }
}
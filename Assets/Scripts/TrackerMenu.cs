namespace PixMoodTracker
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class TrackerMenu : Menu
    {
        private const string DATE_KEY = "LastDate";
        private const string MOOD_KEY = "LastMood";
        private const string START_KEY = "LastStart";
        [SerializeField] private TextMeshProUGUI _dateLabel;
        [SerializeField] private TextMeshProUGUI _timeLabel;
        [SerializeField] private Button _stopButton;
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private TextMeshProUGUI _stopLabel;
        [SerializeField] private Calendar _calendar;
        [SerializeField] private MoodPanel[] _moods;

        protected override void Awake()
        {
            base.Awake();
            _stopButton.onClick.AddListener(Stop);
            _scroll.onValueChanged.AddListener(ChangeValue);
            if (PlayerPrefs.HasKey(DATE_KEY) == false)
                PlayerPrefs.SetString(DATE_KEY, DateTime.Now.ToString());
            if (PlayerPrefs.HasKey(MOOD_KEY) == false)
                PlayerPrefs.SetInt(MOOD_KEY, Mathf.RoundToInt(_moods.Length / 2));
            if (PlayerPrefs.HasKey(START_KEY) == false)
                PlayerPrefs.SetInt(START_KEY, 0);
        }

        private void Update()
        {
            if (IsOpen == true)
            {
                _dateLabel.text = $"{DateTime.Now.DayOfWeek}\n{DateTime.Now.ToString("dd:MM:yyyy")}";
                _timeLabel.text = DateTime.Now.ToString("HH:mm");
            }
        }

        public override void Open()
        {
            base.Open();
            if(PlayerPrefs.GetInt(START_KEY) == 0)
            {
                _stopLabel.text = "Start";
                PlayerPrefs.SetString(DATE_KEY, DateTime.Now.ToString());
            }
            else
            {
                _stopLabel.text = "Stop";
                var last = DateTime.Parse(PlayerPrefs.GetString(DATE_KEY));
                if ((DateTime.Now - last).TotalMinutes >= 5)
                {
                    var mood = _moods[PlayerPrefs.GetInt(MOOD_KEY)].Type;
                    _calendar.InitializeDays(last, mood);
                    PlayerPrefs.SetString(DATE_KEY, DateTime.Now.ToString());
                }
            }
        }

        private void Stop()
        {
            if (PlayerPrefs.GetInt(START_KEY) == 0)
            {
                PlayerPrefs.SetInt(START_KEY, 1);
                _stopLabel.text = "Stop";
            }
            else
            {
                PlayerPrefs.SetInt(START_KEY, 0);
                _stopLabel.text = "Start";
            }
        }

        private void ChangeValue(Vector2 offset)
        {
            for (int i = _moods.Length - 1; i >= 0; i--)
            {
                if (_moods[i].IsSelected(transform.position))
                {
                    PlayerPrefs.SetInt(MOOD_KEY, i);
                    break;
                }
            }
        }
    }
}
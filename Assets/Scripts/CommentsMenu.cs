namespace PixMoodTracker
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using System;

    public class CommentsMenu : Menu
    {
        private const string MOOD_KEY = "Mood";
        private const string COMMENT_KEY = "Comment";
        [SerializeField] private Button _addButton;
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private TMP_InputField _input;
        [SerializeField] private Menu _addMenu;
        [SerializeField] private GameButton _dayBackwardButton;
        [SerializeField] private GameButton _monthBackwardButton;
        [SerializeField] private GameButton _yearBackwardButton;
        [SerializeField] private GameButton _dayForwardButton;
        [SerializeField] private GameButton _monthForwardButton;
        [SerializeField] private GameButton _yearForwardButton;
        [SerializeField] private TextMeshProUGUI _dateLabel;
        [SerializeField] private Pool _commentPool;
        [SerializeField] private Sprite _sad;
        [SerializeField] private Sprite _neutral;
        [SerializeField] private Sprite _happy;
        [SerializeField] private Sprite _angry;
        [SerializeField] private Sprite _excited;
        [SerializeField] private MoodPanel[] _moods;
        private DateTime _currentDate;
        private int _currentIndex;

        protected override void Awake()
        {
            base.Awake();
            _dayBackwardButton.OnPress += DayBackward;
            _monthBackwardButton.OnPress += MonthBackward;
            _yearBackwardButton.OnPress += YearBackward;
            _dayForwardButton.OnPress += DayForward;
            _monthForwardButton.OnPress += MonthForward;
            _yearForwardButton.OnPress += YearForward;

            _addButton.onClick.AddListener(Add);
            _scroll.onValueChanged.AddListener(ChangeValue);
            _currentIndex = Mathf.RoundToInt(_moods.Length / 2);
        }

        public override void Open()
        {
            base.Open();
            _currentDate = DateTime.Now;
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            Redraw();
        }

        private void Add()
        {
            if (string.IsNullOrEmpty(_input.text) == false && _input.text.Length < 80)
            {
                _addMenu.Close();
                var key = DateTime.Now.ToString("dd.MM.yyyy");
                for (int i = 0; ; i++)
                {
                    if (PlayerPrefs.HasKey(key + i + COMMENT_KEY) == false)
                    {
                        PlayerPrefs.SetString(key + i + COMMENT_KEY, _input.text);
                        PlayerPrefs.SetString(key + i + MOOD_KEY, _moods[_currentIndex].Type.ToString());
                        break;
                    }
                }
                Redraw();
            }
        }

        private void ChangeValue(Vector2 offset)
        {
            for (int i = _moods.Length - 1; i >= 0; i--)
            {
                if (_moods[i].IsSelected(transform.position))
                {
                    _currentIndex = i;
                    break;
                }
            }
        }

        private void DayBackward()
        {
            _currentDate = _currentDate.AddDays(-1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            Redraw();
        }

        private void MonthBackward()
        {
            _currentDate = _currentDate.AddMonths(-1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            Redraw();
        }

        private void YearBackward()
        {
            _currentDate = _currentDate.AddYears(-1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            Redraw();
        }

        private void DayForward()
        {
            _currentDate = _currentDate.AddDays(1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            Redraw();
        }

        private void MonthForward()
        {
            _currentDate = _currentDate.AddMonths(1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            Redraw();
        }

        private void YearForward()
        {
            _currentDate = _currentDate.AddYears(1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            Redraw();
        }

        private void Redraw()
        {
            var key = _currentDate.ToString("dd.MM.yyyy");
            _commentPool.ResetItems();
            for (int i = 0; ; i++)
            {
                if (PlayerPrefs.HasKey(key + i + COMMENT_KEY) == false)
                    break;
                var comment = PlayerPrefs.GetString(key + i + COMMENT_KEY);
                var mood = GetSprite(Mood.Parse(PlayerPrefs.GetString(key + i + MOOD_KEY)));
                var commentPanel = _commentPool.GetItem<Comment>();
                commentPanel.Initialize(mood, comment);
            }
        }

        private Sprite GetSprite(MoodType type)
        {
            switch (type)
            {
                case MoodType.Neutral:
                    return _neutral;
                case MoodType.Happy:
                    return _happy;
                case MoodType.Sad:
                    return _sad;
                case MoodType.Angry:
                    return _angry;
                case MoodType.Excited:
                    return _excited;
            }
            return null;
        }
    }
}
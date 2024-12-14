namespace PixMoodTracker
{
    using System;
    using UnityEngine;
    using TMPro;

    public class StatisticsMenu : Menu
    {
        [SerializeField] private GameButton _dayBackwardButton;
        [SerializeField] private GameButton _monthBackwardButton;
        [SerializeField] private GameButton _yearBackwardButton;
        [SerializeField] private GameButton _dayForwardButton;
        [SerializeField] private GameButton _monthForwardButton;
        [SerializeField] private GameButton _yearForwardButton;
        [SerializeField] private TextMeshProUGUI _dateLabel;
        [SerializeField] private Calendar _calendar;
        private DateTime _currentDate;

        protected override void Awake()
        {
            base.Awake();
            _dayBackwardButton.OnPress += DayBackward;
            _monthBackwardButton.OnPress += MonthBackward;
            _yearBackwardButton.OnPress += YearBackward;
            _dayForwardButton.OnPress += DayForward;
            _monthForwardButton.OnPress += MonthForward;
            _yearForwardButton.OnPress += YearForward;
        }

        public override void Open()
        {
            base.Open();
            _currentDate = DateTime.Now;
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            _calendar.InitializeDate(_currentDate);
        }

        private void DayBackward()
        {
            _currentDate = _currentDate.AddDays(-1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            _calendar.InitializeDate(_currentDate);
        }

        private void MonthBackward()
        {
            _currentDate = _currentDate.AddMonths(-1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            _calendar.InitializeDate(_currentDate);
        }

        private void YearBackward()
        {
            _currentDate = _currentDate.AddYears(-1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            _calendar.InitializeDate(_currentDate);
        }

        private void DayForward()
        {
            _currentDate = _currentDate.AddDays(1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            _calendar.InitializeDate(_currentDate);
        }

        private void MonthForward()
        {
            _currentDate = _currentDate.AddMonths(1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            _calendar.InitializeDate(_currentDate);
        }

        private void YearForward()
        {
            _currentDate = _currentDate.AddYears(1);
            _dateLabel.text = _currentDate.ToString("dd.MM.yyyy");
            _calendar.InitializeDate(_currentDate);
        }
    }
}
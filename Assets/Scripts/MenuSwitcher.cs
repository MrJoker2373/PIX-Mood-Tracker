namespace PixMoodTracker
{
    using UnityEngine;

    public class MenuSwitcher : MonoBehaviour
    {
        private MainMenu _main;
        private CommentsMenu _comments;
        private TrackerMenu _tracker;
        private StatisticsMenu _statistics;
        private Menu _currentMenu;

        private void Awake()
        {
            _main = GetComponentInChildren<MainMenu>();
            _comments = GetComponentInChildren<CommentsMenu>();
            _tracker = GetComponentInChildren<TrackerMenu>();
            _statistics = GetComponentInChildren<StatisticsMenu>();
        }

        private void Start()
        {
            OpenMain();
        }

        public void OpenMain()
        {
            if (_currentMenu != null)
                _currentMenu.Close();
            _currentMenu = _main;
            _currentMenu.Open();
        }

        public void OpenComments()
        {
            if (_currentMenu != null)
                _currentMenu.Close();
            _currentMenu = _comments;
            _currentMenu.Open();
        }

        public void OpenTracker()
        {
            if (_currentMenu != null)
                _currentMenu.Close();
            _currentMenu = _tracker;
            _currentMenu.Open();
        }

        public void OpenStatistics()
        {
            if (_currentMenu != null)
                _currentMenu.Close();
            _currentMenu = _statistics;
            _currentMenu.Open();
        }
    }
}
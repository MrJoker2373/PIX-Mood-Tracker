namespace PixMoodTracker
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class CalendarGroup : MonoBehaviour
    {
        private Image[] _moods;
        private TextMeshProUGUI _label;

        public void Initialize(string time)
        {
            _moods = GetComponentsInChildren<Image>();
            _label = GetComponentInChildren<TextMeshProUGUI>();
            _label.text = $"{time.ToString()}:00";
        }

        public void Refresh(Mood[] moods)
        {
            for (int i = 0; i < _moods.Length; i++)
            {
                int inverse = _moods.Length - i - 1;
                if (moods[inverse].IsFull == false)
                    _moods[i].color = Color.clear;
                else
                {
                    switch (moods[inverse].Type)
                    {
                        case MoodType.Neutral:
                            _moods[i].color = Color.yellow;
                            break;
                        case MoodType.Happy:
                            _moods[i].color = Color.green;
                            break;
                        case MoodType.Sad:
                            _moods[i].color = Color.blue;
                            break;
                        case MoodType.Angry:
                            _moods[i].color = Color.red;
                            break;
                        case MoodType.Excited:
                            _moods[i].color = Color.magenta;
                            break;
                    }
                }
            }
        }
    }
}
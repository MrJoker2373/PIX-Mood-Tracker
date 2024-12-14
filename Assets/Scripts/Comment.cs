namespace PixMoodTracker
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class Comment : MonoBehaviour
    {
        [SerializeField] private Image _moodImage;
        [SerializeField] private TextMeshProUGUI _contentLabel;

        public void Initialize(Sprite mood, string content)
        {
            _moodImage.sprite = mood;
            _contentLabel.text = content;
        }
    }
}
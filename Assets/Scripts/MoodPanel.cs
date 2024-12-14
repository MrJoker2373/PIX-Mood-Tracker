namespace PixMoodTracker
{
    using UnityEngine;

    [RequireComponent(typeof(RectTransform))]
    public class MoodPanel : MonoBehaviour
    {
        [SerializeField] private MoodType _type;
        private RectTransform _rect;

        public MoodType Type => _type;

        private void Awake() => _rect = GetComponent<RectTransform>();

        public bool IsSelected(Vector2 position) => position.x >= _rect.position.x - _rect.sizeDelta.x / 2;
    }
}
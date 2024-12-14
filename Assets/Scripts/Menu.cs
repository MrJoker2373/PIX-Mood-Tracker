namespace PixMoodTracker
{
    using UnityEngine;

    [RequireComponent(typeof(CanvasGroup))]
    public class Menu : MonoBehaviour
    {
        private CanvasGroup _group;
        private bool _isOpen;

        public bool IsOpen => _isOpen;

        protected virtual void Awake()
        {
            _group = GetComponent<CanvasGroup>();
        }

        public virtual void Open()
        {
            _isOpen = true;
            _group.alpha = 1f;
            _group.blocksRaycasts = true;
            _group.interactable = true;
        }

        public virtual void Close()
        {
            _isOpen = false;
            _group.alpha = 0f;
            _group.blocksRaycasts = false;
            _group.interactable = false;
        }
    }
}
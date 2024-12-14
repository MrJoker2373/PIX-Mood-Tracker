namespace PixMoodTracker
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    public class GameButton : MonoBehaviour
    {
        protected Button _button;
        private AudioSource _audio;

        public event Action OnPress;

        protected void Awake()
        {
            _button = GetComponent<Button>();
            _audio = GetComponent<AudioSource>();
        }

        protected void OnEnable()
        {
            _button.onClick.AddListener(Press);
        }

        protected void OnDisable()
        {
            _button.onClick.RemoveListener(Press);
        }

        public virtual void Press()
        {
            _audio.Play();
            OnPress?.Invoke();
        }
    }
}
namespace PixMoodTracker
{
    using UnityEngine;

    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private void Awake()
        {
            var rect = GetComponent<RectTransform>();
            var size = new Vector2(Screen.width, Screen.height);
            var anchorMin = Screen.safeArea.position;
            var anchorMax = Screen.safeArea.position + Screen.safeArea.size;
            rect.anchorMin = anchorMin /= size;
            rect.anchorMax = anchorMax /= size;
        }
    }
}
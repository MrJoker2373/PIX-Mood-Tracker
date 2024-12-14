namespace PixMoodTracker
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Loading : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync("Main");
        }
    }
}
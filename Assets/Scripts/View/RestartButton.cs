using UnityEngine;
using UnityEngine.SceneManagement;
    public sealed class RestartButton : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        Player._gems = 0;
        Player._peoplePoint = 0;
            Time.timeScale = 1.0f;
        }

    }


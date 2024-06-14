using UnityEngine;
using UnityEngine.SceneManagement;

namespace OtusProject.GameOver
{
    public sealed class GameOverButton : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


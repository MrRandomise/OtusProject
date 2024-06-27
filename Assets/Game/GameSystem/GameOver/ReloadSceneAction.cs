using UnityEngine;
using UnityEngine.SceneManagement;

namespace OtusProject.GameOver
{
    public sealed class ReloadSceneAction : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


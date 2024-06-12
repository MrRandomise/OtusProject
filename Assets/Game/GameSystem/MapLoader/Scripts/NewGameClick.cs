using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using OtusProject.MenuButton;
using System.Collections;

namespace OtusProject.Config.Map
{
    public sealed class NewGameClick : MonoBehaviour
    {
        [SerializeField] private NewGameView _newGameView;
        [Inject]
        private readonly MapLoader _mapLoader;
        private const string _gameScene = "GameScene";

        public async void LoadGameScene()
        {
            _newGameView.Menu.transform.localScale = Vector3.zero;
            _newGameView.LoadMenu.SetActive(true);
            await _mapLoader.InitializedMap();
            _mapLoader.ChangeMap();
            StartCoroutine(LoadSceneGame());
        }

        IEnumerator LoadSceneGame()
        {
            AsyncOperation Operation = SceneManager.LoadSceneAsync(_gameScene);
            while (!Operation.isDone)
            {
                float Progress = Operation.progress;
                _newGameView.ProgressText.text = $"{(Progress * 100).ToString("0")}%";
                _newGameView.ProgressImage.fillAmount = Progress;
                yield return null;
            }
        }
    }
}
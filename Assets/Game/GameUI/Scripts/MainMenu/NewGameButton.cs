using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using OtusProject.Config.Map;

namespace OtusProject.MenuButton
{
    public sealed class NewGameButton : MonoBehaviour
    {
        [SerializeField] private GameObject Menu;
        [SerializeField] private GameObject LoadMenu;
        [SerializeField] private Image _progressImage;
        [SerializeField] private TMP_Text _progressText;
        [Inject]
        private readonly MapLoader _mapLoader;
        private const string _gameScene = "GameScene";

        public async void LoadGameScene()
        {
            Menu.transform.localScale = Vector3.zero;
            LoadMenu.SetActive(true);
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
                _progressText.text = $"{(Progress * 100).ToString("0")}%"; //Процент загрузки
                _progressImage.fillAmount = Progress;
                yield return null;
            }
        }
    }
}
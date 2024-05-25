using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OtusProject.MenuButton
{
    public sealed class NewGameButton : MonoBehaviour
    {
        [SerializeField] private GameObject Menu;
        [SerializeField] private GameObject LoadMenu;
        [SerializeField] private Image _progressImage;
        [SerializeField] private TMP_Text _progressText;
        private const string _gameScene = "GameScene";

        public void LoadGameScene()
        {
            Menu.transform.localScale = Vector3.zero;
            LoadMenu.SetActive(true);
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
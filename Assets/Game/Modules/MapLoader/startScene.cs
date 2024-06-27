using UnityEngine;
using Zenject;

namespace OtusProject.Config.Map
{
    public class StartScene : MonoBehaviour
    {
        [Inject]
        private readonly MapLoader _mapLoader;
        [SerializeField] private bool _debug;

        private async void Awake()
        {
            if (_debug)
            {
                if (_mapLoader.CurrMap == null)
                {
                    await _mapLoader.InitializedMap();
                    _mapLoader.ChangeMap();
                }
            }
        }
    }
}


using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace OtusProject.Config.Map
{
    public class startScene : MonoBehaviour
    {
        private MapLoader _loader;

        [Inject]
        private void Construct(MapLoader loader)
        {
            _loader = loader;
        }
        private async void Awake()
        {
            await _loader.InitializedMap();
            _loader.LoadMap();
        }
    }
}


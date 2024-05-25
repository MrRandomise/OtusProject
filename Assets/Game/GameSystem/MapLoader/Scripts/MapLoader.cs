using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEditor.AI;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace OtusProject.Config.Map
{
    public sealed class MapLoader
    {
        private List<GameObject> LoadMaps = new List<GameObject>();
        private const int mapCount = 6;
        private GameObject currMap;
        private Transform _mapPoint;
        private AsyncOperationHandle<GameObject> _mapHandle;
        [Inject]
        private void Construct(Transform mapPoint)
        {
            _mapPoint = mapPoint;
        }

        public void LoadMap()
        {
            var index = Random.Range(1, LoadMaps.Count);
            currMap.gameObject.SetActive(false);
            currMap = LoadMaps[index];
            currMap.gameObject.SetActive(true);
            NavMeshBuilder.BuildNavMeshAsync();
        }

        public async Task InitializedMap()
        {
            for(int  i = 1; i < mapCount; i++)
            {
                _mapHandle = Addressables.LoadAssetAsync<GameObject>($"Map{i}");
                await _mapHandle.Task;
                currMap = GameObject.Instantiate(_mapHandle.Result, _mapPoint);
                LoadMaps.Add(currMap);
                currMap.SetActive(false);
            }
        }
    }
}

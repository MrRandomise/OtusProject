using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEditor.AI;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace OtusProject.Config.Map
{
    public sealed class MapLoader
    {
        public GameObject CurrMap;
        private List<GameObject> LoadMaps = new List<GameObject>();
        private Transform _mapPoint;
        private AsyncOperationHandle<GameObject> _mapHandle;
        private readonly string _spawnPoint = "MapSpawn";
        private readonly int mapCount = 6;

        public void ChangeMap()
        {
            var index = Random.Range(1, LoadMaps.Count);
            if(CurrMap != null)
            {
                CurrMap.gameObject.SetActive(false);
            }
            CurrMap = LoadMaps[index];
            CurrMap.gameObject.SetActive(true);
            NavMeshBuilder.BuildNavMeshAsync();
        }

        public async Task InitializedMap()
        {
            _mapPoint = GameObject.FindGameObjectWithTag(_spawnPoint).transform;
            for (int  i = 1; i < mapCount; i++)
            {
                _mapHandle = Addressables.LoadAssetAsync<GameObject>($"Map{i}");
                await _mapHandle.Task;
                CurrMap = GameObject.Instantiate(_mapHandle.Result, _mapPoint);
                LoadMaps.Add(CurrMap);
                CurrMap.SetActive(false);
            }
        }
    }
}

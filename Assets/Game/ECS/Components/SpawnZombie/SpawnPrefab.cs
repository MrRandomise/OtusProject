using Leopotam.EcsLite.Entities;
using System;
using System.Collections.Generic;

namespace OtusProject.Component.Spawn
{
    [Serializable]
    public struct SpawnPrefab 
    {
        public List<Entity> Value;
    }
}
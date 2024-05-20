using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OtusProject.RecourcesConfig
{
    public interface IResources
    {
        int GetCountResources();
        void SetCountResources(int count);
        string GetNameResources();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameManager
{
    public class ResourceManager
    {
        public static ResourceManager Instance = null;

        // Simple method to instance a prefab
        public static GameObject CreatePersistGameObejct(string prefab)
        {
            GameObject prefabObject = Resources.Load<GameObject>(prefab);
            GameObject go = Object.Instantiate(prefabObject);
            Object.DontDestroyOnLoad(go);
            return go;
        }
    }
}

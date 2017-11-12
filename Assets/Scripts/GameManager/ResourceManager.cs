using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameManager
{
    public class ResourceManager
    {
        public static ResourceManager Instance = null;
        public static Dictionary<string, GameObject> UIPrefabCache = new Dictionary<string, GameObject>();
        public static Dictionary<string, GameObject> gameObjectPrefabCache = new Dictionary<string, GameObject>();

        public static GameObject CreatePersistGameObejct(string prefab)
        {
            GameObject prefabObject = Resources.Load<GameObject>(prefab);
            GameObject go = Object.Instantiate(prefabObject);
            Object.DontDestroyOnLoad(go);
            return go;
        }

        public static GameObject CreateGameObejct(string prefab)
        {
            GameObject prefabObject;
            gameObjectPrefabCache.TryGetValue(prefab, out prefabObject);
            if (prefabObject == null)
            {
                prefabObject = Resources.Load<GameObject>(prefab);
                gameObjectPrefabCache[prefab] = prefabObject;
            }
            GameObject go = Object.Instantiate(prefabObject);
            return go;
        }

        public static GameObject CreateUIGameObejct(string prefab)
        {
            GameObject prefabObject;
            UIPrefabCache.TryGetValue(prefab, out prefabObject);
            if (prefabObject == null)
            {
                prefabObject = Resources.Load<GameObject>(prefab);
                if (prefabObject == null)
                {
                    Debug.Log("[ResourceManager] --> Cannot load prefab with path: " + prefab);
                }
                UIPrefabCache[prefab] = prefabObject;
            }
            GameObject go = Object.Instantiate(prefabObject);
            Object.DontDestroyOnLoad(go);
            return go;
        }
    }
}

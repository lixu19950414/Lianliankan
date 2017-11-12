using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class CameraManager
    {
        public static CameraManager Instance = null;

        public GameObject mainCamera = null;

        public CameraManager()
        {
            mainCamera = ResourceManager.CreatePersistGameObejct("StartRes/MainCamera");
        }
    }
}

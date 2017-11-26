using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        // Use this for initialization
        void Awake()
        {
            InitializeAllManagers();
            gameObject.AddComponent<Logcat>();
        }

        void InitializeAllManagers()
        {
            //Should initialize ResourceManager first
            ResourceManager.Instance = new ResourceManager();
            CameraManager.Instance = new CameraManager();
            UICanvasManager.Instance = new UICanvasManager();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {

        }
    }
}

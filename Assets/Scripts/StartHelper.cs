using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStart
{
    public class StartHelper : MonoBehaviour
    {

        // Use this for initialization
        void Awake()
        {
            // Create GameManager GameObject
            GameObject gameManager = new GameObject("GameManager");
            gameManager.AddComponent<GameManager.GameManager>();
            DontDestroyOnLoad(gameManager);

            // Destroy self
            Destroy(gameObject);

            // Start Game
            Game.Main.startGame();
        }
    }
}

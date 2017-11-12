using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Main
    {

        public static void startGame()
        {
            new PanelWelcome();
            SceneManager.LoadScene("Level1");
        }
    }
}

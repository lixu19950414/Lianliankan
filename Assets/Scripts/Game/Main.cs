using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System;
using System.Text;

namespace Game
{
    public class Main
    {

        public static void startGame()
        {
            new PanelWelcome();
            SceneManager.LoadScene("Level1");

            Debug.Log("terst");
            Debug.LogError("123");
           
        }
    }
}

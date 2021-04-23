using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void resetGame()
    {
        //Reset game to offense mode
        SceneManager.LoadScene("Offense");
    }
    public void resetGame_D() {
        //Reset game to defense mode
        SceneManager.LoadScene("Defense");
    }
    public void resetMenu() {
        //Load back to Main Menu
        SceneManager.LoadScene("Main Menu");
    }
}
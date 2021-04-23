using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    //Change scene to Offense
    public void changeSceneO() {
        SceneManager.LoadScene("offense");
    }

    //Change scene to Defense
    public void changeSceneD() {
        SceneManager.LoadScene("defense");
    }

    //Change scene to Instructions
    public void ShowGameInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    //Exit application
    public void ExitGame()
    {
        Application.Quit();
    }
}

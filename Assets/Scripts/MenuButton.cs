using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void changeSceneO() {
        SceneManager.LoadScene("offense");
    }
    public void changeSceneD() {
        SceneManager.LoadScene("defense");
    }
    public void ShowGameInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void resetGame()
    {
        SceneManager.LoadScene("Offense");
    }
    public void resetMenu() {
        SceneManager.LoadScene("Main Menu");
    }
}
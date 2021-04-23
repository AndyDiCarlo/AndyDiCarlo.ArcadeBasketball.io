using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Miss : MonoBehaviour
{
    public void OnTriggerEnter()
    {
        //Load Game Over Scene
        SceneManager.LoadScene("Game Over");
    }
}

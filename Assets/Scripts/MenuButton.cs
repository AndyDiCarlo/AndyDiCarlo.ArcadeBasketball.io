using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

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
}

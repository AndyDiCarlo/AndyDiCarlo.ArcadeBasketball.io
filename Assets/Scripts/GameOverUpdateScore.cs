using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Score: " + Score.Points; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

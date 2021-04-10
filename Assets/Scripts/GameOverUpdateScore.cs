using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int points = Basket.Instance.scorePoints;
        Debug.Log("From GameOverUpdateScore: " + points);
        gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + points; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

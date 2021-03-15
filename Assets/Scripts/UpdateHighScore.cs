using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        Debug.Log(Score.Points);
        Debug.Log(Score.HighPoints);
        if(Score.Points > Score.HighPoints) {
            Score.HighPoints = Score.Points;
        }
        gameObject.GetComponent<Text>().text = "High Score: " + Score.HighPoints;
    }

    // Update is called once per frame
    void Update() {

    }
}
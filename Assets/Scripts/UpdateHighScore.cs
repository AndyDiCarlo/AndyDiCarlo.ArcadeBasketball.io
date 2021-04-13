using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHighScore : MonoBehaviour {

    //Start is called before the first frame update
    public int points = Basket.Instance.scorePoints;
    public static int highpoints = 0;
    void Start() {
        Debug.Log(points);
        Debug.Log(highpoints);
        if(points > highpoints) {
            highpoints = points;
        }
        gameObject.GetComponent<Text>().text = "High Score: " + highpoints;
    }

    // Update is called once per frame
    void Update() {

    }
}
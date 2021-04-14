using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UpdateHighScore : MonoBehaviour {

    //Start is called before the first frame update

    public int highpoints_D;
    public int highpoints;
    public GameObject highscoretext;
    public GameObject scoretext;
    int points_D;
    int points;
    void Start() {
        
        int highpoints = PlayerPrefs.GetInt("HighScore0");
        points = Basket.Instance.scorePoints;
        Debug.Log("From UpdateHighScore points: " + points);
        Debug.Log("highpoints: " + highpoints);
        if(points > highpoints) {
            highpoints = points;
            PlayerPrefs.SetInt("Highscore0", highpoints);
        }
        highscoretext = GameObject.FindGameObjectWithTag("highscore");
        scoretext = GameObject.FindGameObjectWithTag("score");
        //gameObject.GetComponent<TextMeshProUGUI>().text = "High Score: " + highpoints;
        highscoretext.GetComponent<TextMeshProUGUI>().text = "High Score: " + highpoints;
        scoretext.GetComponent<TextMeshProUGUI>().text = "Score: " + points;
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
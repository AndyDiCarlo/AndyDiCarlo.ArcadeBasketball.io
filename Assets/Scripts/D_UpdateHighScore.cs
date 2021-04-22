using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class D_UpdateHighScore : MonoBehaviour
{

    //Variable creation for script
    public int highpoints_D;
    public int highpoints;
    public GameObject highscoretext;
    public GameObject scoretext;
    int points_D;

    // Start is called before the first frame update
    void Start()
    {
        highpoints_D = PlayerPrefs.GetInt("HighScore_D0");
        points_D = Basket_D.Instance.scorePoints;

        //set high score if score is greater than high score
        if(points_D > highpoints_D) {
            highpoints_D = points_D;
            PlayerPrefs.SetInt("Highscore_D0", highpoints_D);
        }

        //Getting text objects and displaying high score / score
        highscoretext = GameObject.FindGameObjectWithTag("highscore");
        scoretext = GameObject.FindGameObjectWithTag("score");
        highscoretext.GetComponent<TextMeshProUGUI>().text = "High Score: " + highpoints_D;
        scoretext.GetComponent<TextMeshProUGUI>().text = "Score: " + points_D;
    }
}

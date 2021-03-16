using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket : MonoBehaviour
{
    public TextMeshPro score; //The score

    void OnTriggerEnter() //if ball hits basket collider
    {
        int updatedScore = int.Parse(score.GetComponent<TextMeshPro>().text) + 1; //add 1 to score
        score.GetComponent<TextMeshPro>().text = updatedScore.ToString();
        //score.GetComponent().text = currentScore.ToString();
    }

    //Update is called once per frame
    void Update() {

    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket : MonoBehaviour
{
    public TextMeshPro score; //The score
    void Update() {
    void OnTriggerEnter2d(Collider2D col) //if ball hits basket collider
    {
        Debug.Log("Collision happened");
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Score!");
            //scoring.Make();
        }

        int updatedScore = int.Parse(score.GetComponent<TextMeshPro>().text) + 1; //add 1 to score
        score.GetComponent<TextMeshPro>().text = updatedScore.ToString();
        //score.GetComponent().text = currentScore.ToString();
    }

    //Update is called once per frame
    

    }
}
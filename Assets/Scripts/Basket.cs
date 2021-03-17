using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket : MonoBehaviour
{
    public static int scorePoints;
    void OnTriggerEnter2D() //if ball hits basket collider
    {
        GameObject ball = GameObject.Find("Ball(Clone)");

        ball.GetComponent<Shoot>().make();
        //score.GetComponent().text = currentScore.ToString();
    }

    //Update is called once per frame
    void Update() {

    }
}
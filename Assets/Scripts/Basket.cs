using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket : MonoBehaviour
{
    public static Basket Instance;
    public int scorePoints;
    void OnTriggerEnter2D() //if ball hits basket collider
    {
        Instance = this;
        GameObject ball = GameObject.Find("Ball(Clone)");

        ball.GetComponent<Shoot>().make();
        //score.GetComponent().text = currentScore.ToString();
        DontDestroyOnLoad(this);
    }

    //Update is called once per frame
    void Update() {

    }
}
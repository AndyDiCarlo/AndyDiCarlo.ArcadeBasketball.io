using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket : MonoBehaviour
{
    //instance of Basket and score tracker for offense
    public static Basket Instance;
    public int scorePoints = 0;

    //Trigger for when ball enters hoop on offense
    void OnTriggerEnter2D() 
    {
        GameObject ball = GameObject.Find("Ball(Clone)");
        ball.GetComponent<Shoot>().make();
    }

    //Update is called once per frame
    void Start() {
        Instance = this;
    }
}
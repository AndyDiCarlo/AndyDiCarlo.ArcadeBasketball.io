using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket : MonoBehaviour
{
    public static Basket Instance;
    public int scorePoints = 0;
    void OnTriggerEnter2D() //if ball hits basket collider
    {
        
        
        GameObject ball = GameObject.Find("Ball(Clone)");

        ball.GetComponent<Shoot>().make();
        //score.GetComponent().text = currentScore.ToString();
        
    }

    //Update is called once per frame
    void Start() {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket_D : MonoBehaviour {
    public static Basket_D Instance;
    public int scorePoints;
    void OnTriggerEnter2D() //if ball hits basket collider
    {


        GameObject ball = GameObject.Find("BallDefense(Clone)");

        ball.GetComponent<AIShoot>().scored();
        //score.GetComponent().text = currentScore.ToString();

    }

    //Update is called once per frame
    void Start() {
        scorePoints = 0;
        Instance = this;
        DontDestroyOnLoad(this);
    }
        
}
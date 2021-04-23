using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket_D : MonoBehaviour {

    //instance of Basket and score tracker for defense
    public static Basket_D Instance;
    public int scorePoints;

    //Trigger for when ball enters hoop on defense
    void OnTriggerEnter2D() 
    {
        GameObject ball = GameObject.Find("BallDefense(Clone)");
        ball.GetComponent<AIShoot>().scored();
    }

    //Update is called once per frame
    void Start() {
        scorePoints = 0;
        Instance = this;
        DontDestroyOnLoad(this);
    }
        
}
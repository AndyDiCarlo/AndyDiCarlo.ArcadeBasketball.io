using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Basket_D : MonoBehaviour {
    public static Basket_D Instance;
    public int scorePoints = 0;
    void OnTriggerEnter2D() //if ball hits basket collider
    {


        GameObject ball = GameObject.Find("Balldefense(Clone)");

        ball.GetComponent<AIShoot>().scored();
        //score.GetComponent().text = currentScore.ToString();

    }

    //Update is called once per frame
    void Start() {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
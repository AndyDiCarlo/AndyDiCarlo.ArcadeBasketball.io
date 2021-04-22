using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //Instance of Jump and Variables for script
    public static Jump Instance;

    public float jumpForce = 14.0f; // player jump force
    public float grounded = 0.0f; // player jump delay
    Rigidbody2D rb;

    // trigger for when player blocks a shot 
    void OnTriggerEnter2D()
    {
        Instance = this;
        GameObject ball = GameObject.Find("Ball(Clone)");
        ball.GetComponent<AIShoot>().blocked();
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player jump when user hits space and jump is not on cooldown
        if(Input.GetKeyDown(KeyCode.Space) && grounded <= 0){
            rb.velocity = Vector2.up * jumpForce;
            grounded = 2f;
        }
        //cooldown countdown for jump
        if(grounded > 0)
        {
            grounded -= Time.deltaTime;
        }
    }
}

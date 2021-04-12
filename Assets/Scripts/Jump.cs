using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public static Jump Instance;
    private Vector2 jump;
    //change this to edit the speed of the jump

    public float jumpForce = 14.0f;
    public float grounded = 0.0f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    Rigidbody2D rb;
    void OnTriggerEnter2D()// if ball hits blocker collider
    {
        Instance = this;
        GameObject ball = GameObject.Find("Ball(Clone)");
        ball.GetComponent<Autoshoot>().block();
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //change these values to edit the jump height
        jump = new Vector2(0.0f, 2.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded <= 0){
            rb.velocity = Vector2.up * jumpForce;

            grounded = 2f;

        }

        if(grounded > 0)
        {
            grounded -= Time.deltaTime;
        }
    }
    void FixedUpdate(){
        
    }
}

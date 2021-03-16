using UnityEngine;
using System.Collections;

public class Shoot : Basket
{
    public GameObject ball; //reference to the ball
    private Vector3 throwSpeed = new Vector3(0, 1, 0); //This value is a guaranteed basket
    public Vector3 ballPos; //starting ball position
    private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
    private GameObject ballClone; //we don't use the original prefab
    //public GameObject meter;
    public GameObject arrow;
    private float arrowSpeed = 0.3f; //Difficulty, higher value = faster arrow movement
    private bool right = true; //used to reverse arrow movement
    //public GameObject gameOver; //game over text

    //Gravity
    void Start()
    {
        Physics.gravity = new Vector3(0, -1, 0);
    }

    //Move Arrow
    void FixedUpdate()
    {
        if (arrow.transform.position.x < 4.7f && right)
        {
            arrow.transform.position += new Vector3(arrowSpeed, 0, 0);
        }
        if (arrow.transform.position.x >= 4.7f)
        {
            right = false;
        }
        if (right == false)
        {
            arrow.transform.position -= new Vector3(arrowSpeed, 0, 0);
        }
        if (arrow.transform.position.x <= -4.7f)
        {
            right = true;
        }


        //Shoot basketball
        if (Input.GetMouseButtonDown(0) && !thrown)
        {
            thrown = true;
            ballClone = Instantiate(ball, ballPos, transform.rotation) as GameObject;
            throwSpeed.y = throwSpeed.y + arrow.transform.position.x;
            throwSpeed.z = throwSpeed.z + arrow.transform.position.x;
            ballClone.GetComponent<Rigidbody2D>().AddForce(throwSpeed, ForceMode2D.Impulse);
            //audio.Play(); //play shoot sound
        }

        //Destroy basketball
        if (ballClone != null && ballClone.transform.position.y < -2.5)
        {
            Destroy(ballClone);
            thrown = false;
            throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
        }

        //if (!OnTriggerEnter())
        //{
         //   arrow.GetComponent<Renderer>().enabled = false;
        //    Instantiate(gameOver, new Vector3(0.31f, 0.2f, 0), transform.rotation);
        //    Invoke("restart", 2);
        //}
    }
    void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

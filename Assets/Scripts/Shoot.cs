using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class Shoot : Basket
{
    public static Shoot Instance;
    public GameObject ball; //reference to the ball
    private Vector3 throwSpeed = new Vector3(1, 1, 0); //This value is a guaranteed basket
    private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
    private GameObject ballClone; //we don't use the original prefab
    private float mouseSpeed = 200f; //Difficulty, higher value = faster arrow movement
    private bool right = true; //used to reverse arrow movement
    private Vector3 start;
    private Vector3 end;
    private int lives;
    private bool madeBasket = false;
 

    //public GameObject gameOver; //game over text

    //Gravity
    void Start()
    {
        Instance = this;
        lives = 3;
        //Physics.gravity = new Vector3(0, -1, 0);
        ball.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    //Move Arrow
    void Update() { 
        if(lives < 1) {
            miss();
        }
        
        if(!GameObject.Find("Ball(Clone)"))
        {
            ballClone = Instantiate(ball, new Vector3(-4,-1,0), transform.rotation);
        }

        //Shoot basketball
        if (Input.GetMouseButtonDown(0))
        {
            thrown = true;
            
            start = Input.mousePosition;


            //throwSpeed.y = throwSpeed.y + arrow.transform.position.x;
            //throwSpeed.z = throwSpeed.z + arrow.transform.position.x;
            //ballClone.GetComponent<Rigidbody2D>().AddForce(throwSpeed, ForceMode2D.Impulse);
            //audio.Play(); //play shoot sound
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 distance = Input.mousePosition - start;
            
            throwSpeed.y = (throwSpeed.y + distance.magnitude) * 1.5f;
            throwSpeed.x = throwSpeed.x + distance.magnitude;
            distance.Normalize();
            ballClone.GetComponent<Rigidbody2D>().gravityScale = 2f;
            ballClone.GetComponent<Rigidbody2D>().AddForce(throwSpeed + distance);
        }

        //Destroy basketball
        if(ballClone != null && ballClone.transform.position.y < -5) {
            Destroy(ballClone);
            thrown = false;
            throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
            lives--;
            var livesText = GameObject.FindWithTag("lives");
            livesText.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();
            Debug.Log(lives);
        }


        //if (!OnTriggerEnter())
        //{
        //   arrow.GetComponent<Renderer>().enabled = false;
        //    Instantiate(gameOver, new Vector3(0.31f, 0.2f, 0), transform.rotation);
        //    Invoke("restart", 2);
        //}
    }
    public void make() {
        Destroy(ballClone);
        Basket.Instance.scorePoints++;
        Debug.Log("Points: " + Basket.Instance.scorePoints);
        thrown = false;
        throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
        Debug.Log(lives);
        madeBasket = true;
        var pointsText = GameObject.FindWithTag("score");
        pointsText.GetComponent<TextMeshProUGUI>().text = "Points: " + Basket.Instance.scorePoints.ToString();
    }
    public void miss() {
        SceneManager.LoadScene("Game Over");
    }
    void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

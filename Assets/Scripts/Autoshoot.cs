using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;

public class Autoshoot : Basket
{
    //private static Timer timer;
    public static Autoshoot Instance;
    public GameObject ball; //reference to the ball
    private Vector3 throwSpeed = new Vector3(1, 1, 0); //This value is a guaranteed basket
    private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
    private GameObject ballClone; //we don't use the original prefab
    private float mouseSpeed = 200f; //Difficulty, higher value = faster movement
    //private bool right = true; //used to reverse arrow movement
    private Vector3 start;
    private Vector3 end;
    private int lives;
    private bool madeBasket = false;
    Stopwatch watch = new Stopwatch();
    Random rnd = new Random();

    //public GameObject gameOver; //game over text

    //Gravity
    void Start()
    {
        Instance = this;
        lives = 3;
        //Physics.gravity = new Vector3(0, -1, 0);
        ball.GetComponent<Rigidbody2D>().gravityScale = 0f;
        watch.Start();
    }

    //Move Arrow
    void Update() { 
        if(lives < 1) {
            miss();
        }
        
        if(!GameObject.Find("Ball(Clone)"))
        {
            ballClone = Instantiate(ball, new Vector3(-523/100,-47/100,0), transform.rotation);
        }

        //Shoot basketball
        //get an error when putting rnd.Next(1000, 5000) to get the random timing
        if (watch.ElapsedMilliseconds == 5000) { //5 seconds
            watch.Stop();
            thrown = true;
            start = new Vector3(-4,-1,0);
            end = new Vector3(4,1,0);
            Vector3 distance = end - start;
            distance.Normalize();
            throwSpeed.y = (throwSpeed.y + distance.magnitude) * 1.5f;
            throwSpeed.x = throwSpeed.x + distance.magnitude;
            ballClone.GetComponent<Rigidbody2D>().gravityScale = 2f;
            ballClone.GetComponent<Rigidbody2D>().AddForce(throwSpeed + distance);
        }

        //Destroy basketball
        if(ballClone != null && ballClone.transform.position.y < -5) {
            Destroy(ballClone);
            thrown = false;
            throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
            //lives--;
            //var livesText = GameObject.FindWithTag("lives");
            //livesText.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();
            //Debug.Log(lives);
        }
    }
    public void make() {
        SceneManager.LoadScene("Game Over");
        UnityEngine.Debug.Log(lives);
        madeBasket = true;
    }
    public void miss() {
        SceneManager.LoadScene("Game Over");
    }
    public void block() {
        Destroy(ballClone);
        Basket.Instance.scorePoints++;
        UnityEngine.Debug.Log("Points: " + Basket.Instance.scorePoints);
        thrown = false;
        throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
        var pointsText = GameObject.FindWithTag("score");
        pointsText.GetComponent<TextMeshProUGUI>().text = "Points: " + Basket.Instance.scorePoints.ToString();
        if (Basket.Instance.scorePoints % 5 == 0)//Increase speed of shot every 5 successful blocks
        {
            throwSpeed.y = throwSpeed.y*2;
        }
        watch.Restart();
    }
    void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

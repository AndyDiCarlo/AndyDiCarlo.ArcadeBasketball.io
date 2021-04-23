using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class Shoot : Basket
{

    //Variables used for script
    public static Shoot Instance;
    public GameObject ball; //reference to the ball
    private Vector3 throwSpeed = new Vector3(1, 1, 0); //This value is a guaranteed basket
    private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
    private GameObject ballClone; //we don't use the original prefab
    private float ballTravelTime = 0f; //track time since throw
    private Vector3 start;
    private int lives;
    private bool madeBasket = false;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        lives = 10;
        ball.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    // Update is called once per frame
    void Update() {
        //if no lives left, send to the game over method
        if (lives < 1) {
            miss();
        }

        // if no ball clone, create one. used to prevent multiple balls at once
        if (!GameObject.Find("Ball(Clone)"))
        {
            ballClone = Instantiate(ball, new Vector3(-4,-1,0), transform.rotation);
        }

        //Get initial position of mouse click to calculate shot
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
        }

        //When mouse click is released
        if (Input.GetMouseButtonUp(0))
        {
            //Set ball force components based on angle and distance of mouse drag
            Vector3 distance = Input.mousePosition - start;
            throwSpeed.y = (throwSpeed.y + distance.magnitude) * 1.5f;
            throwSpeed.x = throwSpeed.x + distance.magnitude;
            distance.Normalize();
            ballClone.GetComponent<Rigidbody2D>().gravityScale = 2f;
            ballClone.GetComponent<Rigidbody2D>().AddForce(throwSpeed + distance);

            ballTravelTime = 3f;
            thrown = true;
        }

        //control time until ball despawn
        if (ballTravelTime > 0)
        {
            ballTravelTime -= Time.deltaTime;
        }

        //Destroy basketball
        if((ballClone != null && thrown == true) && (ballClone.transform.position.y < -5 || ballTravelTime <= 0f)) {
            Destroy(ballClone);
            thrown = false;
            throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
            lives--;
            var livesText = GameObject.FindWithTag("lives");
            livesText.GetComponent<TextMeshProUGUI>().text = "Shots Left: " + lives.ToString();
            Debug.Log(lives);
        }


    }
    public void make() {
        Destroy(ballClone);
        Basket.Instance.scorePoints++;
        thrown = false;
        throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
        madeBasket = true;
        var pointsText = GameObject.FindWithTag("score");
        pointsText.GetComponent<TextMeshProUGUI>().text = "Points: " + Basket.Instance.scorePoints.ToString();

        //edit this to change what intervals the hoop speeds up at
        //current interval -> when score is greater than 10
        if(Basket.Instance.scorePoints > 10){
            HoopMovement.increaseSpeed();
        }
    }
    public void miss() {
        SceneManager.LoadScene("Game Over");
    }
}

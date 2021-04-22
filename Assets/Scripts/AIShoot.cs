using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIShoot : Basket
{

    //Variables used for script and instance of script

    public static AIShoot instance;

    public GameObject BallDefense; //reference to the ball
    public GameObject StartWarningText; //Game start countdown text
    private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
    private GameObject ballClone; //we don't use the original prefab
    private float ballTravelTime = 0f; //track time since throw
    private float TimeToShoot = 6f; //time before ball is shot
    private int lives; //number of lives


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        lives = 1;
        BallDefense.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if no lives left, send to the game over method (AI scores)
        if (lives < 1)
        {
            scored();
        }

        //if no ball clone, create one. used to prevent multiple balls at once
        if (!GameObject.Find("BallDefense(Clone)"))
        {
            ballClone = Instantiate(BallDefense, new Vector3(-4, -1, 0), transform.rotation);
        }

        //Array of potential enemy shots; 80% chance to make a shot and 20% chance to miss a shot
        Vector3[] shotPower = new[] { new Vector3(408.1f,613f), new Vector3(401.2f,601.7f), new Vector3(403.7f, 605.6f), new Vector3(403.6f, 603.8f), 
        new Vector3(398.6f, 597.9f), new Vector3(398.9f, 596.9f), new Vector3(408.2f, 612.5f), new Vector3(412.2f, 617.1f), new Vector3(395.9f, 593.9f), new Vector3(411.9f, 618.9f)};

        //Set opening game countdown
        TimeToShoot -= Time.deltaTime;
        StartWarningText.GetComponent<UnityEngine.UI.Text>().text = "Game Will Begin in " + Mathf.RoundToInt(TimeToShoot).ToString() + " Seconds!";

        //have AI Shoot basketball when cooldown ends
        if (TimeToShoot <= 0)
        {
            StartWarningText.gameObject.SetActive(false);
            Vector3 MyVector = shotPower[Random.Range(0, shotPower.Length)];
            ballClone.GetComponent<Rigidbody2D>().gravityScale = 2f;
            ballClone.GetComponent<Rigidbody2D>().AddForce(MyVector);
            
            //Increase speed of shot after 5 successful blocks; else use longer cooldown
            if (Basket.Instance.scorePoints > 5)
            {
                TimeToShoot = Random.Range(3f,5f);
            }
            else
            {
                TimeToShoot = Random.Range(5f,9f);
            }
            
            ballTravelTime = 3f;
            thrown = true;
        }

        //control time until ball despawn
        if (ballTravelTime > 0)
        {
            ballTravelTime -= Time.deltaTime;
        }

        //Destroy basketball 
        if ((ballClone != null && thrown == true) && (ballClone.transform.position.y < -5 || ballTravelTime <= 0f))
        {
            Destroy(ballClone);
            thrown = false;
            Basket_D.Instance.scorePoints++;
            var livesText = GameObject.FindWithTag("score");
            livesText.GetComponent<TextMeshProUGUI>().text = "Score: " + Basket_D.Instance.scorePoints.ToString();
            Debug.Log(Basket_D.Instance.scorePoints);
        }

    }

     
     // Method when shot does not go in:
     // When ball doesnt go into hoop, increment defensive score
     // Update score text for player 
    public void blocked()
    {
        Basket.Instance.scorePoints++;
        Debug.Log("Points: " + Basket.Instance.scorePoints);
        Debug.Log(lives);
        var pointsText = GameObject.FindWithTag("score");
        pointsText.GetComponent<TextMeshProUGUI>().text = "Points: " + Basket.Instance.scorePoints.ToString();
    }

    //Method to send player to game over screen when ball is scored
    public void scored()
    {
        SceneManager.LoadScene("Game Over Defense");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIShoot : Basket
{
    public static AIShoot instance;
    public GameObject BallDefense; //reference to the ball
    public GameObject StartWarningText;
    private Vector3 throwSpeed = new Vector3(1, 1, 0); //This value is a guaranteed basket
    private bool thrown = false; //if ball has been thrown, prevents 2 or more balls
    private GameObject ballClone; //we don't use the original prefab
    private float ballTravelTime = 0f; //track time since throw
    private float TimeToShoot = 6f; //time before ball is shot
    private Vector3 start;
    private Vector3 end;
    private int lives;
    private bool madeBasket = false;


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
        if (lives < 1)
        {
            scored();
        }

        if (!GameObject.Find("BallDefense(Clone)"))
        {
            ballClone = Instantiate(BallDefense, new Vector3(-4, -1, 0), transform.rotation);
        }

        Vector3[] shotPower = new[] { new Vector3(408.1f,613f), new Vector3(401.2f,601.7f), new Vector3(403.7f, 605.6f), new Vector3(403.6f, 603.8f), 
        new Vector3(398.6f, 597.9f), new Vector3(398.9f, 596.9f), new Vector3(408.2f, 612.5f), new Vector3(412.2f, 617.1f), new Vector3(395.9f, 593.9f), new Vector3(411.9f, 618.9f)};

        TimeToShoot -= Time.deltaTime;

        //have Shoot basketball
        if(TimeToShoot <= 0)
        {
            StartWarningText.gameObject.SetActive(false);
            Vector3 MyVector = shotPower[Random.Range(0, shotPower.Length)];
            ballClone.GetComponent<Rigidbody2D>().gravityScale = 2f;
            ballClone.GetComponent<Rigidbody2D>().AddForce(MyVector);
            if (Basket.Instance.scorePoints % 5 == 0)//Increase speed of shot every 5 successful blocks
            {
                TimeToShoot = Random.Range(3f,6f);
            }
            else
            {
                TimeToShoot = Random.Range(5f,9f);
            }
            
            ballTravelTime = 3f;
            thrown = true;
        }

        if (ballTravelTime > 0)
        {
            ballTravelTime -= Time.deltaTime;
        }

        //Destroy basketball
        if ((ballClone != null && thrown == true) && (ballClone.transform.position.y < -5 || ballTravelTime <= 0f))
        {
            Destroy(ballClone);
            thrown = false;
            throwSpeed = new Vector3(0, 1, 0);//Reset perfect shot
            //lives--;
            var livesText = GameObject.FindWithTag("lives");
            livesText.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString();
            Debug.Log(lives);
        }

    }

    public void blocked()
    {
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
    public void scored()
    {
        SceneManager.LoadScene("Game Over Defense");
    }
}

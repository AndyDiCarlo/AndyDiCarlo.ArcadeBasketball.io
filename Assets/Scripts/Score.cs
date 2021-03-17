using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int Points;
    public static int HighPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Make() {
        Points++;
        if(Points % 5 == 0){
            HoopMovement.increaseSpeed();
        }
    }
    public void Miss() {
        SceneManager.LoadScene("Game Over");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public static int Points;
    public static int HighPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Points = Shoot.scorePoints;
        GetComponent<TextMeshProUGUI>().text = "Points: " + Points.ToString();


    }
    public void Make() {
        Points++;
        if(Points % 5 == 0){
            HoopMovement.increaseSpeed();
        }
    }
    
}

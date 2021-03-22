using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMovement : MonoBehaviour
{
	
	//change this for speed
	private static float speed = 0.5f;
	private float increment = 0;
	
	//placeholder variable
	private float t;
	
	//score variable
	public float score = 0;
	public float newScore = 1;
	
	//change these values to edit the distance
	private Vector3 left = new Vector3(-3, 0, 0);
	private Vector3 right = new Vector3(3, 0, 0);

    // Update is called once per frame
    void Update()
    {
	
		t += Time.deltaTime * speed;
		transform.position = Vector3.Lerp(left, right, t);
		
		
		if (t >= 1)
		{
			var b = right;
			var a = left;
			left = b;
			right = a;
			t = 0;
		}   
		
		
   }
   public static void increaseSpeed(){
	   speed += 0.3f;
   }

}

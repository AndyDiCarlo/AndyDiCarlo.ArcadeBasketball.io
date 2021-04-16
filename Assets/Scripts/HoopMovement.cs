using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoopMovement : Basket
{

	public static HoopMovement HInstance;

	//change this for speed
	private static float speed;
	private float increment = 0;
	
	//placeholder variable
	private float t;
	
	//score variable
	public float score = 0;
	public float newScore = 1;
	
	//change these values to edit the distance
	private Vector3 up = new Vector3(4, 2f, 0);
	private Vector3 down = new Vector3(4,-2f, 0);

    // Update is called once per frame
    void Update()
    {
	
		t += Time.deltaTime * speed;
		transform.position = Vector3.Lerp(up, down, t);
		
		
		if (t >= 1)
		{
			var b = down;
			var a = up;
			up = b;
			down = a;
			t = 0;
		}   
		
		
   }


   void Start(){
	   speed = 0;
   }

   //increases the speed
   public static void increaseSpeed(){
	   speed += 0.3f;
   }

}

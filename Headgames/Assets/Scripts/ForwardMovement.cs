using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    public float speed;
	public float acceleration;
    private float ogSpeed;
	//private float maxSpeed = 15f;
	private float addScore;
	private float new_Speed;

    private Vector3 dir = Vector3.forward;


    // Start is called before the first frame update
    void Start()
    {
        ogSpeed = speed;
		FuelBar.fuelDepletion = 1;
		
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
	}

    public void restoreSpeed()
    {
        speed = ogSpeed;
		FuelBar.fuelDepletion = 1;

    }

    // fast speed (while catching every star)
    public void fastenMovement () {
		new_Speed = speed + 1.0f;
        while (speed < new_Speed) {
            speed = speed + (Time.deltaTime * 0.001f);
        }
    }

    // lower speed (back to the default)
    public void lowerMovement (float rate) {
        while (speed > ogSpeed) {
            speed = speed - (Time.deltaTime * rate);
        }
    }

    // Update is called once per frame
    void Update()
    {
			speed += acceleration;

			//if (speed == maxSpeed/2){
			// 	Debug.Log("WE ARE ON ON DEPLETION LEVEL 2");
			//FuelBar.fuelDepletion = 2;
			//}
 
			//if (speed > (maxSpeed - 2)){
			//speed = maxSpeed;
			//FuelBar.fuelDepletion = 3;
			//}

        // moves everything forward
        transform.Translate(dir * speed * Time.deltaTime);

        // score updater
		addScore = speed * Time.deltaTime;
		GameHandler.playerScore += addScore;
        
    }
}

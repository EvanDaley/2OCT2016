using UnityEngine;
using System.Collections;

public class GyroForwardMovement : MonoBehaviour {

	public float forwardSpeed = 2f;

	// every speedMultInterval we multiply the speed by speedMult
	public float speedMult = 1.11f;
	public float speedMultInterval = 3f;
	private float speedMultCooldown;

	void Update () 
	{
		transform.Translate (transform.forward * forwardSpeed * Time.deltaTime);

		if (Time.time > speedMultCooldown)
		{
			speedMultCooldown = Time.time + speedMultInterval;
			forwardSpeed *= speedMult;
		}
	}

	void MoveLeft()
	{

	}

	void MoveRight()
	{

	}
}

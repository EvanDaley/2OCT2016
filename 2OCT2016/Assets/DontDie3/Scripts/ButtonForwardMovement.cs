using UnityEngine;
using System.Collections;

public class ButtonForwardMovement : MonoBehaviour 
{
	public float strafeSpeed = 1f;
	public float forwardSpeed = 2f;

	// every speedMultInterval we multiply the speed by speedMult
	public float speedMult = 1.11f;
	public float speedMultInterval = 3f;
	private float speedMultCooldown;

	bool rightPressed = false;
	bool leftPressed = false;

	private float startingSpeed = 1f;

	void Start()
	{
		startingSpeed = forwardSpeed;
	}

	void Restart()
	{
		forwardSpeed = startingSpeed;
	}

	void Update () 
	{
		transform.Translate (transform.forward * forwardSpeed * Time.deltaTime);

		if (Time.time > speedMultCooldown)
		{
			speedMultCooldown = Time.time + speedMultInterval;
			forwardSpeed *= speedMult;
		}

		if (rightPressed)
			MoveRight ();

		if (leftPressed)
			MoveLeft ();
	}

	public void MoveLeft()
	{
		transform.Translate (transform.right * strafeSpeed * Time.deltaTime);
	}

	public void MoveRight()
	{
		transform.Translate (-transform.right * strafeSpeed * Time.deltaTime);
	}

	public void OnPointerDownRight()
	{
		rightPressed = true;
	}

	public void OnPointerUpRight()
	{
		rightPressed = false;
	}

	public void OnPointerDownLeft()
	{
		leftPressed = true;
	}

	public void OnPointerUpLeft()
	{
		leftPressed = false;
	}
}

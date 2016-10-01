using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool alive = true;
	Vector3 startPos;

	void Start () 
	{
		startPos = transform.position;
	}
	
	void Update () 
	{
	
	}

	void Die()
	{
		if (alive == true)
		{
			alive = false;
			Invoke ("Respawn", .1f);
		}
	}

	void Respawn()
	{
		transform.position = startPos;
	}
}

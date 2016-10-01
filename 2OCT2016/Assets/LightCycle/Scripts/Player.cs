using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool alive = true;
	Vector3 startPos;

	void Start () 
	{
		startPos = transform.position;
	}

	void Die()
	{
		if (alive == true)
		{
			alive = false;
			Invoke ("Respawn", .01f);
			ScoreKeeper.Instance.PauseScoreKeeping ();
		}
	}

	void OnCollisionEnter()
	{
		Die ();
		Time.timeScale = .01f;
	}

	void Respawn()
	{
		BroadcastMessage ("Restart");
		alive = true;
		ScoreKeeper.Instance.ResetScore ();
		ScoreKeeper.Instance.ResumeScoreKeeping ();
		transform.position = startPos;

		Time.timeScale = 1;
	}
}

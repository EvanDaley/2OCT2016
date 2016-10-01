using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static ScoreKeeper Instance;

	private int score;
	private int record;

	void Start () 
	{
		record = PlayerPrefs.GetInt ("record", 0);
	}

	public void ResetScore()
	{
		score = 0;
	}

	public void AddScore(int points)
	{
		score += points;

		if (score > record)
		{
			record = score;
			PlayerPrefs.SetInt ("record", record);
		}
	}

	public int Score
	{
		get { return score; }
	}

	public int Record
	{
		get { return score; }
	}
}

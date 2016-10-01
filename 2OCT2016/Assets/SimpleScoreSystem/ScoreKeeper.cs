using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public float scoreBoostInterval = 1f;	// increment the score by scoreIntervalAmount every scoreBoostInterval seconds
	public int scoreIntervalAmount = 1;		// how many points we add every x seconds (where x is scoreBoostInterval)
	private float scoreBoostCooldown;		// a timer set based on scoreBoostInterval. See update method. 

	private bool freezeScore = false;		// freeze the score when the player dies

	public static ScoreKeeper Instance;		// a reference to this singleton
	private int score;						// current score of player
	private int record;						// the highest recorded score of the player

	void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		record = PlayerPrefs.GetInt ("record", 0);
	}

	void Update()
	{
		if (Time.time > scoreBoostCooldown)
		{
			// The timer went off. Let's set it a little bit into the future
			scoreBoostCooldown = Time.time + scoreBoostInterval;
			AddScore (scoreIntervalAmount);
		}
	}

	public int Score
	{
		get { return score; }
	}

	public int Record
	{
		get { return record; }
	}

	public void AddScore(int points)
	{
		if (freezeScore)
			return;

		score += points;

		if (score > record)
		{
			record = score;
			PlayerPrefs.SetInt ("record", record);
		}
	}

	public void PauseScoreKeeping()
	{
		freezeScore = true;
	}

	public void ResumeScoreKeeping()
	{
		freezeScore = false;
	}

	public void ResetScore()
	{
		score = 0;
		freezeScore = false;
	}

}

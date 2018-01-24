using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour
{
    [SerializeField] private PlayerScore score;
    private float finishTime = 31;
    private float time = 0f;

    // Using properties to set the min and sec of the timer
    private float min
    {
        get
        {
            return Mathf.FloorToInt((finishTime - time) / 60);
        }
    }

    private float sec
    {
        get
        {
            return Mathf.FloorToInt((finishTime - time) % 60);
        }
    }

    [SerializeField] private Text timerText;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        score = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<PlayerScore>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;

        if (time >= finishTime)
            score.GameOver();
        else
            UpdateTimer();
	}

    void UpdateTimer()
    {
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public float GetTime()
    {
        return time;
    }

    public void SetRoundTime(float newRoundTime)
    {
        finishTime = newRoundTime;
    }
}

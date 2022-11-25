using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 5;
    public static bool timerIsRunning;
    private TextMeshProUGUI timerText;

    public static bool spawnFinished;

    private void Start()
    {
        timerIsRunning = true;
        timerText = GetComponent<TextMeshProUGUI>();
        spawnFinished = false;
    }

    private void Update()
    {
        if(spawnFinished)
        {
            //Debug.Log("Timer has started!");

            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    //Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;

                    Freeze.levelFinished = true;
                    Rotate.inputOn = false;
                    timerText.text = null;
                }
            }
        }

        
    }
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewTimer : MonoBehaviour
{
    [SerializeField] private float timeRemaining;
    public static bool timerIsRunning;
    private TextMeshProUGUI timerText;

    public static bool spawnFinished;

    [SerializeField] private Image[] stars;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image defaultStar;
    [SerializeField] private Sprite[] defaultSprites;

    [SerializeField] private Image newLevelImage;
    [SerializeField] private Sprite[] newLevelSprites;

    public static int spriteIndex;

    public GameObject bar;
    public int time;

    private bool started;

        
    private void Start()
    {
        LeanTween.resume(bar);
        bar.transform.localScale = new Vector3(1f, 0f, 1f);
        started = false;
        spriteIndex = 0;
        newLevelImage.sprite = newLevelSprites[0];
        defaultStar.sprite = defaultSprites[0];
        timerIsRunning = true;
        timerText = GetComponent<TextMeshProUGUI>();
        spawnFinished = false;
        timeRemaining = 6;
    }

    private void Update()
    {
        if (spawnFinished)
        {
            //Debug.Log("Timer has started!");

            if (timerIsRunning)
            {
                LeanTween.resume(bar);

                //if (!started)
                //{
                    AnimateBar();
                    //started = true;
                    Debug.Log("Bar");
                //}

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
                if(timeRemaining <= 4f && timeRemaining >= 2f)
                {
                    defaultStar.sprite = defaultSprites[1];
                    stars[0].sprite = sprites[1];

                    spriteIndex = 1;
                    newLevelImage.sprite = newLevelSprites[1];

                }
                else if(timeRemaining <= 2f && timeRemaining != 0f)
                {
                    defaultStar.sprite = defaultSprites[2];
                    stars[0].sprite = sprites[1];
                    stars[1].sprite = sprites[1];

                    spriteIndex = 2;
                    newLevelImage.sprite = newLevelSprites[2];
                }
                else if(timeRemaining == 0f)
                {
                    defaultStar.sprite = defaultSprites[3];
                    stars[0].sprite = sprites[1];
                    stars[1].sprite = sprites[1];
                    stars[2].sprite = sprites[1];

                    spriteIndex = 3;
                    newLevelImage.sprite = newLevelSprites[3];
                }
            }
            else
            {
                LeanTween.pause(bar);
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

    public void AnimateBar()
    {
        if(!started)
        {
            LeanTween.scaleY(bar, 1, time);
            started = true;
        }
        
    }
}
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelFinisher : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    [SerializeField] private Image[] levelFinisher;
    [SerializeField] private Image[] stars;
    [SerializeField] private CanvasRenderer elementToFade;
    [SerializeField] private Button playAgain;
    [SerializeField] private Button nextLevel;

    [SerializeField] private Animator level;
    [SerializeField] private Animator finish;

    public static bool isLevelFinished;

    private bool isStarted;
    private int sceneIndex;

    private void Start()
    {
        playAgain.interactable = false;
        nextLevel.interactable = false;
        isLevelFinished = false;
        isStarted = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (isLevelFinished && !isStarted)
        {
            playAgain.interactable = true;

            if (StarsChanger.newSpriteIndex == 0 || sceneIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            {
                nextLevel.interactable = false;
            }
            else
            {
                nextLevel.interactable = true;
            }

            level.SetBool("isfinish", true);
            finish.Play("finish");

            StartCoroutine(LerpFunction(colors[1], 1, 1f));
            StartCoroutine(LerpFadeFunction(.4f, 1, 1f));
            stars[1].sprite = StarsChanger.image.sprite;
            StartCoroutine(LerpStarsFunction(stars[1], colors[1], 1, 1f));
            StartCoroutine(LerpStarsFunction(stars[0], colors[0], 4, 1f));

            isLevelFinished = false;
            isStarted = true;
        }
    }

    private IEnumerator LerpFunction(Color endValue, float fadeRate, float delay)
    {
        float time = 0;
        Color currentColor = levelFinisher[0].color;
        yield return new WaitForSeconds(delay);
        while (Mathf.Abs(currentColor.a - endValue.a) > 0.0001f)
        {
            for (int i = 0; i < levelFinisher.Length; i++)
            {
                currentColor.a = Mathf.Lerp(currentColor.a, endValue.a, fadeRate * Time.deltaTime);
                levelFinisher[i].color = currentColor;
                time += Time.deltaTime;
            }
            yield return null;
        }
    }

    private IEnumerator LerpFadeFunction(float endValue, float duration, float delay)
    {
        float time = 0;
        float startValue = elementToFade.GetAlpha();
        yield return new WaitForSeconds(delay);
        while (time < duration)
        {
            elementToFade.SetAlpha(Mathf.Lerp(startValue, endValue, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        elementToFade.SetAlpha(endValue);
    }

    private IEnumerator LerpStarsFunction(Image image, Color endValue, float fadeRate, float delay)
    {
        float time = 0;
        Color currentColor = image.color;
        yield return new WaitForSeconds(delay);
        while (Mathf.Abs(currentColor.a - endValue.a) > 0.0001f)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, endValue.a, fadeRate * Time.deltaTime);
            image.color = currentColor;
            time += Time.deltaTime;
            yield return null;
        }
    }
}

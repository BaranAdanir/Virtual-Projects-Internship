using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private CanvasRenderer elementToFade;
    [SerializeField] private GameObject menu;

    public void PauseGame()
    {
        StartCoroutine(LerpPauseFunction(0f, .2f, 0f));
        menu.LeanScale(new Vector3(0f, 0f, 0f), .5f);
    }

    public void ResumeGame()
    {
        menu.SetActive(true);
        menu.LeanScale(new Vector3(1f, 1f, 1f), .5f);
        StartCoroutine(LerpResumeFunction(.4f, .2f, 0f));
    }

    private IEnumerator LerpResumeFunction(float endValue, float duration, float delay)
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

        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.3f : 0.0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    private IEnumerator LerpPauseFunction(float endValue, float duration, float delay)
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.3f : 0.0f;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);

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
   
}

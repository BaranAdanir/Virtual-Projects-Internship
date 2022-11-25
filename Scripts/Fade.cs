using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private float targetValue = 40f;
    [SerializeField] private float fadeTime = 2f;

    private CanvasRenderer elementToFade;

    [SerializeField] private Image[] buttonImages;
    [SerializeField] private Color targetColor;
    [SerializeField] private Color targetButtonsColor;
    [SerializeField] private GameObject initialButton;

    private void Start()
    {
        elementToFade = gameObject.GetComponent<CanvasRenderer>();
        StartCoroutine(LerpFunction(targetValue, fadeTime, 1f));
    }

    public void FinishStart()
    {
        initialButton.SetActive(false);
        StartCoroutine(LerpFunction(0, 1, .1f));
        StartCoroutine(ButtonsLerp(buttonImages, targetButtonsColor, 2, .1f));
    }

    private IEnumerator LerpFunction(float endValue, float duration, float delay)
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
        initialButton.SetActive(true);
    }

    private IEnumerator ButtonsLerp(Image[] images, Color endValue, float fadeRate, float delay)
    {
        float time = 0;
        Color currentColor = images[0].color;
        yield return new WaitForSeconds(delay);
        while (Mathf.Abs(currentColor.a - endValue.a) > 0.0001f)
        {
            for (int i = 0; i < images.Length; i++)
            {
                currentColor.a = Mathf.Lerp(currentColor.a, endValue.a, fadeRate * Time.deltaTime);
                images[i].color = currentColor;
                time += Time.deltaTime;
            }
            yield return null;
        }
    }
}
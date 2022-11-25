using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFade : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private Color[] colors;
    private bool initialLerped;
    private bool finalLerped;

    void Start()
    {
        initialLerped = false;
        finalLerped = false;
    }

    void Update()
    {
        if(NewTimer.spawnFinished && !initialLerped)
        {
            for(int i = 0; i < images.Length; i++)
            {
                StartCoroutine(LerpStarsFunction(images[i], colors[0], 3, 0f));
                initialLerped = true;
            }
        }
        if(LevelFinisher.isLevelFinished && !finalLerped)
        {

            for (int i = 0; i < images.Length; i++)
            {
                StartCoroutine(LerpStarsFunction(images[i], colors[1], 1.5f, 0f));
                finalLerped = true;
            }
        }
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

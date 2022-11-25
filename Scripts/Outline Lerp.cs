using System.Collections;
using UnityEngine;

public class OutlineLerp : MonoBehaviour
{
    private Material outline;

    private void Start()
    {
        outline = GetComponent<Material>();
    }

    private void Update()
    {
        if(Spawner.hasFinished)
        {
            StartCoroutine(ButtonsLerp(outline, new Color(0, 0, 0, 0), 2, .1f));
        }
    }

    private IEnumerator ButtonsLerp(Material outline, Color endValue, float fadeRate, float delay)
    {
        float time = 0;
        Color currentColor = outline.color;
        yield return new WaitForSeconds(delay);
        while (Mathf.Abs(currentColor.a - endValue.a) > 0.0001f)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, endValue.a, fadeRate * Time.deltaTime);
            outline.color = currentColor;
            time += Time.deltaTime;
            
            yield return null;
        }
    }
}
    
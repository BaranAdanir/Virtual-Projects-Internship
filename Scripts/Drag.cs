using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    [SerializeField] private Color targetColor;
    [SerializeField] private float fadeRate = .5f;
    [SerializeField] private GameObject[] destroyObjects;

    private Color finishColor;
    private Image spriteToFade;

    private void Start()
    {
        for (int i = 0; i < destroyObjects.Length; i++)
        {
            destroyObjects[i].SetActive(true);
        }

        spriteToFade = gameObject.GetComponent<Image>();
        if(spriteToFade.IsActive())
        {
            StartCoroutine(LerpFunction(targetColor, 2 * fadeRate, 3, false));
            finishColor = spriteToFade.color;
        }
        
    }

    public void FinishStart()
    {
        if(spriteToFade.IsActive())
        {
            StartCoroutine(LerpFunction(finishColor, 4, .1f, true));
        }
    }

    private IEnumerator LerpFunction(Color endValue, float fadeRate, float delay, bool isFinish)
    {
        yield return new WaitForSeconds(delay);

        Color currentColor = spriteToFade.color;
        
        while (Mathf.Abs(currentColor.a - endValue.a) > 0.0001f)
        {
            currentColor.a = Mathf.Lerp(currentColor.a, endValue.a, fadeRate * Time.deltaTime);
            spriteToFade.color = currentColor;
            yield return null;
        }

        if (isFinish)
        {
            Spawner.hasFinished = true;
            NewSpawner.hasFinished = true;
            Rotate.inputOn = true;

            for (int i = 0; i < destroyObjects.Length; i++)
            {
                destroyObjects[i].SetActive(false);
            }
        }
    }
}
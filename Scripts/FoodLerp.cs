using System.Collections.Generic;
using UnityEngine;

public class FoodLerp : MonoBehaviour
{
    [SerializeField] private GameObject endPosition;
    [SerializeField] private float desiredDuration;
    [SerializeField] private AnimationCurve curve;

    private Transform startPosition;
    private float elapsedTime;

    public static bool rotationFinished;
    public static List<GameObject> rotate = new();

    private void Start()
    {
        rotate.Clear();
    }

    private void Update()
    {
        //Debug.Log(rotate.Count);

        if (Freeze.levelFinished)
        {
            for (int i = 0; i < rotate.Count; i++)
            {
                Lerp(rotate[i]);
            }       
        }
    }

    private void Lerp(GameObject piece)
    {
        startPosition = piece.transform;
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        piece.transform.rotation = Quaternion.Lerp(startPosition.rotation, endPosition.transform.rotation, curve.Evaluate(percentageComplete));

        if (piece.transform.rotation == endPosition.transform.rotation)
        {
            rotationFinished = true;
        }
    }
}

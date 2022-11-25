using UnityEngine;

public class QuaternionLerp : MonoBehaviour
{
    [SerializeField] private GameObject endPosition;
    [SerializeField] private float desiredDuration;
    [SerializeField] private AnimationCurve curve;

    private Transform startPosition;
    private float elapsedTime;

    public static bool rotationFinished;

    private void Start()
    {
        rotationFinished = false;
    }

    private void Update()
    {
        startPosition = transform;

        if (Freeze.levelFinished)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.rotation = Quaternion.Lerp(startPosition.rotation, endPosition.transform.rotation, curve.Evaluate(percentageComplete));

            if (transform.rotation == endPosition.transform.rotation)
            {
                rotationFinished = true;
            }
        }
    }
}

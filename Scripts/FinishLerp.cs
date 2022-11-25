using UnityEngine;


public class FinishLerp : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float desiredDuration;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private GameObject outline;

    private Vector3 startPosition;
    private float elapsedTime;

    private void Update()
    {
        startPosition = transform.position;

        if (QuaternionLerp.rotationFinished)
        {

            if ((Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, outline.transform.position.y - 4f, this.transform.position.z))) < 2f)
            {
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / desiredDuration;
                transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
            }
            LevelFinisher.isLevelFinished = true;
            NewLevelFinisher.isLevelFinished = true;
        }
    }

    
}

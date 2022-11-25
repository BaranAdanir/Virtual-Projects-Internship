using UnityEngine;

public class NewStartTimer : MonoBehaviour
{
    private bool hasTimerStarted;

    private void Start()
    {
        hasTimerStarted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasTimerStarted)
        {
            
            NewTimer.spawnFinished = true;
            hasTimerStarted = true;
        }
    }
}

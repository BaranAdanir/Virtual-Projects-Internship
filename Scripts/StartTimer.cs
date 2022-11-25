using UnityEngine;

public class StartTimer : MonoBehaviour
{
    private bool hasTimerStarted;

    private void Start()
    {
        hasTimerStarted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!hasTimerStarted)
        {
            Timer.spawnFinished = true;
            hasTimerStarted = true;           
        }
    }
}

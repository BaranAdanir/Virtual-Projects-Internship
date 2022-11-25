using UnityEngine;

public class Fail : MonoBehaviour
{

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            NewTimer.timerIsRunning = false;
            Freeze.levelFinished = true;
            Rotate.inputOn = false; 
        }
    }
}

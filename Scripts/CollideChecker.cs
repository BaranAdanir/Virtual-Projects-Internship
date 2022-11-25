using UnityEngine;

public class CollideChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Cake"))
        {
            CheckStars.collided = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Cake"))
        {
            CheckStars.collided = false;
        }
    }
}

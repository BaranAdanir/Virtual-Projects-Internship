using UnityEngine;

public class Freeze : MonoBehaviour
{
    private Rigidbody rb;
    public static bool levelFinished;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        levelFinished = false;
    }

    private void Update()
    {
        if(levelFinished)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}

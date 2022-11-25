using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force;
    private float multiplier;

    public static bool inputOn;

    private void Start()
    {
        Time.timeScale = 1.3f;
        rb = GetComponent<Rigidbody>();
        inputOn = false;
    }

    private void FixedUpdate()
    {
        if(inputOn)
        {
            if (Input.touchCount == 1)
            {
                Touch screenTouch = Input.GetTouch(0);

                if (screenTouch.phase == TouchPhase.Moved)
                {
                    if (Spawner.spawnedObjects == 0)
                    {
                        multiplier = Time.fixedDeltaTime * force * 100;
                    }
                    else
                    {
                        multiplier = Time.fixedDeltaTime * force * 100 * Spawner.spawnedObjects;
                    }

                    rb.AddTorque(0f, -screenTouch.deltaPosition.x * multiplier, 0f);
                    rb.AddTorque(screenTouch.deltaPosition.y * multiplier, 0f, 0f);
                }
            }
        } 
    }
}

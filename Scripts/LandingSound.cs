using UnityEngine;

public class LandingSound : MonoBehaviour
{
    [SerializeField] private AudioSource landSound;

    private bool isHit;
    private bool played;

    private void Start()
    {
        isHit = false;
        played = false;
    }

    
    private void Update()
    {
        landSound.mute = Volume.landSound;

        if(isHit)
        {
            if(!played)
            {
                //Debug.Log("Oynattim");
                landSound.Play();
                played = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Cake"))
        {
            isHit = true;
        }
    }
}

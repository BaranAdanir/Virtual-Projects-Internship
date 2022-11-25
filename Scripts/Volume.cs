using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private GameObject onButton;
    [SerializeField] private GameObject offButton;
    [SerializeField] private AudioSource[] audios;

    public static bool landSound;

    private void Start()
    {
        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].mute = false;
            landSound = false;
        }
    }

    public void VolumeOn()
    {
        for(int i = 0; i < audios.Length; i++)
        {
            audios[i].mute = true;
            landSound = true;
        }

        onButton.SetActive(false);
        offButton.SetActive(true);
    }

    public void VolumeOff()
    {
        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].mute = false;
            landSound = false;
        }

        offButton.SetActive(false);
        onButton.SetActive(true);
    }
}

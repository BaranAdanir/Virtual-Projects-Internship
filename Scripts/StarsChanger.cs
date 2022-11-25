using UnityEngine;
using UnityEngine.UI;

public class StarsChanger : MonoBehaviour
{
    public static Image image;
    [SerializeField] private Sprite[] sprites;
    private int currentSpriteIndex;
    public static int newSpriteIndex;
    private bool changed;

    private void Start()
    {
        currentSpriteIndex = 0;
        newSpriteIndex = 0;
        image = GetComponent<Image>();
    }

    private void Update()
    {
        changed = (currentSpriteIndex != newSpriteIndex);

        if (changed)
        {
            //Debug.Log("Changed - New Index: " + newSpriteIndex);
            //Debug.Log("Current Index: " + currentSpriteIndex + " - New Index: " + newSpriteIndex);
            //Debug.Log(sprites[newSpriteIndex].name);
            image.sprite = sprites[newSpriteIndex];
            currentSpriteIndex = newSpriteIndex;
        }
    }
}

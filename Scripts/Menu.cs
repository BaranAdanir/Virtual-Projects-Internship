using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Sprite menu;
    [SerializeField] Image button;

    private void Start()
    {
        
    }


    private void Update()
    {
        
    }

    private void OnMouseOver()
    {
        button.sprite = menu;
    }
}

using UnityEngine;

public class CheckStars : MonoBehaviour
{
    [SerializeField] private GameObject outline;

    private bool increased;
    private bool decreased;

    public static bool collided;

    private void Start()
    {
        increased = false;
        decreased = true;
        collided = false;

        //Debug.Log(outline.name + ": " + outline.transform.position);
    }

    private void Update()
    {
        //Debug.Log(name + " - Position: " + transform.position + " - Distance: " + Vector3.Distance(this.transform.localPosition, new Vector3(this.transform.position.x, outline.transform.position.y - 4f, this.transform.position.z)));

        if((Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, outline.transform.position.y - 4f, this.transform.position.z))) < 1.5f && !increased && decreased && collided)
        {
            StarsChanger.newSpriteIndex++;
            increased = true;
            decreased = false;
            collided = false;
            if(!FoodLerp.rotate.Contains(gameObject))
            {
                FoodLerp.rotate.Add(gameObject);
            }

            if(DestroyFood.destroy.Contains(gameObject))
            {
                DestroyFood.destroy.Remove(gameObject);
            }
            
        }
        else if(Vector3.Distance(this.transform.position, new Vector3(this.transform.position.x, outline.transform.position.y - 4f, this.transform.position.z)) > 1.5f && increased && !decreased)
        {
            StarsChanger.newSpriteIndex--;
            increased = false;
            decreased = true;
            collided = true;
            if(FoodLerp.rotate.Contains(gameObject))
            {
                FoodLerp.rotate.Remove(gameObject);
            }

            if(!DestroyFood.destroy.Contains(gameObject))
            {
                DestroyFood.destroy.Add(gameObject);
            }
            
        }
    }
}

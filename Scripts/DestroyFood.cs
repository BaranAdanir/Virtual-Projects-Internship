using System.Collections.Generic;
using UnityEngine;

public class DestroyFood : MonoBehaviour
{
    public static List<GameObject> destroy = new();

    private void Start()
    {
        destroy.Clear();
    }

    private void Update()
    {
        if (Freeze.levelFinished)
        {
            LevelFinisher.isLevelFinished = true;
            for (int i = 0; i < destroy.Count; i++)
            {
                Destroy(destroy[i]);
            }
        }
    }
}

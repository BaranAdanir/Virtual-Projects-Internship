using System.Collections;
using UnityEngine;

public class NewSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 6f;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Vector3[] initialPositions;

    public static int spawnedObjects;
    public static bool hasFinished;

    private bool started;

    private void Start()
    {
        spawnedObjects = 0;
        started = false;
        hasFinished = false;
    }

    private void Update()
    {
        if (hasFinished && !started)
        {
            StartCoroutine(Spawn());
            started = true;
        }
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Instantiate(gameObjects[i], initialPositions[i], Quaternion.identity); 
      
            yield return new WaitForSeconds(spawnTime);
            spawnedObjects++;
        }
    }
}

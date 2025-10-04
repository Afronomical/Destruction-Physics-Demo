using System.Collections;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{

    [Tooltip("Put the object you would like to spawn in here")]
    [SerializeField] public GameObject spawnObject;

    [Space]

    [Tooltip("Time between each new object's creation (in seconds)")]
    [Min(0)][SerializeField] private float spawnInterval = 1.0f;

    [Tooltip("The limit for spawned objects this factory can make")]
    [Min(-1)][SerializeField] private int maxSpawned = 100;
    private int numberSpawned = 0;

    [Space]

    [Tooltip("Spawn the object at a slight offset to this objects position")]
    [SerializeField] public Vector3 spawnOffset = Vector3.zero;

    bool spawning = false;

    IEnumerator SpawnObject()
    {
    
    //Checks if an object is being spawned already (Cooldown is active)sa
        if (spawning) { yield break ; };

        
        //Ensures object count is kept below maximum.
        //      If maxSpawned is -1 will spawn continuosly
        if (maxSpawned < 0 || numberSpawned < maxSpawned)
        {
            spawning = true;

            Instantiate(spawnObject, transform.position + spawnOffset, spawnObject.transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
            ++numberSpawned;

            spawning = false;
        }
        

        
        

    }

    private void Update()
    {
        Spawn();
    }

    void Spawn()
    { 
            StartCoroutine(SpawnObject());
    }
}

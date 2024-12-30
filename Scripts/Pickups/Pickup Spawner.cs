using Unity.Mathematics;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //if it is there nothing spawns
        if(spawnedPickup == null)
        {
        //if its time to spawn a pickup
        if (Time.time > nextSpawnTime)
        {
            //spawn it and set the next time
            spawnedPickup = Instantiate(RandomPickup(), transform.position, quaternion.identity);
            nextSpawnTime = Time.time + spawnDelay;
        }
        }
        else
        {
            //if the object exist reset timer
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
        //gives us a random pickup
    public GameObject RandomPickup()
    {
        return pickupPrefab[UnityEngine.Random.Range(0, pickupPrefab.Length)];
    }
}
using Unity.Mathematics;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject[]enemyPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
    }
    //gives us a random enemy
    public GameObject RandomEnemy()
    {
        return enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];
    }
    //spawns whatever enemy it gives us
    public void SpawnEnemy()
    {
        Instantiate(RandomEnemy(), transform.position, quaternion.identity);
    }
}

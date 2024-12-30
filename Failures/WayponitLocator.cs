using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class WayponitLocator : MonoBehaviour
{
    public GameObject waypoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(waypoint, transform.position, quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

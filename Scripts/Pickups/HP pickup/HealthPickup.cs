using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthPowerup powerup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    //activates when ran into
    public void OnTriggerEnter(Collider other)
    {
        //stores other objects powerupcontroller
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        //if the other object has a powerup controller
        if(powerupManager != null)
        {
            //add the powerup
            powerupManager.Add(powerup);
            //destory the pickup
            Destroy(gameObject);
        }
    }
}

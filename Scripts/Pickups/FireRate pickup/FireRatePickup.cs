using Unity.VisualScripting;
using UnityEngine;

public class FireRatePickup : MonoBehaviour
{
    public FireRatePowerup powerup;
    public Powerups duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
    }
    //when you hit the object its in, it triggers
    public void OnTriggerEnter(Collider other)
    {
        //stores the others power up controller
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        //if the other object has a powerup manager, give it fireRatePowerup
        if (powerupManager != null)
        {
            powerupManager.Add(powerup);
            //destroys the pickup
            Destroy(gameObject);
        }
    }
}

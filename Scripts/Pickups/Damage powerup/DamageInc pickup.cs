using UnityEngine;
public class DamageIncpickup : MonoBehaviour
{
    public DamageIncPowerup powerup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        if(powerupManager != null)
        {
            powerupManager.Add(powerup);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    //floats for the amount of damage dealth and getting the pawn that did it. 
    public float damageDone;
    public Pawn owner; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //a script for dealing the damage, if the rigidbody collides with another it will trigger this, we use a trigger so it only activates once. 
    public void OnTriggerEnter(Collider other)
    {
        //gets the health component from whatever it hits. 
        Health otherHealth = other.gameObject.GetComponent<Health>();
        //checks if the other object has the health component 
        if (otherHealth != null)
        {
            //if it has health it deals damage
            otherHealth.TakeDamage(damageDone, owner);
        }
        //after dealing damage it destroys itself. 
        Destroy(gameObject);
    }
}

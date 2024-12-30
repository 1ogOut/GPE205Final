using UnityEngine;
using UnityEngine.SceneManagement;
//make it a child of shooter so it can gain all the code that shooter does and override its functions so it gainst hings through the shooter script. 
public class TankShooter : Shooter
{
    //gets the transform
    public Transform firepointTransform; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created, 
    public override void Start()
    {
    }
    // Update is called once per frame
    public override void Update()
    {   
    }
    //create the shoot function
    public override void Shoot(GameObject ShellPrefab, float fireForce, float damageDone, float lifespan)
    {
        //creates a new object that is a copy of Shell in the position of shooter(firepoint)
        GameObject newShell = Instantiate(ShellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        //gets the damage on hit component
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();
        //checks if the object has a damage on hit component
        if (doh != null)
        {
            //sets the damageDone 
            doh.damageDone = damageDone;
            //sets the owner of the pawn that shot the shell
            doh.owner = GetComponent<Pawn>();
        }
        //get the rigidbody component
        Rigidbody rb = newShell.GetComponent<Rigidbody>();
        //checks if it has a rigidbody component
        if (rb != null)
        {
            rb.AddForce(firepointTransform.forward * fireForce);
        }
        //destroys the shell
        Destroy(newShell, lifespan);
    }
}

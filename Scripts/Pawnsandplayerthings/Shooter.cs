using UnityEngine;
//we need to make everything abstract so its children can fill it in
public abstract class Shooter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();
    // Update is called once per frame
    public abstract void Update();
    //creates a public function called shoot which has a float for the fireforce, damage it will deal, and how long it will existas well as getting the gameobject shell
    public abstract void Shoot(GameObject ShellPrefab, float fireForce, float damageDone,float lifespan);
    
}

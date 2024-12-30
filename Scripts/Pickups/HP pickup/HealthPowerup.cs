using UnityEngine;
[System.Serializable]
public class HealthPowerup: Powerups
{
    public float healthtoAdd;
    public override void Apply(PowerupManager target)
    {
        //applies health changes
        Health targetHealth = target.GetComponent<Health>();
        if(targetHealth != null)
        {
            //gets the person to heal themselves
            targetHealth.Heal(healthtoAdd, target.GetComponent<Pawn>());
        }
    }
    public override void Remove(PowerupManager target)
    {
        
    }
}

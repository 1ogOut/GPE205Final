using UnityEngine;
[System.Serializable]
public class DamageIncPowerup: Powerups
{
    public float damageToAdd;
    public override void Apply(PowerupManager target)
    {
        //adds damage
        Pawn targetDamage = target.GetComponent<Pawn>();
        if(targetDamage != null)
        {
            targetDamage.IncreaseDamage(damageToAdd, target.GetComponent<Pawn>());
        }
    }
    public override void Remove(PowerupManager target)
    {
        //this does nothing, the buff is permanent
    }
}

using System.Collections.Generic;
using UnityEngine;

public abstract class Powerups
{
    
    public float duration;
    public bool isPermanent;
    public abstract void Apply(PowerupManager target);
    public abstract void Remove(PowerupManager target);
}

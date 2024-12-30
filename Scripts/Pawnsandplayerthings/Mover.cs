using System.Numerics;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    //creating the code that every type of mover will use, even if we only have tankMover these being here to be put into other movies will be helpful
    public abstract void Start();
    public abstract void Move(UnityEngine.Vector3 direction, float speed);
     public abstract void Rotate(float turnspeed);
    
}

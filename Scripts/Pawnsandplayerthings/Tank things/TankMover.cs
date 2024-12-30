using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;

public class TankMover : Mover
{
    //shortcuts for the transform and rigidbody
    private Rigidbody rb;
    private Transform tf;
    // when the game starts the shortcuts will get the rigidbody component, and the transform
    public override void Start()
    {
       rb = GetComponent<Rigidbody>();
       tf = transform;
    }
    
    //creates the code for move, so it gets the proper direction to move, as well as creates the float speed 
    public override void Move(UnityEngine.Vector3 direction, float speed)
    {
        //makes it where when move is done, it sets the speed and direction
       UnityEngine.Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
       //gets the rigid body to take its position and add onto the moveVector amount to get it to teleport to there 
       rb.MovePosition(rb.position + moveVector);
    }
    //creates the float for turnspeed and the code for it
    public override void Rotate(float turnspeed)
    {
        //gets the tranform, and moves it by the Y axis acorindg ot the turnspeed. 
        tf.Rotate(0, turnspeed * Time.deltaTime, 0);
    }
}

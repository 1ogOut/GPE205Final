using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Playables;
[System.Serializable]
public class PlayerController : Controller
{
    //makes the keycodes public so you can edit them from the script on the engine itself
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;
    public bool Dead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        //checks if we have a game manager
        if (GameManager.instance != null)
        {
            //checks if its tracking the players
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
        base.Start();
    }

    // Update is called once per frame, process inputs makes it where its always looking for inputs
    public override void Update()
    {
        ProcessInputs();
        base.Update();
    }

    //If the correct key is being pushed down it will call the script 
    public void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

         if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

         if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

         if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        
        if (Input.GetKey(shootKey))
        {
            pawn.Shoot();
        }
    }
    public void OnDestroy()
    {
        GameManager.instance.ActivateGameOverScreen();
        //if game manager
        if(GameManager.instance != null) 
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Remove(this);
            }
        }
    }
}

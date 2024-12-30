using System;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.Playables;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class AIController : Controller
{
    public GameObject target;
    private float lastStateChangeTime;
    public enum AIState {Idle, Seek, Attack, flee, patrol, choose};
    public AIState currentState;
    public float fleeDistance;
    public Transform[] waypoints;
    public float waypointStopDistance;
    private int currentWaypoint = 0;
    public float fieldOfView;
    public bool deactivate;
    public override void Start()
    {
        base.Start();
        ChangeState(AIState.choose);
    }
    // Update is called once per frame
    public override void Update()
    {
        if (pawn != null)
        {
            
                MakeDecisions();
                base.Update();
            
        }
    }
    //code to target the player
    public void TargetPlayerOne()
    {
        //if game manager exist
        if (GameManager.instance != null)
        {
            //and an array of players exist
            if (GameManager.instance.players != null)
            {
                //and there are players
                if (GameManager.instance.players.Count > 0)
                {
                    //then target the gameobject ofthe pawn of the first plaeyr on the list
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }
    public void targetPlayerTwo()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {
                if (GameManager.instance.players.Count >1)
                target = GameManager.instance.players[1].pawn.gameObject;
            }
        }
    }
    protected bool IsHasTarget()
    {
        //return tre if we have a target false if we dont
        return(target != null);
    }

    //decision making code
    public virtual void MakeDecisions()
    {
    }
    //function to change state
    public virtual void ChangeState(AIState newState)
    {
        //change current state
        currentState = newState;
        //saves the time we changed the state
        lastStateChangeTime = Time.time;
    }
    //transition code, finds out if we are close to the player 
    protected bool IsDisntanceLessThan(GameObject target, float distance)
    {
        if (UnityEngine.Vector3.Distance (pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //state code
    protected virtual void DoSeekState()
    {
        Seek(target);
    }
    //seek code
    //finds our target then runs toward them
    public void Seek(GameObject target)
    {
        Seek(target.transform);
        pawn.MoveForward();
    }
    //rotates our pawn toward the target
    public void Seek(UnityEngine.Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition); 
    }
    //gets the rotation of the target and finds out where they are. 
    public void Seek(Transform targetTransform)
    {
        Seek(targetTransform.position);
        pawn.MoveForward();

    }
    //Idle state code
    protected virtual void DoIdleState()
    {
        //Chill man
    }
    protected virtual void DoAttackState()
    {
        Seek(target);
        Shoot();
    }
    public void Shoot()
    {
        pawn.Shoot();
    }
    //fleeing code
    protected void Flee()
    {
        //find the direction to our target
        UnityEngine.Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        //find the vector away from our target by negativizing it 
        UnityEngine.Vector3 vectorAwayFromTarget = -vectorToTarget;
        //find the vector we travel by
        UnityEngine.Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
        //Seek() flee vector 
        Seek(pawn.transform.position + fleeVector);
        float targetDistance = UnityEngine.Vector3.Distance(target.transform.position, pawn.transform.position);
        float percentOffleeDistance = targetDistance / fleeDistance;
        percentOffleeDistance = Mathf.Clamp01(percentOffleeDistance);
    }
    //I know this isn't how we were told to do it but the way it was set, I couldn't stop it from just staying in one area, so I decided to try just making it go backwards
    //it worked, and I enjoy the look of the tank moving backwards, I feel like it works well at making it look scared.  I am going to do the flee code and test that thoough. 
    protected void Flee2()
    {
        Seek(target.transform.position);
        pawn.MoveBackward();
    }

    //waypoint/patrol code
    protected void patrol()
    {
        //check if theres enough waypoints to move to our current goal
        if (waypoints.Length > currentWaypoint)
        {
            //seek the waypoint
            Seek(waypoints[currentWaypoint]);
            //if were close enough move to the next waypoint. 
            if (UnityEngine.Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            RestartPatrol();
        }
    }
    protected void RestartPatrol()
    {
        currentWaypoint = 0;
    }
}

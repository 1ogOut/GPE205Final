using System;
using System.IO;
using JetBrains.Annotations;
using Mono.Cecil.Cil;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{

    //move speed variable
    public float moveSpeed;
    //turn speed variable
    public float turnSpeed;
    //firerate variable
    public float fireRate;
    //storing our mover. 
    public Mover mover; 
    //gets our shooter
    public Shooter shooter; 
    //nosiemaker variable
    public NoiseMaker noiseMaker;
    public float movingVolumeDistance;


    //when the game starts, it will get the mover to obtain the Mover copmonent 
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        noiseMaker = GetComponent<NoiseMaker>();
    }

    // needs to be here and public so TankPawn can get it even if theres nothing in it
    public virtual void Update()
    {
    }
    public void IncreaseFireRate(float amount, Pawn source)
    {
        //adds the amount to the fireRate
        fireRate = fireRate + amount; 
    }
    public void IncreaseDamage(float damageAmount, Pawn source)
    {
        //adds amount to Damage
        damageDone = damageDone + damageAmount;
    }
    public GameObject ShellPrefab;
    public float fireForce;
    public float damageDone;
    public float ShellLifespan;

    //scripts for the move commands
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);

}

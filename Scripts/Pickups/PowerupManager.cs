using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerupManager : MonoBehaviour
{
    public List<Powerups> powers;
    private List<Powerups> removedPowersQueue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powers = new List<Powerups>();
        removedPowersQueue = new List<Powerups>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimer();
    }
    private void LateUpdate()
    {
        ApplyRemovePowersQueue();
    }
    public void Add(Powerups powerupToAdd)
    {
        //applies powerup
        powerupToAdd.Apply(this);
        //save it to the list
        powers.Add(powerupToAdd);
    }
    //to do, remove the powerup
    public void Remove(Powerups powerToRemove)
    {
        //removes powerup
        powerToRemove.Remove(this);
        //adds the power to the removal queue
        removedPowersQueue.Add(powerToRemove);
    }
    public void DecrementPowerupTimer()
    {
        //once at a time, put every object in powers into the powerup variable and loop it 
        foreach (Powerups powerups in powers)
        {
            //subtract the time it took to draw the frame
            powerups.duration -= Time.deltaTime;
            //if the time is up remove thte powerup
            if (powerups.duration <= 0)
            {
                Remove(powerups);
            }
        }
    }
    //removes powers from the powerups list
    private void ApplyRemovePowersQueue()
    {
        //remove the powers in the removal queue
        foreach (Powerups powerups in removedPowersQueue)
        {
            powers.Remove(powerups);
        }
        //reset the removal queue
        removedPowersQueue.Clear();
    }
}

using System;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //instance makes it where only this one can exist. 
    public static GameManager instance;
    //gets the transform of PlayerSpawn
    public PlayerSpawn PlayerSpawnTransform;
    public Player2Spawn player2SpawnTransform;
    public List<PlayerController> players;
    public PlayerSpawn[] spawnpoints;
    public Player2Spawn[] twospawnpoints;
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;
    public AIController AIcontroller;
    //Awake means this is the first thing that happens, this code looks for other instance's of gamemanagers and destroys them, without destroying this. 
    private void Awake ()
    {
        if (instance == null){
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else{ 
            Destroy(gameObject);
        }
        AIcontroller = GetComponent<AIController>();
    }
    //Code for Spawning the player
    public void SpawnPlayer()
    {
        Transform spawner = null;
        //if (spawnpoints == null)
        {
           spawnpoints = FindObjectsByType<PlayerSpawn>(FindObjectsSortMode.InstanceID);
        }
        if (spawnpoints.Length > 0)
        {
            spawner = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Length)].transform; 
        }
        if (spawner != null)
        {
        //Spawns in the playercontroller and tank
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity) as GameObject;
        GameObject newPawnObj = Instantiate(tankPawnPrefab, spawner.position, spawner.rotation) as GameObject;
        //makes newPlayerOBj(the player controller) the controller of the game by getting them and assinging them 
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        newController.pawn = newPawn;
        }
        
    }
    public void SpawnPlayerTwo()
    {
        Transform spawnerTwo = null;
        //if 
        {
            twospawnpoints = FindObjectsByType<Player2Spawn>(FindObjectsSortMode.InstanceID);
        }
        if (twospawnpoints.Length > 0)
        {
            spawnerTwo = twospawnpoints[UnityEngine.Random.Range(0, twospawnpoints.Length)].transform;
        }
        if (spawnerTwo != null)
        {
            GameObject twoPlayerObj = Instantiate(twoControllerPrefab, UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity) as GameObject;
            GameObject twoPawnObj = Instantiate(twoTankPrefab, spawnerTwo.position, spawnerTwo.rotation) as GameObject;
            Controller twoController = twoPlayerObj.GetComponent<Controller>();
            Pawn newPawn = twoPawnObj.GetComponent<Pawn>();
            twoController.pawn = newPawn;
        }
    }
    //
    public GameObject tankPawnPrefab;
    public GameObject playerControllerPrefab;
    public GameObject twoTankPrefab;
    public GameObject twoControllerPrefab;
    //makes it where when the game sstarts SpawnPlayer() is put into effect
    public void Start()
    {
        ActivateTitleScreen();

    }
    //deactivates all gamestates
    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }
    //activates a state
    public void ActivateTitleScreen()
    {
        //Deactivate all states
        DeactivateAllStates();
        //activate title screen
        TitleScreenStateObject.SetActive(true);
        Debug.Log("Title screen active");
    }
    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
        Debug.Log("Main menu screen active");

    }
    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
        Debug.Log("Options screen active");
    }
    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        CreditsScreenStateObject.SetActive(true);
        Debug.Log("Credits screen active");
    }
    public void ActivateGameplay()
    {
        DeactivateAllStates();
        GameplayStateObject.SetActive(true);
        SpawnPlayer();
        SpawnPlayerTwo();
        Debug.Log("Gameplay screen active");
    }
    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();
        GameOverScreenStateObject.SetActive(true);
        Debug.Log("GameOver screen active");
    }
}

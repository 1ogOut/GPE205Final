using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class MapGenerator : MonoBehaviour
{
    public GameObject[]gridPrefabs;
    //Rows = Y
    public int rows;
    //Collumn = X
    public int collums;
    //these need to equal the size of the rooms, otherwise they'll clip into eachother
    public float roomWidth = 25.0f;
    public float roomHeight = 25.0f;
    private Room[,] grid;
    public int mapSeed;
    public bool MapOfTheDay;
    public bool TimeMap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int DateToInt(DateTime dateToUse)
    {
        //add our date and return it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute;
    }

    //gives us a random room
    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
    }

    public void GenerateMap()
    {
        if (MapOfTheDay == true)
        {
            mapSeed = DateToInt(DateTime.Now.Date);
        }
        else if (TimeMap == true)
        {
        //create and set our seed
            int mapSeed = DateToInt(DateTime.Now);
            UnityEngine.Random.InitState(mapSeed);
        }
        //clears the grid
        grid = new Room[collums, rows];
        //for each grid row
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            //for each collumin the row
            for (int currentCollumn = 0; currentCollumn < collums; currentCollumn++)
            {
                //find out the location by taking the rooms width or height and multiplying it by what number collum or row it is
                float xPosition = roomWidth * currentCollumn;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);
                //create a room at the location
                GameObject tempRoomObj = Instantiate (RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;
                //set parent
                tempRoomObj.transform.parent = this.transform;
                //give it a name based on its coordinate 
                tempRoomObj.name = "room_" + currentCollumn + "," + currentRow;
                //get the room object
                Room tempRoom = tempRoomObj.GetComponent<Room>();
                //save it to the array grid
                grid[currentCollumn, currentRow] = tempRoom;

                //opens the doors
                //bottom/first row opens the north door
                if(currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                //top/last row opens the south door
                else if(currentRow == rows-1)
                {
                    Destroy(tempRoom.doorSouth);
                }
                else 
                {
                    Destroy(tempRoom.doorNorth);
                    Destroy(tempRoom.doorSouth);
                }
                //first collumd destroys the east door
                if(currentCollumn == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                //last collumn destroys the west door
                else if(currentCollumn == collums-1)
                {
                    Destroy(tempRoom.doorWest);
                }
                //if were in the middle destroy all doors
                else
                {
                    Destroy(tempRoom.doorWest);
                    Destroy(tempRoom.doorEast);
                }
            }
        }
    }
}

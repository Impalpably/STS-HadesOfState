using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksHandler : MonoBehaviour
{
    public static AllBlocksHandler instance;
    public CharacterHandler characterHandler;

    public GameObject player;
    private GameObject myPlayer;
    private Vector2 startPos;

    public GameObject stairs;
    private GameObject myStairs;

    public GameObject mainCamera;

    public GameObject startRoom;
    public int minStartPos = -15;
    public int maxStartPos = 15;

    public GameObject[] anyRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;

    public GameObject[] leftHall;
    public GameObject[] rightHall;
    public GameObject[] topHall;
    public GameObject[] bottomHall;

    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject wallGenerator;

    public int roomSize;
    public int roomSizeMin = 3;
    public int roomSizeMax = 10;

    public GameObject[] enemies;
    public GameObject[] bossEnemies;

    public GameObject[] items;

    public int maxEnemies = 12;
    public int minEnemies = 3;
    private int enemiesToSpawn = 0;

    public int maxItems = 4;
    public int minItems = 0;
    private int itemsToSpawn = 0;

    public LayerMask ActorLayer;

    public FadeToBlack blackScreen;

    private GameObject[] tiles;

    private void Awake()
    {
        if (instance != null)
        {
            // More than one Handler in a scene
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        characterHandler = CharacterHandler.instance;

        if (minEnemies == maxEnemies)
        {
            enemiesToSpawn = minEnemies;
        }
        else
        {
            enemiesToSpawn = Random.Range(minEnemies, maxEnemies);
        }

        if (minItems == maxItems)
        {
            itemsToSpawn = minItems;
        }
        else
        {
            itemsToSpawn = Random.Range(minEnemies, maxItems);
        }
        
        if (roomSizeMin == roomSizeMax)
        {
            roomSize = roomSizeMin;
        }
        else
        {
            roomSize = Random.Range(roomSizeMin, roomSizeMax);
        }
        
        startPos = new Vector2(Random.Range(minStartPos, maxStartPos), Random.Range(minStartPos, maxStartPos));

        SpawnStartRoom(startPos);

        Invoke("SpawnEnemies", 3f);
        Invoke("SpawnWalls", 3.5f);
    }

    void SpawnStartRoom(Vector2 startPos)
    {
        int roomArray = Random.Range(0, 4);

        Vector3 playerPos = startPos;

        switch (roomArray)
        {
            case 0:
                startRoom = leftRooms[Random.Range(0, leftRooms.Length)];
                playerPos = new Vector3(startPos.x + Random.Range(-2, 0), startPos.y + Random.Range(-1, 1), -0.01f);
                break;

            case 1:
                startRoom = rightRooms[Random.Range(0, rightRooms.Length)];
                playerPos = new Vector3(startPos.x + Random.Range(0, 2), startPos.y + Random.Range(-1, 1), -0.01f);
                break;

            case 2:
                startRoom = topRooms[Random.Range(0, topRooms.Length)];
                playerPos = new Vector3(startPos.x + Random.Range(-1, 1), startPos.y + Random.Range(0, 2), -0.01f);
                break;

            case 3:
                startRoom = bottomRooms[Random.Range(0, bottomRooms.Length)];
                playerPos = new Vector3(startPos.x + Random.Range(-1, 1), startPos.y + Random.Range(-2, 0), -0.01f);
                break;

            case 4:
                startRoom = anyRooms[Random.Range(0, anyRooms.Length)];
                playerPos = new Vector3(startPos.x + Random.Range(-1, 1), startPos.y + Random.Range(-1, 1), -0.01f);
                break;

            default:
                startRoom = anyRooms[Random.Range(0, anyRooms.Length)];
                playerPos = new Vector3(startPos.x + Random.Range(-1, 1), startPos.y + Random.Range(-1, 1), -0.01f);
                break;
        }

        Instantiate(startRoom, startPos, Quaternion.identity);

        Debug.Log(startRoom.ToString());

        // The player must always spawn within the starting room
        // The player is disabled to start with to not interfere with tile generation
        myPlayer = Instantiate(player, playerPos, Quaternion.identity);
        myPlayer.SetActive(false);

        mainCamera.transform.position = new Vector3(playerPos.x, playerPos.y, mainCamera.transform.position.z);
    }

    void SpawnEnemies()
    {
        Debug.Log("Spawning entities...");
        // Reenables the palyer so that other Actors can't be placed on top
        myPlayer.SetActive(true);
        mainCamera.transform.parent = myPlayer.transform;
        //myPlayer.GetComponent<BoxCollider2D>().enabled = true;

        // Get all the possible tiles available
        tiles = GameObject.FindGameObjectsWithTag("FloorTile");

        while(true)
        {
            GameObject stairsTile = tiles[Random.Range(0, tiles.Length)];
            if (stairsTile.name == "Room Tile")
            {
                Collider2D checkblock = Physics2D.OverlapCircle(stairsTile.transform.position, 0.1f, ActorLayer);
                float distanceToStairs = Vector2.Distance(stairsTile.transform.position, myPlayer.transform.position);

                // If the stairs would spawn underneath the player or too close to the player, relocate it
                if (checkblock || distanceToStairs < 3f)
                {
                    //Debug.Log("Current location too close to the player, recalculating...");
                }
                else
                {
                    myStairs = Instantiate(stairs, new Vector3(stairsTile.transform.position.x, stairsTile.transform.position.y, -0.007f), Quaternion.identity);
                    myStairs.name = "Stairs";
                    characterHandler.stairs = myStairs;
                    //Debug.Log("Stairs created!");
                    //Debug.Log(distanceToStairs);
                    break;
                } 
            }
        }

        if (enemiesToSpawn > 0)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                GameObject myTile = tiles[Random.Range(0, tiles.Length)];

                // Ensures to only spawn in Rooms and not Halls
                while (true)
                {
                    if (myTile.name == "Room Tile")
                    {
                        // Checks if the tile is free to spawn an enemy
                        Collider2D checkblock = Physics2D.OverlapCircle(myTile.transform.position, 0.1f, ActorLayer);

                        // Ensures not to spawn too close to the player
                        float distanceToPlayer = Vector2.Distance(myTile.transform.position, myPlayer.transform.position);
                        if (checkblock || distanceToPlayer < 3f)
                        {
                            // If the tile holds the player or an enemy already, it can't be placed on top, so it needs to find a new place
                            //Debug.Log("Duplicate placement for enemy!");
                            myTile = tiles[Random.Range(0, tiles.Length)];
                        }
                        else
                        {
                            // Places a random enemy if it is free
                            int randomEnemy = Random.Range(0, enemies.Length);

                            GameObject myEnemy = Instantiate(enemies[randomEnemy], new Vector3(myTile.transform.position.x, myTile.transform.position.y, -0.009f), Quaternion.identity);
                            //Debug.Log("Placed enemy.");
                            break;
                        }
                    }
                    else
                    {
                        myTile = tiles[Random.Range(0, tiles.Length)];
                    }
                }


            }
        }

        if (itemsToSpawn > 0)
        {
            for (int i = 0; i < itemsToSpawn; i++)
            {
                GameObject myTile = tiles[Random.Range(0, tiles.Length)];

                // Ensures to only spawn in Rooms and not Halls
                while (true)
                {
                    if (myTile.name == "Room Tile")
                    {
                        // Checks if the tile is free to spawn an item
                        Collider2D checkblock = Physics2D.OverlapCircle(myTile.transform.position, 0.1f, ActorLayer);
                        if (checkblock)
                        {
                            // If the tile holds the player, enemy or item already, it can't be placed on top
                            //Debug.Log("Duplicate placement for item!");
                            myTile = tiles[Random.Range(0, tiles.Length)];
                        }
                        else
                        {
                            // Places a random item if it is free
                            int randomItem = Random.Range(0, enemies.Length);

                            GameObject myItem = Instantiate(items[randomItem], new Vector3(myTile.transform.position.x, myTile.transform.position.y, -0.008f), Quaternion.identity);
                            //Debug.Log("Placed item.");
                            break;
                        }
                    }
                    else
                    {
                        myTile = tiles[Random.Range(0, tiles.Length)];
                    }
                }
            }
        }
    }

    void SpawnWalls()
    {
        Debug.Log("Spawning walls...");
        // Number of TileGenerators in Wall Generator
        int wallGeneratorLength = 15;

        // How manay Wall Generators we want to spawn in each direction
        // Must be odd
        int wallGeneratorCount = 7;
        int halfCount = Mathf.FloorToInt(wallGeneratorCount / 2);

        for (int i = 0; i < wallGeneratorCount; i++)
        {
            int xDistance = (i - halfCount) * wallGeneratorLength;

            for (int j = 0; j < wallGeneratorCount; j++) 
            {
                int yDistance = (j - halfCount) * wallGeneratorLength;
                Vector2 spawnPos = new Vector2(startPos.x + xDistance, startPos.y + yDistance);
                Instantiate(wallGenerator, spawnPos, Quaternion.identity);
            }
        }
        Invoke("BeginMovement", 1f);
    }

    void BeginMovement()
    {
        foreach(GameObject myTile in tiles)
        {
            myTile.GetComponent<BoxCollider2D>().enabled = false;
        }

        // Allows the stairs to be stepped on
        characterHandler.stairs.GetComponent<BoxCollider2D>().isTrigger = true;

        blackScreen.fading = true;
    }
}

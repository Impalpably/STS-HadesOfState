using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksHandler : MonoBehaviour
{
    public GameObject player;
    private GameObject myPlayer;
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
    public GameObject[] wallTilesLarge;

    public int roomSize;

    public GameObject[] enemies;
    public GameObject[] bossEnemies;

    public GameObject[] items;

    public int maxEnemies = 12;
    public int minEnemies = 3;
    private int enemiesToSpawn;

    public int maxItems = 4;
    public int minItems = 0;
    private int itemsToSpawn;

    public LayerMask ActorLayer;

    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = Random.Range(minEnemies, maxEnemies);
        itemsToSpawn = Random.Range(minEnemies, maxItems);

        Vector2 startPos = new Vector2(Random.Range(minStartPos, maxStartPos), Random.Range(minStartPos, maxStartPos));

        SpawnStartRoom(startPos);

        Invoke("SpawnEnemies", 2f);
    }

    void SpawnStartRoom(Vector2 startPos)
    {
        int roomArray = Random.Range(0, 4);
        
        switch(roomArray)
        {
            case 0:
                startRoom = leftRooms[Random.Range(0, leftRooms.Length)];
                break;

            case 1:
                startRoom = rightRooms[Random.Range(0, rightRooms.Length)];
                break;

            case 2:
                startRoom = topRooms[Random.Range(0, topRooms.Length)];
                break;

            case 3:
                startRoom = bottomRooms[Random.Range(0, bottomRooms.Length)];
                break;

            case 4:
                startRoom = anyRooms[Random.Range(0, anyRooms.Length)];
                break;

            default:
                startRoom = anyRooms[Random.Range(0, anyRooms.Length)];
                break;
        }

        Instantiate(startRoom, startPos, Quaternion.identity);

        Vector3 playerPos = new Vector3(startPos.x + Random.Range(-1, 1), startPos.y + Random.Range(-1, 1), -0.01f);
        myPlayer = Instantiate(player, playerPos, Quaternion.identity);

        mainCamera.transform.position = new Vector3(playerPos.x, playerPos.y, mainCamera.transform.position.z);
    }

    void SpawnEnemies()
    {
        myPlayer.GetComponent<BoxCollider2D>().enabled = true;

        // Get a random tile
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("FloorTile");

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject myTile = tiles[Random.Range(0, tiles.Length)];

            // Checks if the tile is free to spawn an enemy
            Collider2D checkblock = Physics2D.OverlapCircle(myTile.transform.position, 0.1f, ActorLayer);
            if (checkblock)
            {
                // If the tile holds the player or an enemy already, it can't be placed on top
                Debug.Log("Duplicate placement for enemy!");
            }
            else
            {
                // Places a random enemy if it is free
                int randomEnemy = Random.Range(0, enemies.Length);

                GameObject myEnemy = Instantiate(enemies[randomEnemy], new Vector3(myTile.transform.position.x, myTile.transform.position.y, -0.009f), Quaternion.identity);
                //Debug.Log("Placed enemy.");
            }
        }

        for (int i = 0; i < itemsToSpawn; i++)
        {
            GameObject myTile = tiles[Random.Range(0, tiles.Length)];

            // Checks if the tile is free to spawn an item
            Collider2D checkblock = Physics2D.OverlapCircle(myTile.transform.position, 0.1f, ActorLayer);
            if (checkblock)
            {
                // If the tile holds the player, enemy or item already, it can't be placed on top
                Debug.Log("Duplicate placement for item!");
            }
            else
            {
                // Places a random item if it is free
                int randomItem = Random.Range(0, enemies.Length);

                GameObject myItem = Instantiate(items[randomItem], new Vector3(myTile.transform.position.x, myTile.transform.position.y, -0.008f), Quaternion.identity);
                //Debug.Log("Placed item.");
            }
        }
    }
}

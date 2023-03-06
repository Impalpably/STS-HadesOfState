using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksHandler : MonoBehaviour
{
    public GameObject[] leftHall;
    public GameObject[] rightHall;
    public GameObject[] topHall;
    public GameObject[] bottomHall;

    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    
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

        Invoke("SpawnEnemies", 2f);
    }

    void SpawnEnemies()
    {
        // Get a random tile
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("FloorTile");

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject myTile = tiles[Random.Range(0, tiles.Length)];

            //Checks if the tile is free to spawn an enemy
            Collider2D checkblock = Physics2D.OverlapCircle(myTile.transform.position, 0.1f, ActorLayer);
            if (checkblock)
            {
                // If the tile holds the player or an enemy already, it can't be placed on top
                Debug.Log("Duplicate placement!");
            }
            else
            {
                // Places a random enemy if it is free
                int randomEnemy = Random.Range(0, enemies.Length);

                GameObject myEnemy = Instantiate(enemies[randomEnemy], myTile.transform.position, Quaternion.identity);
                //Debug.Log("Placed enemy.");
            }
        }

        for (int i = 0; i < itemsToSpawn; i++)
        {
            GameObject myTile = tiles[Random.Range(0, tiles.Length)];

            //Checks if the tile is free to spawn an item
            Collider2D checkblock = Physics2D.OverlapCircle(myTile.transform.position, 0.1f, ActorLayer);
            if (checkblock)
            {
                // If the tile holds the player, enemy or item already, it can't be placed on top
                Debug.Log("Duplicate placement!");
            }
            else
            {
                // Places a random item if it is free
                int randomItem = Random.Range(0, enemies.Length);

                GameObject myEnemy = Instantiate(items[randomItem], myTile.transform.position, Quaternion.identity);
                //Debug.Log("Placed item.");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    // Floor = 0, Wall = 1
    public int type;
    public bool isRoomTile;

    private Collider2D collidedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnCheck()
    {
        // Checks if something is already placed on this tile 
        collidedObject = Physics2D.OverlapCircle((Vector2)transform.position, 0.2f);

        if (collidedObject)
        {
            Destroy(this.gameObject);
            return;
        }

        // Spawn room block
        AllBlocksHandler handler = AllBlocksHandler.instance; //GameObject.FindGameObjectWithTag("GameController").GetComponent<AllBlocksHandler>();

        GameObject block = null;

        int spawnRandom = 0;

        switch (type)
        {
            // Floor
            case 0:
                spawnRandom = Random.Range(0, handler.floorTiles.Length);
                block = Instantiate(handler.floorTiles[spawnRandom], transform.position, Quaternion.identity);
                block.transform.parent = GameObject.Find("Floor Tile List").transform;

                if (isRoomTile)
                {
                    block.name = "Room Tile";
                }
                else
                {
                    block.name = "Hall Tile";
                }

                break;

            // Wall
            case 1:
                spawnRandom = Random.Range(0, handler.wallTiles.Length);
                block = Instantiate(handler.wallTiles[spawnRandom], transform.position, Quaternion.identity);
                block.transform.parent = GameObject.Find("Wall Tile List").transform;
                block.name = "Wall Tile";
                break;

            // Defaults to Floor
            default:
                spawnRandom = Random.Range(0, handler.floorTiles.Length);
                block = Instantiate(handler.floorTiles[spawnRandom], transform.position, Quaternion.identity);
                block.transform.parent = GameObject.Find("Floor Tile List").transform;

                if (isRoomTile)
                {
                    block.name = "Room Tile";
                }
                else
                {
                    block.name = "Hall Tile";
                }

                break;
        }

        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private Collider2D collidedObject;

    // Left = 0, Right = 1, Top = 2, Bottom = 3
    public int direction = 0;
    // True for Yes, False for No
    public bool createHall;

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
        AllBlocksHandler handler = GameObject.FindGameObjectWithTag("GameController").GetComponent<AllBlocksHandler>();

        // If no more rooms, don't spawn
        if (handler.roomSize <= 0)
        {
            Destroy(this.gameObject);
            return;
        }

        GameObject block = null;

        int spawnRandom = 0;

        // If we're not creating a Hall, we're creating a Room instead
        if (!createHall)
        {
            switch(direction)
            {
                // Left
                case 0:
                    spawnRandom = Random.Range(0, handler.leftRooms.Length);
                    block = Instantiate(handler.leftRooms[spawnRandom], transform.position, Quaternion.identity);
                    break;
                
                // Right
                case 1:
                    spawnRandom = Random.Range(0, handler.rightRooms.Length);
                    block = Instantiate(handler.rightRooms[spawnRandom], transform.position, Quaternion.identity);
                    break;
                
                // Top
                case 2:
                    spawnRandom = Random.Range(0, handler.topRooms.Length);
                    block = Instantiate(handler.topRooms[spawnRandom], transform.position, Quaternion.identity);
                    break;
                
                // Bottom
                case 3:
                    spawnRandom = Random.Range(0, handler.bottomRooms.Length);
                    block = Instantiate(handler.bottomRooms[spawnRandom], transform.position, Quaternion.identity);
                    break;
                   
                // Defaults to Left
                default:
                    spawnRandom = Random.Range(0, handler.leftRooms.Length);
                    block = Instantiate(handler.leftRooms[spawnRandom], transform.position, Quaternion.identity);
                    break;
            }
        }

        // If we're not creating a Room, we're creating a Hall instead
        else
        {
            switch (direction)
            {
                // Left
                case 0:
                    spawnRandom = Random.Range(0, handler.leftHall.Length);
                    block = Instantiate(handler.leftHall[spawnRandom], transform.position, Quaternion.identity);
                    break;

                // Right
                case 1:
                    spawnRandom = Random.Range(0, handler.rightHall.Length);
                    block = Instantiate(handler.rightHall[spawnRandom], transform.position, Quaternion.identity);
                    break;

                // Top
                case 2:
                    spawnRandom = Random.Range(0, handler.topHall.Length);
                    block = Instantiate(handler.topHall[spawnRandom], transform.position, Quaternion.identity);
                    break;

                // Bottom
                case 3:
                    spawnRandom = Random.Range(0, handler.bottomHall.Length);
                    block = Instantiate(handler.bottomHall[spawnRandom], transform.position, Quaternion.identity);
                    break;

                // Defaults to Left
                default:
                    spawnRandom = Random.Range(0, handler.leftHall.Length);
                    block = Instantiate(handler.leftHall[spawnRandom], transform.position, Quaternion.identity);
                    break;
            }
        }

        handler.roomSize -= 1;
        Destroy(this.gameObject);
    }


}

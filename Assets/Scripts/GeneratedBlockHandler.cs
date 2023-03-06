using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedBlockHandler : MonoBehaviour
{
    // Create another block set

    public TileGenerator[] tilesToGenerate;
    public RoomGenerator[] roomsToGenerate;

    // Start is called before the first frame update
    void Start()
    {
        tilesToGenerate = GetComponentsInChildren<TileGenerator>();
        roomsToGenerate = GetComponentsInChildren<RoomGenerator>();

        Invoke("StartGeneration", Random.Range(0.1f, 0.3f));
    }

    void StartGeneration()
    {
        // Begins the generation for each tile and room
        foreach (TileGenerator tile in tilesToGenerate)
        {
            tile.SpawnCheck();
            tile.transform.parent = null;
        }

        foreach (RoomGenerator room in roomsToGenerate)
        {
            room.SpawnCheck();
            room.transform.parent = null;
        }

        Destroy(this.gameObject);
    }

}

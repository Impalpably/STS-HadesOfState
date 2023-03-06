using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    public Sprite[] floorTiles;
    public Sprite[] floorThreeSides;
    public Sprite[] floorTwoSides;
    public Sprite[] floorTwoSidesCorner;

    public SpriteRenderer floor;
    public LayerMask checkLayers;

    public bool isLeft;
    public bool isRight;
    public bool isUp;
    public bool isDown;

    // Start is called before the first frame update
    void Start()
    {
        floor = GetComponent<SpriteRenderer>();
        Invoke("CheckTile", 0.5f);
    }

    void CheckTile()
    {
        // Checks in each direction if there is a tile adjacent to it
        isUp = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, 1), 0.1f, checkLayers);
        isDown = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -1), 0.1f, checkLayers);
        isLeft = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(-1, 0), 0.1f, checkLayers);
        isRight = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(1, 0), 0.1f, checkLayers);

        // By default, grabs a standard tile
        floor.sprite = floorTiles[Random.Range(0, floorTiles.Length)];

        // Checks which tiles are adjacent and adjusts the tile's orientation in accordance
        //
        // Up & Down Straight
        if (isUp && isDown && !isLeft && !isRight)
        {
            floor.sprite = floorTwoSides[Random.Range(0, floorTwoSides.Length)];
        }
        // Left & Right Straight
        else if (!isUp && !isDown && isLeft && isRight)
        {
            floor.sprite = floorTwoSides[Random.Range(0, floorTwoSides.Length)];
            floor.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        // Left & Down Corner
        else if (!isUp && isDown && isLeft && !isRight)
        {
            floor.sprite = floorTwoSidesCorner[Random.Range(0, floorTwoSidesCorner.Length)];
            floor.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        // Left & Up Corner
        else if (isUp && !isDown && isLeft && !isRight)
        {
            floor.sprite = floorTwoSidesCorner[Random.Range(0, floorTwoSidesCorner.Length)];
            floor.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        // Right & Down Corner
        else if (!isUp && isDown && !isLeft && isRight)
        {
            floor.sprite = floorTwoSidesCorner[Random.Range(0, floorTwoSidesCorner.Length)];
        }
        // Right & Up Corner
        else if (isUp && !isDown && !isLeft && isRight)
        {
            floor.sprite = floorTwoSidesCorner[Random.Range(0, floorTwoSidesCorner.Length)];
            floor.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }

        // Up Wall
        else if (isUp && !isDown && !isLeft && !isRight)
        {
            floor.sprite = floorThreeSides[Random.Range(0, floorThreeSides.Length)];
            floor.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        // Down Wall
        else if (!isUp && isDown && !isLeft && !isRight)
        {
            floor.sprite = floorThreeSides[Random.Range(0, floorThreeSides.Length)];
            floor.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        // Left Wall
        else if (!isUp && !isDown && isLeft && !isRight)
        {
            floor.sprite = floorThreeSides[Random.Range(0, floorThreeSides.Length)];
            floor.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        // Right Wall
        else if (!isUp && !isDown && !isLeft && isRight)
        {
            floor.sprite = floorThreeSides[Random.Range(0, floorThreeSides.Length)];
        }
    }
}

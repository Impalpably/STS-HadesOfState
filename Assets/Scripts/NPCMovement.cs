using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMovement : MonoBehaviour
{
    private CharacterHandler characterHandler;
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private Vector2 randomMovement;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private int duration = 1;

    public LayerMask checkLayers;

    public bool isMoving = false;

    [SerializeField]
    private bool cantUp = true;
    [SerializeField]
    private bool cantDown = true;
    [SerializeField]
    private bool cantLeft = true;
    [SerializeField]
    private bool cantRight = true;

    // Start is called before the first frame update
    void Start()
    {
        characterHandler = CharacterHandler.instance;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void CheckMovement()
    {
        // Checks in each direction if there is a tile adjacent to it
        cantUp = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, 1), 0.1f, checkLayers);
        cantDown = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -1), 0.1f, checkLayers);
        cantLeft = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(-1, 0), 0.1f, checkLayers);
        cantRight = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(1, 0), 0.1f, checkLayers);
    }

    void GetDirection()
    {
        CheckMovement();

        bool finished = false;

        // By default, Do Nothing is #4
        int direction = 4;

        while (!finished)
        {
            direction = Random.Range(0, 4);

            switch (direction)
            {
                // Left
                case 0:
                    if (!cantLeft)
                    {
                        randomMovement = new Vector2(-1, 0);
                        finished = true;
                    }
                    break;

                // Right
                case 1:
                    if (!cantRight)
                    {
                        randomMovement = new Vector2(1, 0);
                        finished = true;
                    }
                    break;

                // Up
                case 2:
                    if (!cantUp)
                    {
                        randomMovement = new Vector2(0, 1);
                        finished = true;
                    }
                    break;

                // Down
                case 3:
                    if (!cantDown)
                    {
                        randomMovement = new Vector2(0, -1);
                        finished = true;
                    }
                    break;

                // Don't Move
                case 4:
                    randomMovement = new Vector2(0, 0);
                    finished = true;
                    break;

                default:
                    randomMovement = new Vector2(0, 0);
                    finished = true;
                    break;
            }
        }
    }

    void StopMovement()
    {
        // Stops all movement
        myRigidbody.velocity = new Vector2(0, 0);

        // Allows movement again after a random time period of 1-3 seconds
        Invoke("MoveAgain", Random.Range(0, 3));
    }

    void MoveAgain()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (characterHandler.enableMovement && !isMoving)
        {
            GetDirection();

            myRigidbody.velocity = randomMovement * speed;
            isMoving = true;
            Invoke("StopMovement", duration);
        }
    }

    public void UpdateSprite()
    {
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        mySprite.sprite = NPCInkDialogue.instance.NPCImage.GetComponent<Image>().sprite;
    }
}

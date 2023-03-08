using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterHandler characterHandler;

    private Rigidbody2D myRigidbody;

    private Vector2 movementInput;

    public bool canUseStairs = false;

    [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        characterHandler = CharacterHandler.instance;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Stairs")
        {
            if (canUseStairs)
            {
                Debug.Log("Use stairs?");
            }
            else
            {
                Debug.Log("You can't use the stairs yet! You need to unlock them first.");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "NPC")
        {
            // Stop movement for both entities
            characterHandler.enableMovement = false;
            myRigidbody.velocity = new Vector2(0, 0);
            other.rigidbody.velocity = new Vector2(0, 0);
            Debug.Log("Talk to NPC");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "NPC")
        {
            // Reenable movement for both entities
            characterHandler.enableMovement = true;
            myRigidbody.velocity = new Vector2(0, 0);
            Debug.Log("Finished talking to NPC");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (characterHandler.enableMovement)
        { 
            myRigidbody.velocity = movementInput * speed;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        if (characterHandler.enableMovement)
        {
            movementInput = inputValue.Get<Vector2>();
        }
    }
}

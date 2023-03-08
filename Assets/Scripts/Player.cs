using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterHandler characterHandler;

    private Rigidbody2D myRigidbody;

    private Vector2 movementInput;

    [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        characterHandler = CharacterHandler.instance;
        myRigidbody = GetComponent<Rigidbody2D>();
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

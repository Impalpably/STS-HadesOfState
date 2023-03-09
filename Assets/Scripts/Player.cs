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

    public GameObject stairsPrompt;
    public GameObject noStairsPrompt;

    [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        characterHandler = CharacterHandler.instance;
        myRigidbody = GetComponent<Rigidbody2D>();
        GetStairsPrompt();
    }

    public void UseStairs()
    {
        stairsPrompt.SetActive(true);
    }

    IEnumerator CantUseStairs()
    {
        noStairsPrompt.SetActive(true);
        yield return new WaitForSeconds(1f);
        noStairsPrompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Stairs")
        {
            if (canUseStairs)
            {
                characterHandler.enableMovement = false;
                myRigidbody.velocity = new Vector2(0, 0);
                UseStairs();
                Debug.Log("Use stairs?");
            }
            else
            {
                StartCoroutine(CantUseStairs());
                Debug.Log("You can't use the stairs yet! You need to unlock them first.");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "NPC")
        {
            NPCInkDialogue story = NPCInkDialogue.instance;

            if (story.firstStoryTime == true)
            {
                // Stop movement for both entities
                characterHandler.enableMovement = false;
                myRigidbody.velocity = new Vector2(0, 0);
                other.rigidbody.velocity = new Vector2(0, 0);
                Debug.Log("Talk to NPC");
                story.TellStory();
                canUseStairs = true;
            }
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

    void GetStairsPrompt()
    {
        stairsPrompt = GameObject.FindWithTag("StairsPrompt");
        noStairsPrompt = GameObject.FindWithTag("NoStairsPrompt");
        stairsPrompt.SetActive(false);
        noStairsPrompt.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stairsPrompt == null || noStairsPrompt == null)
        {
            GetStairsPrompt();
        }

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

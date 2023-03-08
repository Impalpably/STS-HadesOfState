using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public static CharacterHandler instance;
    public bool enableMovement;
    public GameObject stairs;

    private void Awake()
    {
        if (instance != null)
        {
            // More than one Handler in a scene
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enableMovement = false;
    }
}

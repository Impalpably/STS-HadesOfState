using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInkDialogue : MonoBehaviour
{

    public GameObject InkCanvas;
    public GameObject InkStoryLevel;
    public GameObject NPCImage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InkCanvas.SetActive(true);
        InkStoryLevel.SetActive(true);
        NPCImage.SetActive(true);
    }

}

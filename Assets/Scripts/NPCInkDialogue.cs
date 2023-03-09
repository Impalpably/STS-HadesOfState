using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInkDialogue : MonoBehaviour
{
    public static NPCInkDialogue instance;
    //public GameObject InkCanvas;
    public GameObject InkStoryLevel;
    public GameObject NPCImage;
    public GameObject UIPanel;

    public GameObject[] stories;

    public bool firstStoryTime = true;

    private void Awake()
    {
        if (instance != null)
        {
            // More than one Handler in a scene
            return;
        }
        instance = this;
    }

    public void GetStory(int levelIndex)
    {
        InkStoryLevel = stories[levelIndex];
        NPCImage = InkStoryLevel.transform.Find("Image").gameObject;
    }

    public void TellStory()
    {
        if (firstStoryTime)
        {
            //InkCanvas.SetActive(true);
            InkStoryLevel.SetActive(true);
            NPCImage.SetActive(true);
            UIPanel.SetActive(true);
            firstStoryTime = false;
        }
        
    }
}

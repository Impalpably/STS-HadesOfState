using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    public NPCInkDialogue story;
    public AudioSource BGM;
    public AudioClip[] backgroundMusic;
    public static CharacterHandler instance;
    public bool enableMovement;
    public GameObject stairs;
    private FadeToBlack fadeToBlack;

    public static int levelIndex = 5;
    public string currentLevel = "END";
    //public bool loadNextLevel;

    private Color limboColor = Color.gray;
    private Color lustColor = new Color(0f, 0.275f, 0.8f, 1f);
    private Color gluttonyColor = new Color(0.686f, 0.25f, 0f, 1f);
    private Color greedColor = new Color(0.757f, 0.631f, 0f, 1f);
    private Color wrathColor = new Color(0.529f, 0f, 0f, 1f);
    private Color heresyColor = new Color(0.529f, 0.807f, 0.921f, 1f);
    private Color violenceColor = new Color(0.314f, 0.784f, 0.47f, 1f);
    private Color fraudColor = new Color(0f, 0.22f, 0f, 1f);
    private Color treacheryColor = new Color(0.588f, 0f, 0.518f, 1f);
    private Color endingColor = Color.white;

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
        fadeToBlack = FadeToBlack.instance;
        story = NPCInkDialogue.instance;
        
        // Only execute if the Black Screen exists
        if (fadeToBlack != null)
        {
            switch (levelIndex)
            {
                case 0:
                    fadeToBlack.currentLevel = "LIMBO";
                    fadeToBlack.nextLevel = "LUST";
                    fadeToBlack.currentColor = limboColor;
                    fadeToBlack.nextColor = lustColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 1:
                    fadeToBlack.currentLevel = "LUST";
                    fadeToBlack.nextLevel = "GLUTTONY";
                    fadeToBlack.currentColor = lustColor;
                    fadeToBlack.nextColor = gluttonyColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 2:
                    fadeToBlack.currentLevel = "GLUTTONY";
                    fadeToBlack.nextLevel = "GREED";
                    fadeToBlack.currentColor = gluttonyColor;
                    fadeToBlack.nextColor = greedColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 3:
                    fadeToBlack.currentLevel = "GREED";
                    fadeToBlack.nextLevel = "WRATH";
                    fadeToBlack.currentColor = greedColor;
                    fadeToBlack.nextColor = wrathColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 4:
                    fadeToBlack.currentLevel = "WRATH";
                    fadeToBlack.nextLevel = "HERESY";
                    fadeToBlack.currentColor = wrathColor;
                    fadeToBlack.nextColor = heresyColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 5:
                    fadeToBlack.currentLevel = "HERESY";
                    fadeToBlack.nextLevel = "VIOLENCE";
                    fadeToBlack.currentColor = heresyColor;
                    fadeToBlack.nextColor = violenceColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 6:
                    fadeToBlack.currentLevel = "VIOLENCE";
                    fadeToBlack.nextLevel = "FRAUD";
                    fadeToBlack.currentColor = violenceColor;
                    fadeToBlack.nextColor = fraudColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 7:
                    fadeToBlack.currentLevel = "FRAUD";
                    fadeToBlack.nextLevel = "TREACHERY";
                    fadeToBlack.currentColor = fraudColor;
                    fadeToBlack.nextColor = treacheryColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[0];
                    break;

                case 8:
                    fadeToBlack.currentLevel = "TREACHERY";
                    fadeToBlack.nextLevel = "END";
                    fadeToBlack.currentColor = treacheryColor;
                    fadeToBlack.nextColor = endingColor;
                    story.GetStory(levelIndex);
                    BGM.clip = backgroundMusic[1];
                    break;

                default:
                    fadeToBlack.currentLevel = "END";
                    fadeToBlack.nextLevel = "";
                    fadeToBlack.currentColor = endingColor;
                    fadeToBlack.nextColor = endingColor;
                    story.GetStory(0);
                    BGM.clip = backgroundMusic[0];
                    break;
            }

            fadeToBlack.level.color = fadeToBlack.currentColor;

            currentLevel = fadeToBlack.currentLevel;
        }
    }

    public void LoadNextLevel()
    {
        fadeToBlack.AWinnerIsYou();
    }

    public void UpdateLevelIndex()
    {
        levelIndex++;
        return;
    }

    public int GetLevelIndex()
    {
        return levelIndex;
    }

    public void EnableMovement()
    {
        enableMovement = true;
    }
}

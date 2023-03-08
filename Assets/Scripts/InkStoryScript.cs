using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;


public class InkStoryScript : MonoBehaviour
{

    List<Story> Stories;

    public GameObject OptionsPanel;
    public GameObject UIPanel;

    public Text SceneDescription;
    public Text StatisticsText;
    public Text CorruptionText;
    public Text LustText;
    public Text GluttonyText;
    public Text GreedText;
    public Text WrathText;
    public Text HeresayText;
    public Text ViolenceText;
    public Text FraudText;
    public Text TreacheryText;

    static int corruption = 0;
    static int lust = 0;
    static int gluttony = 0;
    static int greed = 0;
    static int wrath = 0;
    static int heresy = 0;
    static int violence = 0;
    static int fraud = 0;
    static int treachery = 0;

    public int Corruption { get { return corruption; } }
    public int Lust { get { return lust; } }
    public int Gluttony { get { return gluttony; } }
    public int Greed { get { return greed; } }
    public int Wrath { get { return wrath; } }
    public int Heresy { get { return heresy; } }
    public int Violence { get { return violence; } }
    public int Fraud { get { return fraud; } }
    public int Treachery { get { return treachery; } }

    public int StoryCount { get { return Stories.Count; } }

    public Button ButtonPrefab;

    public bool End = false;

    [SerializeField]
    private TextAsset[] inkJSONAsset;



    // Start is called before the first frame update
    void Start()
    {
        Stories = new List<Story>();
        UpdateStatistics();
        GetFiles();
        PickRandomStory();
    }

    // Update Ink statistics
    void UpdateStatistics()
    {
        StatisticsText.text = "corruption: " + corruption + " | lust: " + lust + " | gluttony:" + gluttony +
        " | greed: " + greed + " | wrath: " + wrath + " | heresy: " + heresy + " | violence: " + violence + " | fraud: " + fraud + " | treachery: " + treachery;

        LustText.text = "Lust: " + lust;
        CorruptionText.text = "Corruption: " + corruption;
        GluttonyText.text = "Gluttony: " + gluttony;
        GreedText.text = "Greed: " + greed;
        WrathText.text = "Wrath: " + wrath;
        HeresayText.text = "Heresy: " + heresy;
        ViolenceText.text = "Violence: " + violence;
        FraudText.text = "Fraud: " + fraud;
        TreacheryText.text = "Treachery: " + treachery;
    }


    // Update Content
    void UpdateContent(Story InkStory)
    {
        InkStory.variablesState["Lust"] = Lust;
        InkStory.variablesState["Corruption"] = Corruption;
        InkStory.variablesState["Gluttony"] = Gluttony;
        InkStory.variablesState["Greed"] = Greed;
        InkStory.variablesState["Wrath"] = Wrath;
        InkStory.variablesState["Heresy"] = Heresy;
        InkStory.variablesState["Violence"] = Violence;
        InkStory.variablesState["Fraud"] = Fraud;
        InkStory.variablesState["Treachery"] = Treachery;

        DestroyChildren(OptionsPanel.transform);

        InkStory.ObserveVariables(new List<string>() { "End", "Lust", "Corruption", "Gluttony", "Greed", "Wrath", "Heresy", "Violence", "Fraud", "Treachery" },
        (variable, value) =>
        {
            switch (variable)
            {
                case "Lust":
                    lust = (int)value;
                    break;

                case "Corruption":
                    corruption = (int)value;
                    break;

                case "Gluttony":
                    gluttony = (int)value;
                    break;

                case "Greed":
                    greed = (int)value;
                    break;

                case "Wrath":
                    wrath = (int)value;
                    break;

                case "Heresy":
                    heresy = (int)value;
                    break;

                case "Violence":
                    violence = (int)value;
                    break;

                case "Fraud":
                    fraud = (int)value;
                    break;

                case "Treachery":
                    treachery = (int)value;
                    break;

                case "End":
                    End = (bool)value;
                    break;
            }

            UpdateStatistics();

        });

        SceneDescription.text = System.Text.RegularExpressions.Regex.Unescape(InkStory.ContinueMaximally());

        foreach (Choice choice in InkStory.currentChoices)
        {
            Button choiceButton = Instantiate(ButtonPrefab, OptionsPanel.transform);
            choiceButton.onClick.AddListener(delegate
            {
                InkStory.ChooseChoiceIndex(choice.index);

                if (End == true)
                {

                    //InkStory.Continue();
                    DestroyChildren(OptionsPanel.transform);
                    SceneDescription.text = "";
                    UIPanel.SetActive(false);

                    End = false;
                    PickRandomStory();

                }
                else
                {
                    UpdateContent(InkStory);
                }
            });

            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
        }
    }

    void DestroyChildren(Transform t)
    {
        foreach (Transform child in t)
        {
            Destroy(child.gameObject);
        }
    }

    void GetFiles()
    {
        //string inkPath = Application.streamingAssetsPath + "/Ink/";
        foreach (TextAsset file in inkJSONAsset)
        //  foreach (TextAsset file in Directory.GetFiles(inkPath, "*.json"))
        {
            //  string contents = File.ReadAllText(file);
            Stories.Add(new Story(file.text));
        }
    }

    void PickRandomStory()
    {
        if (Stories.Count > 0)
        {
            System.Random rand = new System.Random();
            int index = rand.Next(Stories.Count);
            Story entry = Stories[index];

            Stories.RemoveAt(index);
            UpdateContent(entry);
        }
        else
        {

        }

    }
}

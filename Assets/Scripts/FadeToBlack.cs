using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack instance;

    public string currentLevel;
    public string nextLevel;
    public Color currentColor;
    public Color nextColor;
    public TMP_Text level;
    public Image image;

    public bool fading = false;
    public bool fadeToBlack = false;

    public float maxAlpha = 1f;
    public float minAlpha = 0f;
    public bool atMaxAlpha = false;
    public bool atMinAlpha = false;

    public float duration;
    public float lerp = 1f;

    public CharacterHandler characterHandler;

    public void AWinnerIsYou()
    {
        fading = true;
        fadeToBlack = true;
        level.text = nextLevel;
        level.color = nextColor;

        characterHandler.UpdateLevelIndex();

        StartCoroutine(LoadNextLevel());
        return;
    }

    IEnumerator LoadNextLevel()
    {
        AsyncOperation async;

        if ((nextLevel == "END") || nextLevel == "")
        {
            yield return new WaitForSeconds(duration);
            async = SceneManager.LoadSceneAsync("MainMenu");

            while (!async.isDone)
            {
                yield return null;
            }
        }
        else
        {
            yield return new WaitForSeconds(duration * 2);
            async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

            while (!async.isDone)
            {
                yield return null;
            }
        }
    }

    void SetAlpha(float alpha)
    {
        var tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;
        return;
    }

    private void Awake()
    {
        if (instance != null)
        {
            // More than one instance in a scene
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        maxAlpha = image.color.a;
        atMaxAlpha = true;
        atMinAlpha = false;
        characterHandler = CharacterHandler.instance;
        level.text = currentLevel;
        level.color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            if (fadeToBlack && !atMaxAlpha)
            {
                atMinAlpha = false;
                //Debug.Log("Fading To Black");
                lerp += Time.deltaTime / duration;
                float myAlpha = Mathf.Lerp(minAlpha, maxAlpha, lerp);
                SetAlpha(myAlpha);
                level.alpha = myAlpha;

                if (myAlpha >= maxAlpha)
                {
                    atMaxAlpha = true;
                    fading = false;
                    characterHandler.enableMovement = false;
                    Debug.Log("Movement Disabled.");
                    lerp = 0;
                }
            }

            else if (!fadeToBlack && !atMinAlpha)
            {
                atMaxAlpha = false;
                //Debug.Log("Fading Away");
                lerp += Time.deltaTime / duration;
                float myAlpha = Mathf.Lerp(maxAlpha, minAlpha, lerp);
                SetAlpha(myAlpha);
                level.alpha = myAlpha;

                if (myAlpha <= minAlpha)
                {
                    atMinAlpha = true;
                    fading = false;
                    characterHandler.enableMovement = true;
                    Debug.Log("Movement Enabled.");
                    lerp = 0;
                }
            }
        }
    }
}

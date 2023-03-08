using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FadeToBlack : MonoBehaviour
{
    public string nextLevel;
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
        level.text = "";
        StartCoroutine(LoadNextLevel());
        return;
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(duration * 2);
        AsyncOperation async = SceneManager.LoadSceneAsync(nextLevel);

        while (!async.isDone)
        {
            yield return null;
        }
    }

    void SetAlpha(float alpha)
    {
        var tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        maxAlpha = image.color.a;
        characterHandler = CharacterHandler.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            if (fadeToBlack && !atMaxAlpha)
            {
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
                }
            }

            else if (!fadeToBlack && !atMinAlpha)
            {
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
                }
            }
        }
    }
}

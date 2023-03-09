using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public string myLevel;
    private bool canLoad = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(myLevel);
    }

    public void LoadLevel()
    {
        if (canLoad)
        {
            StartCoroutine(Loading());
            canLoad = false;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game.");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMainMenu : MonoBehaviour
{
    public AudioSource myAudio;
    // Start is called before the first frame update
   public void playButton()
    {
        myAudio.Play();
    }
}

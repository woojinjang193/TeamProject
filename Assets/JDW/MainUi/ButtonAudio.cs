using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Button btn = GetComponent<Button>();
        if(btn != null)
        {
            btn.onClick.AddListener(PlayClickSound);
        }
    }

   
   void PlayClickSound()
    {
        if(clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}

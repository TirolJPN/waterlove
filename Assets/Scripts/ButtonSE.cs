using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSE : MonoBehaviour {
    public AudioClip buttonClip; // ボタン用
    AudioSource audioSourceButton;

    public void Button()
    {
        audioSourceButton = gameObject.GetComponent<AudioSource>();
        audioSourceButton.clip = buttonClip;
        audioSourceButton.PlayOneShot(buttonClip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {
    public AudioClip buttonClip; // ボタン用
    AudioSource audioSourceButton;

    public void Button(int i)
    {
        audioSourceButton = gameObject.GetComponent<AudioSource>();
        audioSourceButton.clip = buttonClip;
        audioSourceButton.PlayOneShot(buttonClip);

        if (i == 0)
        {
            StoryButton();
        }
        else if (i == 1)
        {
            GalleryButton();
        }
        else if (i == 2)
        {
            DebugButton();
        }
    }

    public void StoryButton() // 物語を始めるボタン
    {

        SceneManager.LoadScene("Opening");
    }

    public void GalleryButton() // ギャラリーを見るボタン
    {
        SceneManager.LoadScene("Gallery");
    }

    public void DebugButton() // 物語を始めるボタン
    {

        SceneManager.LoadScene("Debug");
    }
}

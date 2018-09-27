﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour {

    string[] names = { "友鷹", "友鷹", "", ""
                       };
    string[] talks = { "はあはあ。もうだめだ。からだが、うごかない。\n"
                     , "西園寺さん、ごめん。がんばってくれ。\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n"
                     , "BAD END\n果てない暗闇の中で\n"
    };
    string NextScene = "Title";
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;

    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        Gallery gallery = GameObject.Find("GalleryController").GetComponent<Gallery>();
        gallery.BadFlagSet(0);
        if (Gallery.galleryFlag == true)
        {
            NextScene = "Gallery";
        }
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;

        touchWindow = GetComponent<TouchWindow>();
        touchWindow.SetText(names, talks, NextScene, false); // タッチ時のテキスト情報を専用ファイルに渡す
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Debug : MonoBehaviour {

    public UnityEngine.UI.Text[] HappyButtonText; // ボタンテキスト
    public UnityEngine.UI.Text[] BitterButtonText; // ボタンテキスト
    public UnityEngine.UI.Text[] BadButtonText; // ボタンテキスト

    public AudioClip audioClip; // BGM用
    AudioSource audioSource;

    public AudioClip buttonClip; // ボタン用
    AudioSource audioSourceButton;

    public static bool[] isHappyEndCleard = { false };
    public static bool[] isBitterEndCleard = { false, false, false };
    public static bool[] isBadEndCleard = { false };

    string[] HappyName = { "希望の「小紋島」" };
    string[] BitterName = { "足りなかった思いやり", "優しさ故の過ち", "詰め切れない距離" };
    string[] BadName = { "果てない暗闇の中で" };

    public static bool galleryFlag = false; // ギャラリーから読み込んでいるかどうか

    void Start()
    {
        galleryFlag = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

    }

    void Update()
    {

    }

    public void HappyButton(int i)
    {
        galleryFlag = true;
        if (isHappyEndCleard[i] == true)
        {
            Button("HappyEnd");
        }
    }

    public void BitterButton(int i)
    {
        galleryFlag = true;
        if (isBitterEndCleard[i] == true)
        {
            Button("BitterEnd" + (i + 1));
        }
    }

    public void BadButton(int i)
    {
        galleryFlag = true;
        if (isBadEndCleard[i] == true)
        {
            Button("BadEnd");
        }
    }

    public void ReturnButton()
    {
        Button("Title");
    }

    public void ChooseButton()
    {
        Button("ChooseForests");
    }

    public void Button(string scene) // ボタン押したとき
    {
        audioSourceButton = gameObject.GetComponent<AudioSource>();
        audioSourceButton.clip = buttonClip;
        audioSourceButton.Play();
        SceneManager.LoadScene(scene);
    }

    public void FlagSet(int end, int i) // クリア時にそのエンディングフラグを真にする
    {
        bool[][] Flags = { isHappyEndCleard, isBitterEndCleard, isBadEndCleard };
        Flags[end][i] = true;

        string[][] endNames = { HappyName, BitterName, BadName };
        UnityEngine.UI.Text[][] texts = { HappyButtonText, BitterButtonText, BadButtonText };
        texts[end][i].text = endNames[end][i];
    }

    public void HappyFlagSet(int i)
    {
        FlagSet(0, i);
    }

    public void BitterFlagSet(int i)
    {
        FlagSet(1, i);
    }

    public void BadFlagSet(int i)
    {
        FlagSet(2, i);
    }

    public void FlagReset() // 全てのフラグをfalseにする
    {
        bool[][] Flags = { isHappyEndCleard, isBitterEndCleard, isBadEndCleard };
        for (int i = 0; i < Flags.Length; i++)
        {
            for (int j = 0; j < Flags[i].Length; j++)
            {
                Flags[i][j] = false;
            }
        }
    }
}
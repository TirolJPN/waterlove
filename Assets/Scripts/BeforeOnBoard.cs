﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeOnBoard : MonoBehaviour {
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "友鷹", "友鷹" };
    string[] talks = { "俺の名前は島袋友鷹(しまぶくろともたか)。大学2年生。\n"
                     , "今日から沖縄に船で旅行に行くつもりだ。\n"
                     , "お、来た来た。あれが今回俺の乗る「シーエス号」だな。\n"};
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    // Use this for initialization
    void Start()
    {
        //TextLabel.text = "こんにちは。Unityちゃん監督です。ここでは高得点をとるヒントを紹介するよ。\n";
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return) && enterCount < talks.Length)
        {
            NameLabel.text = names[enterCount];
            TextLabel.text = talks[enterCount];
            enterCount++;
        }
        else if (Input.GetKeyUp(KeyCode.Backspace) && enterCount < talks.Length)
        {
            enterCount--;
            enterCount--;
            NameLabel.text = names[enterCount];
            TextLabel.text = talks[enterCount];
            enterCount++;
        }
        else if (Input.GetKeyUp(KeyCode.Return) && enterCount == talks.Length)
        {
            SceneManager.LoadScene("OnBoard");
        }
        /*else if (Input.GetKeyUp(KeyCode.Return) && enterCount == 0)
        {  // エンターキーが押されている間
            NameLabel.text = "友鷹\n";
            TextLabel.text = "";
            enterCount++;
        }*/
    }
}
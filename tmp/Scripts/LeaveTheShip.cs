using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveTheShip : MonoBehaviour
{
    string[] names = { "船長", "友鷹"//, "友鷹", "友鷹", "友鷹"
                      };
    string[] talks = { "「お降りになる方はこちらの出口からお願いします！チケットはお見せにならなくても大丈夫です！」\n"
                     , "「ありがとうございました。」\n"
                     //, "外は真上から照り付ける太陽がきついな。\n"
                     //, "船を降りた場所のすぐ近くに案内所があるってパンフレットには書いてあるけど、見つからないな。\nどこだろう。\n"
                     //, "とりあえず歩いてみよう。\n"
    };
    string NextScene = "OnTheIsland";
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        touchWindow = GetComponent<TouchWindow>();
        touchWindow.SetText(names, talks, NextScene, false); // タッチ時のテキスト情報を専用ファイルに渡す
    }

    void LateUpdate()
    {
        touchWindow.Touching();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnBoard : MonoBehaviour
{

    public GameObject[] Back; // 背景用
    string[] names = { "船長", "友鷹", "船長", "友鷹", "友鷹", "友鷹", "", "船長", "友鷹" };
    string[] talks = { "「チケット持っている方はこちらでお渡しください！」\n"
                     , "「これお願いします。」\n"
                     , "「はい！あ、おっとっと、すみません落としてしまいました。\n大人一人ですね！どうぞ中の方にお入りください。」\n"
                     , "「ありがとうございます。」\n"
                     , "大阪から沖縄まで長時間移動の船なので、船内は割と広い。\n"
                     , "レストランや売店など様々な施設が揃っているな。\n到着まで甲板でゆっくりと過ごそう。\n"
                     , "…"
                     , "「長らくの乗船お待たせいたしました。まもなく『小紋島』に到着いたします。」\n"
                     , "む。いつの間にか寝てしまっていたな。準備して降りなければ。\n"
    };
    string NextScene = "LeaveTheShip";
    int[] backSelectNumber = { 0 };
    int[] backEnterCount = { 8 };
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;
    // Use this for initialization
    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
// <<<<<<< feature/kosuke_debug
//         enabled = false;
//         yield return new WaitForSeconds(2);
//         enabled = true;
//     }

//     void LateUpdate()
//     {
//         timeleft -= Time.deltaTime;
//         //タッチがあるかどうか？
//         for (int i = 0; i < Input.touchCount; i++)
//         {
//             // タッチ情報を取得する
//             Touch touch = Input.GetTouch(i);
//             // ゲーム中ではなく、タッチ直後であればtrueを返す。
//             if (touch.phase == TouchPhase.Began && timeleft <= 0.0)
//             {
//                 timeleft = 0.2f;
//                 if (enterCount == talks.Length)
//                 {
//                     SceneManager.LoadScene("LeaveTheShip");
//                 }
//                 else
//                 {
//                     NameLabel.text = names[enterCount];
//                     TextLabel.text = talks[enterCount];
//                     DarkChange();
//                     enterCount++;
//                 }
//             }
//         }
// =======

        touchWindow = GetComponent<TouchWindow>();
        touchWindow.SetText(names, talks, NextScene, true); // タッチ時のテキスト情報を専用ファイルに渡す
        touchWindow.SetBack(Back, backSelectNumber, backEnterCount); // 背景切り替え時情報を専用ファイルに渡す
    }

// <<<<<<< feature/kosuke_debug

//     public void DarkChange() // 暗転
// =======
    void LateUpdate()
// >>>>>>> develop
    {
        touchWindow.Touching();
    }

    //IEnumerator WaitShortTime()
    //{
    //    // 0.5秒待つ
    //    yield return new WaitForSeconds(10);
    //}
}

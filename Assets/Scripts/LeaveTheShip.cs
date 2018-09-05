using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveTheShip : MonoBehaviour
{

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "船長", "友鷹", "友鷹", "友鷹" };
    string[] talks = { "「お降りになる方はこちらの出口からお願いします！チケットはお見せにならなくても大丈夫です！」\n"
                     , "「ありがとうございました。」\n"
                     , "船を降りた場所のすぐ近くに案内所があるってパンフレットには書いてあるけど、見つからないな。\nどこだろう。\n"
                     , "とりあえず歩いてみよう。\n"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return) && enterCount < talks.Length)
        {
            NameLabel.text = names[enterCount];
            TextLabel.text = talks[enterCount];
            enterCount++;
        }

        else if (Input.GetKeyUp(KeyCode.Return) && enterCount == talks.Length)
        {
            SceneManager.LoadScene("OnTheIsland");
        }
    }
}

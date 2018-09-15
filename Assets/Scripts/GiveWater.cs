using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GiveWater : MonoBehaviour
{

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", " " };
    string[] talks = { "とりあえず半分こしよう。\n"
                     , "水を二人で分け合った！\n"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    // 持っている水の合計
    private int amountScore;

    // PlayerPrefsで保存するためのキー
    private string amountScoreKey = "amountScore";

    // 友鷹のHP
    private int HP;

    private string HPKey = "HP";

    // 西園寺に上げた水の合計
    private int saionjiAmountScore;

    // PlayerPrefsで保存するためのキー
    // 手持ちの水合計
    private string saionjiAmountScoreKey = "saionjiAmountScore";

    private int division = 0;

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
            // とりあえず水を2分割する。
            // 本来ならばここで入力によって水分割を調整
            amountScore = PlayerPrefs.GetInt(amountScoreKey);
            HP = PlayerPrefs.GetInt(HPKey);
            saionjiAmountScore = PlayerPrefs.GetInt(saionjiAmountScoreKey);
            division = amountScore / 2;
            HP += division;
            saionjiAmountScore += division;

            PlayerPrefs.SetInt(HPKey, HP);
            PlayerPrefs.SetInt(saionjiAmountScoreKey, saionjiAmountScore);
            // Get100mlwaterの直前を呼び出す
            SceneManager.LoadScene("OnTheIsland");
        }
        /*else if (Input.GetKeyUp(KeyCode.Return) && enterCount == 0)
        {  // エンターキーが押されている間
            NameLabel.text = "友鷹\n";
            TextLabel.text = "";
            enterCount++;
        }*/
    }
}

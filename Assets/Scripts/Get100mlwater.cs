using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Get100mlwater : MonoBehaviour
{

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", " ", "友鷹", "友鷹" };
    string[] talks = {
                     "ん？何か光ってるものがあるぞ。これは…水？\n"
                     , "水100mlを入手した。\n"
                     , "なるほど。こういうのを集めればいいのか。\n"
                     , "さて、どこに向かおうかな。\n"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    // 持っている水の合計
    private int amountScore;

    // PlayerPrefsで保存するためのキー
    private string amountScoreKey = "amountScore";

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
            // もし合計がすでに保存されていたら100増やして上書き保存
            if(PlayerPrefs.HasKey(amountScoreKey)){
                amountScore = PlayerPrefs.GetInt(amountScoreKey, -1);
                amountScore += 100;
                PlayerPrefs.SetInt(amountScoreKey, amountScore);
                PlayerPrefs.Save();
            }
            // そうでなければ100を初期値で保存する
            else{
                amountScore = 100;
                PlayerPrefs.SetInt(amountScoreKey, amountScore);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("ChooseForests");
        }
        /*else if (Input.GetKeyUp(KeyCode.Return) && enterCount == 0)
        {  // エンターキーが押されている間
            NameLabel.text = "友鷹\n";
            TextLabel.text = "";
            enterCount++;
        }*/
    }
}

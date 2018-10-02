using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BitterEnd2 : MonoBehaviour {
    public GameObject[] Back; // 背景用
    string[] names = { "友鷹", "友鷹", "梨子", "梨子", "梨子", "友鷹", "梨子", "梨子", "友鷹"
                     , "梨子", "友鷹", "友鷹", "友鷹", "友鷹", "梨子", "梨子", "友鷹", "", "", "",
                       };
    string[] talks = { "「西園寺さん！水持ってきたよ。」\n"
                     , "「これ飲んで。」\n"
                     , "「ありがとうございます！」\n"
                     , "「私も火をおこすのに役に立ちそうな木を集めてきました！」\n"
                     , "「あと、高くてとれなかったのですが、向こうの方に果物みたいなものもありました！」\n"
                     , "「おお、すごい…ありがとう。」\n"
                     , "「こんな状況でも前向きに一生懸命考えて行動ができて、本当にすごいです。\n"
                     , "「私一人だったら何もできませんでした。ありがとうございます。」\n"
                     , "「いや、こちらこそ…。少し休ませてもらうね。」\n"
                     , "「はい。お疲れ様です。」\n"
                     , "体はもう疲れ果てて動かない。\n"
                     , "言葉もうまくかけられない。\n"
                     , "でも梨子さんが喜んでくれてよかった。\n"
                     , "早く迎えが来てくれることを祈ろう…。\n"
                     , "「あの…友鷹さん。」\n"
                     , "「もしよかったら私と…ってあれ。眠っちゃってる。」\n"
                     , "「すーすー。」\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n"
                     , "俺の中で忘れられない苦い思い出が、そこにはあった。\n"
                     , "BITTER END2\n優しさ故の過ち\n"
    };
    string NextScene = "Title";
    int[] backSelectNumber = { 3, 0, 2 };
    int[] backEnterCount = { 2, 9, 15 };
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;

    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        Gallery.BitterFlagSet(1);
        SaveFlag.SetBool(Gallery.endNames[1][1], true);
        //PlayerPrefs.Save();
        if (Gallery.galleryFlag == true)
        {
            NextScene = "Gallery";
        }
      
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;

        touchWindow = GetComponent<TouchWindow>();
        touchWindow.SetText(names, talks, NextScene, true); // タッチ時のテキスト情報を専用ファイルに渡す
        touchWindow.SetBack(Back, backSelectNumber, backEnterCount); // 背景切り替え時情報を専用ファイルに渡す
    }
}

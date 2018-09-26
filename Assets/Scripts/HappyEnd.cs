using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HappyEnd : MonoBehaviour
{
    string[] names = { "友鷹", "梨子", "梨子", "友鷹", "梨子", "梨子"
                     , "友鷹", "友鷹", "梨子", "", ""
                       };
    string[] talks = { "「西園寺さん！水持ってきたよ。これ飲んで。」\n"
                     , "「ありがとうございます！私も火をおこすのに役に立ちそうな木を集めてきました！」\n"
                     , "「あと、高くてとれなかったのですが、向こうの方に果物みたいなものもありました！」\n"
                     , "「おお！すごい！たくさん頑張ってくれたんだね、ありがとう。」\n"
                     , "「いえ、むしろ友鷹さんの方が…。」\n"
                     , "「こんな状況でも前向きに一生懸命考えて行動ができて、本当にすごいです。\n私一人だったら何もできませんでした。」\n"
                     , "「いや、俺がここまで頑張れたのは君のためだよ。一人じゃ何もできなかったのは俺も一緒だよ。」\n"
                     , "「…梨子さん、『小紋島』に着いたら、俺と一緒に行動してもらえませんか？」\n"
                     , "「…はい。」\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n俺の中で忘れられない大切な思い出が、そこにはあった。\n"
                     , "HAPPY END\n希望の「小紋島」\n"
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
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;

        touchWindow = GetComponent<TouchWindow>();
        touchWindow.SetText(names, talks, NextScene, false); // タッチ時のテキスト情報を専用ファイルに渡す
    }

    void LateUpdate()
    {
        touchWindow.Touching();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BitterEnd1 : MonoBehaviour {
    string[] names = { "友鷹", "梨子", "友鷹", "友鷹", "梨子", "友鷹", "梨子", "", ""
                       };
    string[] talks = { "「西園寺さん！水持ってきたよ。これ飲んで。」\n"
                     , "「ありがとうございます。すみません、島袋さんはがんばってくださっているのに、\n私の方は役に立ちそうなものが見つけられませんでした…。」\n"
                     , "「いや、俺がここまで頑張れたのは君のためだよ。一人じゃ何もできなかった。」\n"
                     , "「…梨子さん、『小紋島』に着いたら、俺と一緒に行動してもらえませんか？」\n"
                     , "「え？うーん、そうですね…。すみません…。今はこの状況を乗り切ることしか考えられなくて。」\n"
                     , "「そ、そうですよね。すみません、変なこと言っちゃって。」\n"
                     , "「いえいえ、ありがとうございます。船が来るまで頑張りましょう。」\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n俺の中で忘れられない苦い思い出が、そこにはあった。\n"
                     , "BITTER END1\n足りなかった思いやり\n"
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

        //Gallery gallery = GetComponent<Gallery>();
        Gallery.BitterFlagSet(0);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BitterEnd1 : MonoBehaviour
{
    public GameObject[] Back; // 背景用
    string[] names = { "友鷹", "友鷹", "梨子", "梨子", "友鷹", "友鷹", "友鷹", "梨子", "梨子", "友鷹", "友鷹", "梨子", "梨子", "友鷹", "", "", ""
                       };
    string[] talks = { "「西園寺さん！水持ってきたよ。」\n"
                     , "「これ飲んで。」\n"
                     , "「ありがとうございます。」\n"
                     , "「すみません、島袋さんはがんばってくださっているのに、\n私の方は役に立ちそうなものが見つけられませんでした…。」\n"
                     , "「いや、俺がここまで頑張れたのは君のためだよ。」\n"
                     , "「一人じゃ何もできなかった。」\n"
                     , "「…梨子さん、『小紋島』に着いたら、俺と一緒に行動してもらえませんか？」\n"
                     , "「え？うーん、そうですね…。」\n"
                     , "「すみません…。今はこの状況を乗り切ることしか考えられなくて。」\n"
                     , "「そ、そうですよね。」\n"
                     , "「すみません、変なこと言っちゃって。」\n"
                     , "「いえいえ、ありがとうございます。」\n"
                     , "「船が来るまで頑張って待ちましょう。」\n"
                     , "「そうですね。」\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n"
                     , "俺の中で忘れられない苦い思い出が、そこにはあった。\n"
                     , "BITTER END1\n足りなかった思いやり\n"
    };
    string NextScene = "Title";
    int[] backSelectNumber = { 2, 0, 2, 0, 2 };
    int[] backEnterCount = { 2, 3, 7, 8, 11 };
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;


    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        Gallery.BitterFlagSet(0);
        SaveFlag.SetBool(Gallery.endNames[1][0], true);
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

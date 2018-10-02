using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BitterEnd3 : MonoBehaviour {
    public GameObject[] Back; // 背景用
    string[] names = { "友鷹", "友鷹", "梨子", "梨子", "友鷹", "友鷹", "梨子"
                     , "友鷹", "友鷹", "友鷹", "", "", ""
                       };
    string[] talks = { "「西園寺さん。水持ってきたよ。」\n"
                     , "「これ飲んで。」\n"
                     , "「ありがとうございます。」\n"
                     , "「すみません、島袋さんはがんばってくださっているのに、\n私の方は役に立ちそうなものが見つけられませんでした…。」\n"
                     , "「いや、そんなことは…。」\n"
                     , "「少し休ませてもらうね。」\n"
                     , "「はい。お疲れ様です。」\n"
                     , "体はもう疲れ果てて動かない。\n"
                     , "言葉もうまくかけられない。\n"
                     , "早く迎えが来てくれることを祈ろう…。\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n"
                     , "俺の中で忘れられない苦い思い出が、そこにはあった。\n"
                     , "BITTER END3\n詰め切れない距離\n"
    };
    string NextScene = "Title";
    int[] backSelectNumber = { 2, 0, 2 };
    int[] backEnterCount = { 2, 3, 6 };
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;

    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        Gallery.BitterFlagSet(2);
        SaveFlag.SetBool(Gallery.endNames[1][2], true);
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

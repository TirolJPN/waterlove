using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BitterEnd3 : MonoBehaviour {
    string[] names = { "友鷹", "梨子", "友鷹", "友鷹", "", ""
                       };
    string[] talks = { "「西園寺さん、水持ってきたよ。これ飲んで。」\n"
                     , "「ありがとうございます。すみません、島袋さんはがんばってくださっているのに、\n私の方は役に立ちそうなものが見つけられませんでした…。」\n"
                     , "「うん…。」\n"
                     , "体はもうボロボロで動かない。言葉もうまくかけられない。\n早く迎えが来てくれることを祈ろう…。\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n俺の中で忘れられない苦い思い出が、そこにはあった。\n"
                     , "BITTER END3\n詰め切れない距離\n"
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

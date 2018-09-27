using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BitterEnd2 : MonoBehaviour {
    string[] names = { "友鷹", "梨子", "梨子", "友鷹", "梨子", "友鷹"
                     , "梨子", "友鷹", "", ""
                       };
    string[] talks = { "「西園寺さん！水持ってきたよ。これ飲んで。」\n"
                     , "「ありがとうございます！私も火をおこすのに役に立ちそうな木を集めてきました！」\n"
                     , "「あと、高くてとれなかったのですが、向こうの方に果物みたいなものもありました！」\n"
                     , "「うん…ありがとう。」\n"
                     , "「こんな状況でも前向きに一生懸命考えて行動ができて、本当にすごいです。\n私一人だったら何もできませんでした。」\n"
                     , "体はもうボロボロで動かない。言葉もうまくかけられない。\nでも梨子さんが喜んでくれてよかった。早く迎えが来てくれることを祈ろう…。\n"
                     , "「あの…友鷹さん。もしよかったら私と…ってあれ。眠っちゃってる。」\n"
                     , "「すーすー。」\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n俺の中で忘れられない苦い思い出が、そこにはあった。\n"
                     , "BITTER END2\n優しさ故の過ち\n"
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

        Gallery gallery = GetComponent<Gallery>();
        gallery.BitterFlagSet(1);
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

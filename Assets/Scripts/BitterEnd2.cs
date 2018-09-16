using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BitterEnd2 : MonoBehaviour {
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "梨子", "友鷹", "友鷹", "梨子", "友鷹", "", ""
                       };
    string[] talks = { "「西園寺さん！水持ってきたよ。これ飲んで。」\n"
                     , "「ありがとうございます。こんな状況でも前向きに一生懸命考えて行動ができて、本当にすごいです。私一人だったら何もできませんでした。」\n"
                     , "「うん…ありがとう。」\n"
                     , "体はもうボロボロで動かない。言葉もうまくかけられない。\nでも梨子さんが喜んでくれてでよかった。早く迎えが来てくれることを祈ろう…。\n"
                     , "「あの…友鷹さん。もしよかったら私と…ってあれ。眠っちゃってる。」\n"
                     , "「すーすー。」\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n俺の中で忘れられない苦い思い出が、そこにはあった。\n"
                     , "BITTER END2\n優しさ故の過ち\n"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (enterCount == talks.Length)
            {
                SceneManager.LoadScene("Title");
            }
            else
            {
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
                enterCount++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Backspace))
        {
            if (enterCount > 0)
            {
                enterCount--;
                if (enterCount == 0)
                {
                    //SceneManager.LoadScene("BeforeOnBoard");
                }
                else
                {
                    enterCount--;
                    NameLabel.text = names[enterCount];
                    TextLabel.text = talks[enterCount];
                    enterCount++;
                }
            }
        }
    }
}

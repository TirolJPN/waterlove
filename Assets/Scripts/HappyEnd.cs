using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HappyEnd : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "梨子", "友鷹","友鷹", "梨子", "友鷹", ""
                       };
    string[] talks = { "「西園寺さん！水持ってきたよ。これ飲んで。」\n"
                     , "「ありがとうございます。\nこんな状況でも前向きに一生懸命考えて行動ができて、本当にすごいです。\n私一人だったら何もできませんでした。」\n"
                     , "「いや、俺がここまで頑張れたのは君のためだよ。一人じゃ何もできなかったのは俺も一緒だよ。」\n"
                     , "「…梨子さん、『小紋島』に着いたら、俺と一緒に行動してもらえませんか？」\n"
                     , "「…はい。」\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n俺の中で忘れられない思い出が、そこにはあった。\n"
                     , "HAPPY END\n希望の「小紋島」\n"
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
                    SceneManager.LoadScene("BeforeOnBoard");
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

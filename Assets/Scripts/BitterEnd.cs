using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BitterEnd : MonoBehaviour {
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "梨子", "友鷹","友鷹", "梨子", "友鷹", ""
                       };
    string[] talks = { "「西園寺さん！…ごめん。水全然確保できなかった。」\n"
                     , "「そうだったんですね。いえいえ、島袋さんは頑張ってたので謝ることはありませんよ。ありがとうございます。」\n"
                     , "「うん…。」\n"
                     , "体はもうボロボロで動かないし、言葉もうまくかけられない。悲惨だな…。\n"
                     , "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n俺の中で忘れられない思い出が、そこにはあった。\n"
                     , "BITTER END3\n詰め切れない距離\n"
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

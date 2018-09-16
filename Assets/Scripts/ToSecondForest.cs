using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToSecondForest : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    public GameObject[] Back; // 背景用
    string[] names = { "友鷹", "友鷹",　"", "友鷹", "梨子", "友鷹"
                     , "", "友鷹"
                     //, ""
                     , "梨子", "友鷹"
                     , "梨子", "", "友鷹", "梨子", "友鷹", ""
                     , "友鷹", "", "友鷹"};
    string[] talks = { "ふう。とりあえずはこんなものかな。\n"
                     , "西園寺さんも待っているだろうし、早く持って行ってあげよう。\n"
                     , "…"
                     , "「西園寺さん、お待たせ。」\n"
                     , "「島袋さん！おかえりなさい！」\n"
                     , "「水持ってきたよ。まずは俺が試しに飲んでみるね。」\n"
                     , "飲む量を選んでください。\n"
                     , "「うん、飲んでみたけど体に支障はなさそうだ。西園寺さんにも今渡すね。」\n"
                     //, "渡す量を選んでください。\n"
                     , "「ありがとうございます。…んっ。おいしいです。」\n"
                     , "「よかった。少し休憩したらまた調達してくるよ。」\n"
                     , "「そうですね。今は休みましょう。」\n"
                     , "…"
                     , "「じゃあそろそろ行ってくるね。」\n"
                     , "「はい。お気をつけて。私も何か役に立ちそうなものを探してみます。」\n"
                     , "「西園寺さんも、無理はしないでね。」\n"
                     , "…"
                     , "お、また水がある。これも回収しとこう。\n"
                     , "水100mlを入手した。\n"
                     , "さて、どこに向かおうかな。\n"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    // Use this for initialization
    void Start()
    {
        //TextLabel.text = "こんにちは。Unityちゃん監督です。ここでは高得点をとるヒントを紹介するよ。\n";
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (enterCount == talks.Length)
            {
                SceneManager.LoadScene("ChooseForests");
            }
            else
            {
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
                DarkChange();
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
                    DarkChange();
                    enterCount++;
                }
            }
        }
    }

    public void DarkChange() // 暗転
    {
        if (talks[enterCount].Equals("…"))
        {
            Back[0].SetActive(false);
            Back[1].SetActive(true); // 暗転
        }
        else
        {
            Back[0].SetActive(true); // 暗転解除
            Back[1].SetActive(false);
        }
    }
}

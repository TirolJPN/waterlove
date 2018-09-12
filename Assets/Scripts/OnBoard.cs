using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnBoard : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "船長", "友鷹", "船長", "友鷹", "友鷹", "\n", "船長", "友鷹" };
    string[] talks = { "「チケット持っている方はこちらでお渡しください！」\n"
                     , "「これお願いします。」\n"
                     , "「はい！あ、おっとっと、すみません落としてしまいました。\n大人一人ですね！どうぞ中の方にお入りください。」\n"
                     , "「ありがとうございます。」\n"
                     , "大阪から沖縄まで長時間移動の船なので、船内は割と広い。\nレストランや売店など様々な施設が揃っているな。\n到着まで甲板でゆっくりと過ごそう。\n"
                     , "\n"
                     , "「長らくの乗船お待たせいたしました。まもなく『小紋島』に到着いたします。」\n"
                     , "む。いつの間にか寝てしまっていたな。準備して降りなければ。\n"
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
                SceneManager.LoadScene("LeaveTheShip");
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
            if (enterCount == 0)
            {
                SceneManager.LoadScene("BeforeOnBoard");
            }
            else
            {
                enterCount--;
                enterCount--;
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
                enterCount++;
            }
        }
    }
}

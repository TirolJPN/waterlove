using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OntheIsland : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    public GameObject[] Back; // 背景用
    string[] names = { "友鷹", "友鷹", "友鷹", "", "友鷹"
                     ,"友鷹", "", "友鷹", "友鷹", "友鷹", "女の子", "友鷹"
                     , "女の子", "友鷹", "友鷹", "女の子", "友鷹", "梨子"
                     , "友鷹", "友鷹", "友鷹", "梨子", "友鷹", ""
                     , "友鷹", "", "友鷹", "友鷹" };
    string[] talks = { "外は真上から照り付ける太陽がきついな。\n"
                     , "船を降りた場所のすぐ近くに案内所があるってパンフレットには書いてあるけど、見つからないな。\nどこだろう。\n"
                     , "とりあえず歩いてみよう。\n"
                     , "…"
                     , "うーむ。案内所どころか、人気もない。\n"
                     , "一旦船の方に戻ってみよう。\n"
                     , "…"
                     , "ああ。もう船は出てしまっている。\n"
                     , "でも同じ船から降りたと思われる女の子が一人いるからあの子に聞いてみよう。\n"
                     , "「すみません。案内所ってどこか分かりますか？」\n"
                     , "「あっ、えーっと、私も分からなくて…。どうしようって思ってました。」\n"
                     , "「そうですよねー。事前に見ていた島の景色と違うような気がしますし。」\n"
                     , "「もしかしたら間違えて降ろされてしまったのかもしれません。\n船長さんに乗るときにチケット渡したら慌てて落としてましたし、そういう人なのかも。」\n"
                     , "「今はそう考えてしまったほうが楽かもしれませんね。」\n"
                     , "「最終目的地まで船がたどり着く頃にはさすがに間違いに気づくでしょう。\nその後にでも助けに来てくれるでしょうから、それまでなんとか待機しましょう。」\n"
                     , "「そうですね。見た感じここで降りたのは私たちだけみたいですね。」\n"
                     , "「ですね。あ、そういえば自己紹介がまだでしたね。\n俺は島袋友鷹(しまぶくろともたか)って言います。大学2年生です。\nよろしくお願いします。」\n"
                     , "「私は西園寺梨子(さいおんじりこ)です。同じく大学2年生です。\nよろしくお願いします、島袋さん。」\n"
                     , "「同い年だったんだね、こちらこそよろしく、西園寺さん。」\n"
                     , "「助けが来るまでどれぐらいかかるか分からないから、まずは飲み水を確保することを考えよう。」\n"
                     , "「長旅で疲れてるだろうから、俺が調達してくるよ。西園寺さんは陰で休んでて。」\n"
                     , "「ありがとうございます。回復したら、私も手伝いますね。」\n"
                     , "「ありがとう。島の奥の方に行ってみるよ。」\n"
                     , "…"
                     , "ん？何か光ってるものがあるぞ。これは…水？\n"
                     , "水100mlを入手した。\n"
                     , "なるほど。こういうのを集めればいいのか。\n"
                     , "さて、どこに向かおうかな。\n"
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
                SceneManager.LoadScene("ChooseForests");
            }
            else
            {
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
                DarkChange();
                if (enterCount == 4 || enterCount == 5)
                {
                    BackChange(2);
                }
                enterCount++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Backspace))
        {
            if (enterCount == 0)
            {
                SceneManager.LoadScene("LeaveTheShip");
            }
            else
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
            foreach (GameObject g in Back)
            {
                g.SetActive(false);
            }
            Back[1].SetActive(true); // 暗転
        }
        else
        {
            // <<<<<<< feature/manage
            //             SceneManager.LoadScene("Get100mlwater");
            // =======
            foreach (GameObject g in Back)
            {
                g.SetActive(false);
            }
            Back[0].SetActive(true); // 暗転解除
            //Back[1].SetActive(false);
// >>>>>>> develop
        }
    }

    public void BackChange(int i)
    {
        foreach (GameObject g in Back)
        {
            g.SetActive(false);
        }
        Back[i].SetActive(true);
    }
}

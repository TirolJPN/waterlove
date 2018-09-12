using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OntheIsland : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "", "友鷹", "友鷹", "女の子", "友鷹"
                      ,"女の子", "友鷹", "友鷹", "女の子", "友鷹", "梨子"
                      , "友鷹", "友鷹", "友鷹", "梨子", "友鷹" };
    string[] talks = { "うーむ。案内所どころか、人気もない。\n一旦船の方に戻ってみよう。\n"
                     , "歩行音\n"
                     , "ああ。もう船は出てしまっている。\nでも同じ船から降りたと思われる女の子が一人いるからあの子に聞いてみよう。\n"
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
                     , "「ありがとう。さて、どこに向かおうかな。」\n"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    void LateUpdate()
    {
        // エンターキーなら先に進み, バックスペースなら前に戻る
        if (Input.GetKeyUp(KeyCode.Return) && enterCount < talks.Length)
        {
            if (enterCount == talks.Length)
            {
                SceneManager.LoadScene("ChooseForests");
            }
            else
            {
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
                enterCount++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Backspace) && enterCount < talks.Length)
        {
            if (enterCount == 0)
            {
                SceneManager.LoadScene("LeaveTheShip");
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

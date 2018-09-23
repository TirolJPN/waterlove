using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OntheIsland : MonoBehaviour
{

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
    };
    string NextScene = "BeforeOnBoard";
    int[] backSelectNumber = { 2, 0 };
    int[] backEnterCount = { 4, 7 };
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        touchWindow = GetComponent<TouchWindow>();
        touchWindow.SetText(names, talks, NextScene, true); // タッチ時のテキスト情報を専用ファイルに渡す
        touchWindow.SetBack(Back, backSelectNumber, backEnterCount); // 背景切り替え時情報を専用ファイルに渡す
    }

    void LateUpdate()
    {
        touchWindow.Touching();
    }
}

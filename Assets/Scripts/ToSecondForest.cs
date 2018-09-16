using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToSecondForest : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    public GameObject[] Back; // 背景用
    string[] names = { "友鷹", "友鷹", "", "友鷹", "梨子", "友鷹"
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

    private const int selectNum = 7;

    // 持っている水の合計
    private int amountScore;

    // PlayerPrefsで保存するためのキー
    private string amountScoreKey = "amountScore";

    // 友鷹のHP
    private int HP;

    private string HPKey = "HP";

    // 西園寺に上げた水の合計
    private int saionjiAmountScore;

    // PlayerPrefsで保存するためのキー
    // 手持ちの水合計
    private string saionjiAmountScoreKey = "saionjiAmountScore";

    private int division = 0;

    // 水受け渡し後に呼ぶSceneの入れ子
    public GameObject scene;
    public Slider slider;

    // 選択中の水の量
    public Text minValue;
    public Text maxValue;

    // Use this for initialization
    void Start()
    {
        //TextLabel.text = "こんにちは。Unityちゃん監督です。ここでは高得点をとるヒントを紹介するよ。\n";
        // 飲む量は最小値の10
        // 西園寺にあげれる量は、その差分
        // slider値は10分の1
        slider.minValue = 10 / 10;
        slider.maxValue = (PlayerPrefs.GetInt(amountScoreKey, -1) - 10) / 10;
        minValue.text = (slider.minValue * 10).ToString();
        maxValue.text = (slider.maxValue * 10).ToString();

        amountScore = PlayerPrefs.GetInt(amountScoreKey);
        HP = PlayerPrefs.GetInt(HPKey);
        saionjiAmountScore = PlayerPrefs.GetInt(saionjiAmountScoreKey);
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (enterCount == talks.Length)
            {

                // もし合計がすでに保存されていたら100増やして上書き保存
                if (PlayerPrefs.HasKey(amountScoreKey))
                {
                    amountScore = PlayerPrefs.GetInt(amountScoreKey, -1);
                    amountScore += 100;
                    PlayerPrefs.SetInt(amountScoreKey, amountScore);
                    PlayerPrefs.Save();
                }
                // そうでなければ100を初期値で保存する
                else
                {
                    amountScore = 100;
                    PlayerPrefs.SetInt(amountScoreKey, amountScore);
                    PlayerPrefs.Save();
                }
                SceneManager.LoadScene("ChooseForests");
            }
            else if(enterCount == selectNum){
                enterCount++;
                scene.SetActive(true);
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

    // モーダルのOKボタンを押すと値を更新してシーン遷移する関数
    public void goScene()
    {
        division = ((int)slider.value * 10);
        HP += division;
        saionjiAmountScore += (amountScore - division);
        amountScore = 0;

        PlayerPrefs.SetInt(HPKey, HP);
        PlayerPrefs.SetInt(amountScoreKey, amountScore);
        PlayerPrefs.SetInt(saionjiAmountScoreKey, saionjiAmountScore);
        // Get100mlwaterの直前を呼び出す
        scene.SetActive(false);
    }

    // sliderの値が更新されるたびに表示を変える関数
    public void changeValueDisplay()
    {
        // divisionを作業変数として用いる
        division = (int)slider.value * 10;
        minValue.text = division.ToString();
        maxValue.text = (amountScore - division).ToString();
    }
}

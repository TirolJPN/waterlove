using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadToTheEnding : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    public GameObject[] Back; // 背景用
    string[] names = { "友鷹", ""
        , ""
        ,  "友鷹"
        , "" , ""
                       };
    string[] talks = { "よし、西園寺さんのところに戻ろう。どれくらい飲もうかな。\n"
                     , "飲む量を選んでください。\n"
                     , ""
                     , "「残りは西園寺さんにあげるね。」"
                     , "…"
                     , "……"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    private const int selectNum = 2;

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
                //SceneManager.LoadScene("BitterEnd2");
            }
            else if (enterCount == selectNum)
            {
                enterCount++;
                scene.SetActive(true);
            }
            else
            {
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
                //DarkChange();
                if (talks[enterCount].Equals("…"))
                {
                    Back[0].SetActive(false);
                    Back[1].SetActive(true); // 暗転
                }
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
                    //DarkChange();
                    if (talks[enterCount].Equals("…"))
                    {
                        Back[0].SetActive(false);
                        Back[1].SetActive(true); // 暗転
                    }
                    enterCount++;
                }
            }
        }
        //else if (enterCount == talks.Length)
        //{
            //SceneManager.LoadScene("BitterEnd2")
            HP = PlayerPrefs.GetInt(HPKey, 0);
            saionjiAmountScore = PlayerPrefs.GetInt(saionjiAmountScoreKey, 0);
            if (HP > 50 && saionjiAmountScore > 100)
            {
                SceneManager.LoadScene("HappyEnd");
            }
            else if (HP > 50 && saionjiAmountScore < 100)
            {
                SceneManager.LoadScene("BitterEnd1");
            }
            else if (HP < 50 && saionjiAmountScore > 100)
            {
                SceneManager.LoadScene("BitterEnd2");
            }
            else if (HP < 50 && saionjiAmountScore < 100)
            {
                SceneManager.LoadScene("BitterEnd3");
            }
            else if (HP == 0)
            {
                SceneManager.LoadScene("BadEnd");
            }
        //}
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

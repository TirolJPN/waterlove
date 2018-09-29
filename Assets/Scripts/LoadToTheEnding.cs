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
        , "無視"
        ,  "友鷹"
        , "" , ""
                       };
    string[] talks = { "よし、西園寺さんのところに戻ろう。どれくらい飲もうかな。\n"
                     , "飲む量を選んでください。\n"
                     , "無視"
                     , "残りは西園寺さんにあげよう。"
                     , "…"
                     , "……"
    };
    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;

    private int enterCount = 0;

    private float timeleft;

    private const int selectNum = 2;

    // 持っている水の合計
    private int amountScore;

    // PlayerPrefsで保存するためのキー
    private string amountScoreKey = "amountScore";

    // 友鷹のハイスコア
    private int amountHighscore;

    private string amountHighscoreKey = "amountHighscore";

    //1回目のスコア
    private int firstscore;

    private string firstscoreKey = "firstscore";

    // 友鷹のHP
    private int HP;

    private string HPKey = "HP";

    // 西園寺に上げた水の合計
    private int saionjiAmountScore;

    // PlayerPrefsで保存するためのキー
    // 手持ちの水合計
    private string saionjiAmountScoreKey = "saionjiAmountScore";

    // 西園寺のハイスコア
    private int saionjiAmountHighscore;

    private string saionjiAmountHighscoreKey = "saionjiAmountHighscore";

    private int division = 0;

    // 水受け渡し後に呼ぶSceneの入れ子
    public GameObject scene;
    public Slider slider;

    // 選択中の水の量
    public Text minValue;
    public Text maxValue;



    private bool sliderFlag;

    // Use this for initialization
    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;

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
        timeleft -= Time.deltaTime;

        //タッチがあるかどうか？
        for (int i = 0; i < Input.touchCount; i++)
        {
            // タッチ情報を取得する
            Touch touch = Input.GetTouch(i);

            // ゲーム中ではなく、タッチ直後であればtrueを返す。
            if (touch.phase == TouchPhase.Ended && timeleft <= 0.0)
            {
                timeleft = 0.2f;
                if (enterCount == talks.Length)
                {
                    //SceneManager.LoadScene("BitterEnd2")
                    //HP = PlayerPrefs.GetInt(HPKey, 0);
                    //saionjiAmountScore = PlayerPrefs.GetInt(saionjiAmountScoreKey, 0);
                    GoEnding(); // エンディングに行く
                }
                else if (enterCount == selectNum)
                {
                    enterCount++;
                    scene.SetActive(true);
                    sliderFlag = true;
                }

                else if (enterCount == (selectNum+1) && sliderFlag == true)
                {
                    continue;
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
        }
    }

    public void GoEnding() // エンディングに行く
    {
        if (HP >= 50 && saionjiAmountScore >= 2000)
        {
            SceneManager.LoadScene("HappyEnd");
        }
        else if (HP >= 50 && saionjiAmountScore < 2000)
        {
            SceneManager.LoadScene("BitterEnd1");
        }
        else if (HP < 50 && saionjiAmountScore >= 2000)
        {
            SceneManager.LoadScene("BitterEnd2");
        }
        else if (HP < 50 && saionjiAmountScore < 2000)
        {
            SceneManager.LoadScene("BitterEnd3");
        }
        else if (HP == 0)
        {
            SceneManager.LoadScene("BadEnd");
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

        saionjiAmountScore += (amountScore - division);

        // ハイスコアの更新
        firstscore = PlayerPrefs.GetInt(firstscoreKey, 0);
        amountHighscore = PlayerPrefs.GetInt(amountHighscoreKey, 0);
        saionjiAmountHighscore = PlayerPrefs.GetInt(saionjiAmountHighscoreKey, 0);
        if (firstscore + amountScore > amountHighscore)
        {
            PlayerPrefs.SetInt(amountHighscoreKey, firstscore + amountScore);
        }

        if(saionjiAmountScore > saionjiAmountHighscore)
        {
            PlayerPrefs.SetInt(saionjiAmountHighscoreKey, saionjiAmountScore);
        }

        if ((HP + division / 10) > 100)
        {
            division = (100 - HP) * 10;
            HP = 100;
        }
        else
        {
            HP += division / 10;
        }
        amountScore = 0;

        /*PlayerPrefs.SetInt(HPKey, HP);
        PlayerPrefs.SetInt(amountScoreKey, amountScore);
        PlayerPrefs.SetInt(saionjiAmountScoreKey, saionjiAmountScore);*/

        //一応初期化(タイトルでできてない可能性あり？)
        PlayerPrefs.SetInt(HPKey, 100);
        PlayerPrefs.SetInt(amountScoreKey, 0);
        PlayerPrefs.SetInt(saionjiAmountScoreKey, 0);

        // Get100mlwaterの直前を呼び出す
        scene.SetActive(false);
        sliderFlag = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Get100mlwater : MonoBehaviour
{
   
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "友鷹", "", "友鷹", "友鷹" };
    string[] talks = {
                     "ん？何か光ってるものがあるぞ。\n"
                     , "これは…水？\n"
                     , "水100mlを入手した。\n"
                     , "なるほど。こういうのを集めればいいのか。\n"
                     , "さて、どこに向かおうかな。\n"
    };
    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;
    public GameObject water;

    private int enterCount = 0;
    private float timeleft;

    // 持っている水の合計
    private int amountScore;

    // PlayerPrefsで保存するためのキー
    private string amountScoreKey = "amountScore";

    // Use this for initialization
    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;
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
                
                if (enterCount < talks.Length)
                {
                    if(enterCount == 2) // 水を拾うことで画面から消す
                    {
                        water.SetActive(false);
                    }
                    NameLabel.text = names[enterCount];
                    TextLabel.text = talks[enterCount];
                    enterCount++;
                }
                else if (enterCount == talks.Length)
                {
                    enterCount++;
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
            }
        }
    }
}

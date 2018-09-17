using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeOnBoard : MonoBehaviour {
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "友鷹", "友鷹" };
    string[] talks = { "俺の名前は島袋友鷹(しまぶくろともたか)。大学2年生。\n"
                     , "今日から沖縄に船で旅行に行くつもりだ。\n"
                     , "お、来た来た。あれが今回俺の乗る「シーエス号」だな。\n"};
    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;
    private int enterCount = 0;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void LateUpdate()
    {
        //タッチがあるかどうか？
        for (int i = 0; i < Input.touchCount; i++)
        {

            // タッチ情報を取得する
            Touch touch = Input.GetTouch(i);

            // ゲーム中ではなく、タッチ直後であればtrueを返す。
            if (touch.phase == TouchPhase.Began)
            {
                if (enterCount == talks.Length)
                {
                    SceneManager.LoadScene("OnBoard");
                }
                else
                {
                    NameLabel.text = names[enterCount];
                    TextLabel.text = talks[enterCount];
                    enterCount++;
                }
            }
        }
    }
}

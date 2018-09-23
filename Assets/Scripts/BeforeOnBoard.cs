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
    private float timeleft;

    // Use this for initialization
    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        enabled = false;
        yield return new WaitForSeconds(5);
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
            if (touch.phase == TouchPhase.Began &&  timeleft <= 0.0)
            {
                timeleft = 1.0f;
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

    //IEnumerator WaitShortTime()
    //{
    //    // 0.5秒待つ
    //    yield return new WaitForSeconds(10);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹"};
    string[] talks = { "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n" };
    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;
    private int enterCount = 0;
    //public static int score = 0;
    //public static int HP = 100;
    private float timeleft;


    // Use this for initialization
    IEnumerator Start () {
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
            if (touch.phase == TouchPhase.Began && timeleft <= 0.0)

            {
                timeleft = 0.2f;
                if (enterCount == talks.Length)
                {
                    SceneManager.LoadScene("BeforeOnBoard");
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

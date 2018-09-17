using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnBoard : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    public GameObject[] Back; // 背景用
    string[] names = { "船長", "友鷹", "船長", "友鷹", "友鷹", "友鷹", "", "船長", "友鷹" };
    string[] talks = { "「チケット持っている方はこちらでお渡しください！」\n"
                     , "「これお願いします。」\n"
                     , "「はい！あ、おっとっと、すみません落としてしまいました。\n大人一人ですね！どうぞ中の方にお入りください。」\n"
                     , "「ありがとうございます。」\n"
                     , "大阪から沖縄まで長時間移動の船なので、船内は割と広い。\n"
                     , "レストランや売店など様々な施設が揃っているな。\n到着まで甲板でゆっくりと過ごそう。\n"
                     , "…"
                     , "「長らくの乗船お待たせいたしました。まもなく『小紋島』に到着いたします。」\n"
                     , "む。いつの間にか寝てしまっていたな。準備して降りなければ。\n"
    };
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
                    SceneManager.LoadScene("LeaveTheShip");
                }
                else
                {
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
}

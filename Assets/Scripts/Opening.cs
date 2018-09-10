using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    // Use this for initialization
    void Start () {
        //TextLabel.text = "こんにちは。Unityちゃん監督です。ここでは高得点をとるヒントを紹介するよ。\n";
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return) && enterCount == 1)
        {
            SceneManager.LoadScene("BeforeOnBoard");
        }
        else if (Input.GetKeyUp(KeyCode.Return) && enterCount == 0)
        {  // エンターキーが押されている間
            NameLabel.text = "友鷹\n";
            TextLabel.text = "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n";
            enterCount++;
        }
    }
}

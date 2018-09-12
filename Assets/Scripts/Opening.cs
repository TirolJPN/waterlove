using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹" };
    string[] talks = { "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n" };
    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;
    private int enterCount = 0;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void LateUpdate()
    {
        // エンターキーなら先に進み, バックスペースなら前に戻る
        if (Input.GetKeyUp(KeyCode.Return) && enterCount < talks.Length)
        {
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
        else if (Input.GetKeyUp(KeyCode.Backspace) && enterCount < talks.Length)
        {
            if (enterCount == 0)
            {
                SceneManager.LoadScene("Title");
            }
            else
            {
                enterCount--;
                enterCount--;
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
                enterCount++;
            }
        }
    }
}

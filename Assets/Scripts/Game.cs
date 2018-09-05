using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹" };
    string[] talks = { "水、とったど―――！！"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return) && enterCount < talks.Length)
        {
            NameLabel.text = names[enterCount];
            TextLabel.text = talks[enterCount];
            enterCount++;
        }

        else if (Input.GetKeyUp(KeyCode.Return) && enterCount == talks.Length)
        {
            SceneManager.LoadScene("HappyEnd");
        }
    }
}

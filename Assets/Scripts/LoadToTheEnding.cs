using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToTheEnding : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "友鷹", "", "友鷹",""
                       };
    string[] talks = { "よし、西園寺さんのところに戻ろう。どれくらい渡してあげようかな。\n"
                     , "渡す量を選んでください。\n"
                     , "残りは俺が飲もう\n"
                     , "HPが〇〇回復した！\n"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (enterCount == talks.Length)
            {
                //SceneManager.LoadScene("BitterEnd2");
            }
            else
            {
                NameLabel.text = names[enterCount];
                TextLabel.text = talks[enterCount];
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
                    enterCount++;
                }
            }
        }

        if (enterCount == talks.Length)
        {
            //SceneManager.LoadScene("BitterEnd2");
            if (Input.GetKeyUp(KeyCode.A))
            {
                SceneManager.LoadScene("HappyEnd");
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                SceneManager.LoadScene("BitterEnd1");
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                SceneManager.LoadScene("BitterEnd2");
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                SceneManager.LoadScene("BitterEnd3");
            }
            else if (Input.GetKeyUp(KeyCode.G))
            {
                SceneManager.LoadScene("BadEnd");
            }
        }
    }
}

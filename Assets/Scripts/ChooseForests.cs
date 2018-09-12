using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseForests : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    string[] names = { "" };
    string[] talks = { "森を選んでね"
    };
    //public AudioClip audioClip; //セリフ用
    //AudioSource audioSource;
    private int enterCount = 0;

    static bool isNorthSelected = false;
    static bool isSouthSelected = false;

    void LateUpdate()
    {

        if (Input.GetKeyUp(KeyCode.Return) && enterCount < talks.Length)
        {
            NameLabel.text = names[enterCount];
            TextLabel.text = talks[enterCount];
            enterCount++;
        }

        //else if (Input.GetKeyUp(KeyCode.Return) && enterCount == talks.Length)
        //{
        //    SceneManager.LoadScene("Game");
        //}


        else if (Input.GetKeyUp(KeyCode.N))
        {
            if (isNorthSelected == false)
            {
                if(isSouthSelected == true) // 2回目のときはリセット
                {
                    isSouthSelected = false;
                }
                isNorthSelected = true;
                SceneManager.LoadScene("NorthForest");
            }
            else
            {
                TextLabel.text = "既に行ってます。\n";
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            SceneManager.LoadScene("SouthForest");
        }
    }
}

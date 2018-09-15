using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseForests : MonoBehaviour {

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    public UnityEngine.UI.Text SelectableForestLabel; // 森の確認時用テキスト
    public UnityEngine.UI.Text UnselectableForestLabel; // 森の確認時用テキスト
    public GameObject[] scenes;
    string[] names = { "" };
    string[] talks = { "森を選んでね"
    };
    string Forest;
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
                if (isSouthSelected == true) // 2回目のときはリセット
                {
                    isSouthSelected = false;
                }
                else
                {
                    isNorthSelected = true;
                }
                SceneManager.LoadScene("NorthForest");
            }
            else
            {
                TextLabel.text = "既に行ってます。\n";
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {

            if (isSouthSelected == false)
            {
                if (isNorthSelected == true) // 2回目のときはリセット
                {
                    isNorthSelected = false;
                }
                else
                {
                    isSouthSelected = true;
                }
                SceneManager.LoadScene("NorthForest");
            }
            else
            {
                TextLabel.text = "既に行ってます。\n";
            }
        }
    }

    public void NorthButton() // 北の森を選んだ時にパネルを出す
    {
        if (isNorthSelected == false)
        {
            SelectableForestLabel.text = "北の森に行きますか。";
            Forest = "北の森";
            scenes[0].SetActive(true); // 確認パネルを表示
        }
        else
        {
            UnselectableForestLabel.text = "北の森には既に行ってます。\n";
            scenes[1].SetActive(true); // 確認パネルを表示
        }
    }

    public void SouthButton() // 南の森を選んだ時にパネルを出す
    {
        if (isSouthSelected == false)
        {
            SelectableForestLabel.text = "南の森に行きますか。";
            Forest = "南の森";
            scenes[0].SetActive(true); // 確認パネルを表示
        }
        else
        {
            UnselectableForestLabel.text = "南の森には既に行ってます。\n";
            scenes[1].SetActive(true); // 確認パネルを表示
        }
    }

    public void ReturnButton() // 戻るボタンを押したとき
    {
        foreach (GameObject g in scenes)
        {
            g.SetActive(false);
        }

        scenes[2].SetActive(true); // 北の森を押した時に反応させるようにする
        scenes[3].SetActive(true); // 南の森を押した時に反応させるようにする
    }

    public void GoForest()
    {
        if(Forest.Equals("北の森"))
        {
            if (isSouthSelected == true) // 2回目の森のときはフラグをリセット
            {
                isSouthSelected = false;
            }
            else
            {
                isNorthSelected = true;
            }
            SceneManager.LoadScene("NorthForest");
        }
        else
        {
            if (isNorthSelected == true) // 2回目の森のときはフラグをリセット
            {
                isNorthSelected = false;
            }
            else
            {
                isSouthSelected = true;
            }
            SceneManager.LoadScene("SouthForest");
        }
    }

    public void FlagManagement(bool flag1, bool flag2)
    {
        if (flag2 == true) // 2回目の森のときはフラグをリセット
        {
            flag2 = false;
        }
        else
        {
            flag1 = true;
        }
    }
}

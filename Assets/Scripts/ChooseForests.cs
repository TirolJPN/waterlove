using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseForests : MonoBehaviour
{

    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト
    public UnityEngine.UI.Text SelectableForestLabel; // 森の確認時用テキスト
    public UnityEngine.UI.Text UnselectableForestLabel; // 森の確認時用テキスト
    public GameObject[] scenes;
    public GameObject AssistPanel; // 最初の説明書き
    string[] names = { "" };
    string[] talks = { "森を選んでね"
    };
    string[] Forest = { "北の森", "南の森", "東の森" };
    int forestNumber; // 今選んでいる森の番号
    string[] ForestScenes = {"NorthForest", "SouthForest", "EastForest" };
    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;
    private int enterCount = 0;


    // 森選択フラグ 0:北の森 1:南の森 2:東の森
    static bool[] isForestsSelected = {false, false, false};

    IEnumerator Start()
    {
        foreach(bool flag in isForestsSelected) // 2回目の選択時に説明パネルはいらない
        {
            if(flag == true)
            {
                AssistPanel.SetActive(false);
                break;
            }
        }

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;
    }

    void LateUpdate()
    {

        if (Input.GetKeyUp(KeyCode.Return) && enterCount < talks.Length)
        {
            NameLabel.text = names[enterCount];
            TextLabel.text = talks[enterCount];
            enterCount++;
        }
    }

    // 森を選んだ時にパネルを出す
    public void SelectButton(int forestNumber)
    {
        // forestNumber
        // 0:北の森 1:南の森 2:東の森

        this.forestNumber = forestNumber; // 森番号の登録

        if (isForestsSelected[forestNumber] == false)
        {
            SelectableForestLabel.text =  Forest[forestNumber] + "に行きますか。";
            scenes[0].SetActive(true); // 確認パネルを表示
        }
        else
        {
            UnselectableForestLabel.text = Forest[forestNumber] + "には既に行ってます。\n";
            scenes[1].SetActive(true); // 確認パネルを表示
        }
    }

    public void ReturnButton() // 戻るボタンを押したときブロックパネルを全消しする
    {
        foreach (GameObject g in scenes)
        {
            g.SetActive(false);
        }
        
    }

    public void AssistOkButton() // 説明書きのOKボタンを押したときにブロックパネルを消す
    {
        AssistPanel.SetActive(false);
    }

    public void GoForest()
    {
        for (int i = 0; i < isForestsSelected.Length; i++)
        {
            if (isForestsSelected[i] == true)
            {
                FlagReset(); // 2回目の森のときはフラグをリセット
                break;
            }

            if (i == isForestsSelected.Length - 1) // 1回目の森選択ならフラグを真にする
            {
                isForestsSelected[forestNumber] = true;
            }
        }
        SceneManager.LoadScene(ForestScenes[forestNumber]);
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

    // フラグの初期化
    public static void FlagReset()
    {
        for(int i = 0; i < isForestsSelected.Length; i++)
        {
            isForestsSelected[i] = false;
        }
    }
}
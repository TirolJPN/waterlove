using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gallery : MonoBehaviour {

    public UnityEngine.UI.Text[] HappyButtonText; // ボタンテキスト
    public UnityEngine.UI.Text[] BitterButtonText; // ボタンテキスト
    public UnityEngine.UI.Text[] BadButtonText; // ボタンテキスト

    public AudioClip audioClip; // BGM用
    AudioSource audioSource;

    public AudioClip buttonClip; // ボタン用
    AudioSource audioSourceButton;

    public static bool[] isHappyEndCleard = { false };
    public static bool[] isBitterEndCleard = { false, false, false };
    public static bool[] isBadEndCleard = { false };
    public static bool[][] Flags = { isHappyEndCleard, isBitterEndCleard, isBadEndCleard };

    public static string[] HappyName = { "希望の「小紋島」" };
    public static string[] BitterName = { "足りなかった思いやり", "優しさ故の過ち", "詰め切れない距離" };
    public static string[] BadName = { "果てない暗闇の中で" };
    public static string[][] endNames = { HappyName, BitterName, BadName };

    public static bool galleryFlag = false; // ギャラリーから読み込んでいるかどうか

    void Start () {
        galleryFlag = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        UnityEngine.UI.Text[][] texts = { HappyButtonText, BitterButtonText, BadButtonText };
        for(int end = 0; end < Flags.Length; end++)
        {
            for(int i = 0; i < Flags[end].Length; i++)
            {
                // クリアフラグのロード
                FlagSet(end, i, (SaveFlag.GetBool(endNames[end][i], false)));
                if (Flags[end][i] == true)
                {
                    // 1度見たエンディングはギャラリーに名前が出る
                    texts[end][i].text = endNames[end][i];
                }
            }
        }
    }

    void Update () {
		
	}

    public void HappyButton(int i)
    {
        if (isHappyEndCleard[i] == true)
        {
            galleryFlag = true;
            Button("HappyEnd");
        }
    }

    public void BitterButton(int i)
    {
        if (isBitterEndCleard[i] == true)
        {
            galleryFlag = true;
            Button("BitterEnd" + (i+1) );
        }
    }

    public void BadButton(int i)
    {
        if (isBadEndCleard[i] == true)
        {
            galleryFlag = true;
            Button("BadEnd");
        }
    }

    public void ReturnButton()
    {
        Button("Title");
    }

    public void Button(string scene) // ボタン押したとき
    {
        audioSourceButton = gameObject.GetComponent<AudioSource>();
        audioSourceButton.clip = buttonClip;
        audioSourceButton.Play();
        SceneManager.LoadScene(scene);
    }

    // エンディングクリアフラグをセットする
    public static void FlagSet(int end, int i, bool flag) 
    {
        Flags[end][i] = flag;
    }

    // クリア時にそのエンディングフラグを真にする
    public static void HappyFlagSet(int i)
    {
        FlagSet(0, i, true);
    }

    public static void BitterFlagSet(int i)
    {
        FlagSet(1, i, true);
    }

    public static void BadFlagSet(int i)
    {
        FlagSet(2, i, true);
    }

    public static void FlagReset() // 全てのフラグをfalseにする
    {
        for(int end = 0; end < Flags.Length; end++)
        {
            for(int i = 0; i < Flags[end].Length; i++)
            {
                Flags[end][i] = false;
                SaveFlag.SetBool(endNames[end][i], false);
            }
        }
    }
}

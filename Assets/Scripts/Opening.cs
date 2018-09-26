using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {

    string[] names = { "友鷹"};
    string[] talks = { "――大学2年の夏。それは、予想外の波乱に満ちた夏だった。\n" };
    string NextScene = "BeforeOnBoard";
    TouchWindow touchWindow;

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;
    // <<<<<<< feature/kosuke_debug
    //     private int enterCount = 0;
    //     //public static int score = 0;
    //     //public static int HP = 100;
    //     private float timeleft;


    //     // Use this for initialization
    //     IEnumerator Start () {
    //         audioSource = gameObject.GetComponent<AudioSource>();
    //         audioSource.clip = audioClip;
    //         audioSource.Play();
    //         enabled = false;
    //         yield return new WaitForSeconds(2);
    //         enabled = true;
    // =======

    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;

        touchWindow = GetComponent<TouchWindow>();
        touchWindow.SetText(names, talks, NextScene, false); // タッチ時のテキスト情報を専用ファイルに渡す
    }


    //IEnumerator WaitShortTime()
    //{
    //    // 0.5秒待つ
    //    yield return new WaitForSeconds(10);
    //}
}

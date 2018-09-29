using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    // 持っている水の合計
    private int amountScore;

    // PlayerPrefsで保存するためのキー
    // 手持ちの水合計
    private string amountScoreKey = "amountScore";

    // 友鷹のHP
    private int HP;

    private string HPKey = "HP";

    // 西園寺に上げた水の合計
    private int saionjiAmountScore;

    // PlayerPrefsで保存するためのキー
    // 手持ちの水合計
    private string saionjiAmountScoreKey = "saionjiAmountScore";

    public AudioClip audioClip; // BGM用
    AudioSource audioSource;

    public AudioClip buttonClip; // ボタン用
    AudioSource audioSourceButton;


    IEnumerator Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        enabled = false;
        yield return new WaitForSeconds(2);
        enabled = true;

        // 各値初期化
        amountScore = 0;
        PlayerPrefs.SetInt(amountScoreKey, amountScore);
        HP = 100;
        PlayerPrefs.SetInt(HPKey, HP);
        saionjiAmountScore = 0;
        PlayerPrefs.SetInt(saionjiAmountScoreKey, saionjiAmountScore);
        PlayerPrefs.Save();

        ChooseForests.FlagReset(); // タイトルに戻ったときにフラグリセット
        Gallery.galleryFlag = false;
        Debug.debugFlag = false;

        //Gallery.Flags[0][0] = SaveFlag.GetBool(Gallery.endNames[0][0], false);
        //Gallery.Flags[1][1] = SaveFlag.GetBool(Gallery.endNames[1][1], false);
        //Gallery.Flags[1][1] = true;
    }
}

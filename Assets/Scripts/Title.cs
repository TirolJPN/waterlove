﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    void LateUpdate()
    {
        // 各値初期化
        amountScore = 0;
        PlayerPrefs.SetInt(amountScoreKey, amountScore);
        HP = 100;
        PlayerPrefs.SetInt(HPKey, HP);
        saionjiAmountScore = 0;
        PlayerPrefs.SetInt(saionjiAmountScoreKey, saionjiAmountScore);

        PlayerPrefs.Save();
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Opening");
        }
    }
}

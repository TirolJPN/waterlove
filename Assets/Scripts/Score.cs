using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Score : MonoBehaviour
{
    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    //public Text highScoreText;
    

    // スコア
    private int score;

    // ハイスコア
    static int highScore;

    // PlayerPrefsで保存するためのキー
    //private string highScoreKey = "highScore";

    // 持っている水の合計
    private int amountScore;

    // PlayerPrefsで保存するためのキー
    private string amountScoreKey = "amountScore";




    void Start()
    {
        Initialize();
    }

    void Update()
    {
        // スコアがハイスコアより大きければ
        if (amountScore < score)
        {
            amountScore = score;
            PlayerPrefs.SetInt(amountScoreKey, amountScore);
            PlayerPrefs.Save();
        }

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        //highScoreText.text = highScore.ToString();

        
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // ハイスコアを取得する。保存されてなければ0を取得する。
        //highScore = PlayerPrefs.GetInt(highScoreKey, 0);

        // 合計量を取得する。保存されていなければ0を取得する。
        amountScore = PlayerPrefs.GetInt(amountScoreKey, 0);

        score = amountScore;
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point;
    }


    // ハイスコアの保存
    public void Save()
    {
        // ハイスコアをセットする
        //PlayerPrefs.SetInt(highScoreKey, highScore);

        // 合計スコアをセットする
        //amountScore += highScore;
        //PlayerPrefs.SetInt(amountScoreKey, amountScore);
        //PlayerPrefs.Save();

        // なぜかamountが保存されないため。上記処理をUpdate()に配置

        // ゲーム開始前の状態に戻す
        Initialize();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchWindow : MonoBehaviour {
    private int enterCount = 0;
    string[] names;
    string[] talks;
    GameObject[] BackPictures;
    int[] backSelectNumber; // Backのうちどれを選ぶか
    int[] backEnterCount; // enterCountがいつの時に変わるか
    int backIndex = 0; // 何回目の背景切り替えか
    string NextScene;
    bool isBackChange;
    public UnityEngine.UI.Text NameLabel; // 名前テキスト
    public UnityEngine.UI.Text TextLabel; // セリフテキスト

    public void Touching()
    {
        //タッチがあるかどうか？
        for (int i = 0; i < Input.touchCount; i++)
        {

            // タッチ情報を取得する
            Touch touch = Input.GetTouch(i);

            // ゲーム中ではなく、タッチ直後であればtrueを返す。
            if (touch.phase == TouchPhase.Ended)
            {
                if (enterCount == talks.Length)
                {
                    SceneManager.LoadScene(NextScene);
                }
                else
                {
                    NameLabel.text = names[enterCount];
                    TextLabel.text = talks[enterCount];
                    if(isBackChange == true)
                    {
                        Back back = GetComponent<Back>();
                        back.DarkChange(BackPictures, talks[enterCount]); // "…"なら暗転
                        if(backIndex < backEnterCount.Length && backEnterCount[backIndex] == enterCount) // 背景変えるタイミングのとき
                        {
                            back.BackChange(BackPictures, backSelectNumber[backIndex]); // 背景を変える
                            backIndex++;
                        }
                    }
                    enterCount++;
                }
            }
        }
    }

    public void SetText(string[] names, string[] talks, string NextScene, bool isBackChange)
    {
        this.names = names;
        this.talks = talks;
        this.NextScene = NextScene;
        this.isBackChange = isBackChange;
    }

    public void SetBack(GameObject[] BackPictures, int[] backSelectNumber, int[] backEnterCount)
    {
        this.BackPictures = BackPictures;
        this.backSelectNumber = backSelectNumber;
        this.backEnterCount = backEnterCount;
    }
}

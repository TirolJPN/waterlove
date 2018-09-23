using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchWindow : MonoBehaviour {
    private int enterCount = 0;
    string[] names;
    string[] talks;
    string NextScene;
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
            if (touch.phase == TouchPhase.Began)
            {
                if (enterCount == talks.Length)
                {
                    SceneManager.LoadScene(NextScene);
                }
                else
                {
                    NameLabel.text = names[enterCount];
                    TextLabel.text = talks[enterCount];
                    enterCount++;
                }
            }
        }
    }

    public void Setting(string[] names, string[] talks, string NextScene)
    {
        this.names = names;
        this.talks = talks;
        this.NextScene = NextScene;
    }
}

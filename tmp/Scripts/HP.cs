using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour {

    // HPを表示する
    public Text HPText;

    private int hp;

    private string HPKey = "HP";

    private float damage = 0;

    private int start_hp;
    // Use this for initialization
    void Start () {
        // HPを初期値に戻す
        start_hp = PlayerPrefs.GetInt(HPKey, 0);
        hp = PlayerPrefs.GetInt(HPKey, 0);
    }
	
	// Update is called once per frame
	void Update () {

        // HPを表示する
        damage = damage + 1 * Time.deltaTime;
        hp = start_hp - (int)damage;
        HPText.text = hp.ToString();
        PlayerPrefs.SetInt(HPKey, hp);
        // HPが0になったらBAD END
        if (hp == 0)
        {
            SceneManager.LoadScene("BadEnd");
        }
    }
}

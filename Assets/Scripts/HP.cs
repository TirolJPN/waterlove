using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour {

    // HPを表示する
    public Text HPText;

    private int hpMAX = 1000;

    private int hp;

    private float damage = 0;
    // Use this for initialization
    void Start () {
        // HPを初期値に戻す
        hp = hpMAX;
    }
	
	// Update is called once per frame
	void Update () {

        // HPを表示する
        damage = damage + 1 * Time.deltaTime;
        hp = hpMAX - (int)damage;
        HPText.text = hp.ToString();

        // HPが0になったらBAD END
        if (hp == 0)
        {
            SceneManager.LoadScene("BitterEnd");
        }
    }
}

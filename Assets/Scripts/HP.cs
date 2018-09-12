using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour {

    // HPを表示する
    public Text HPText;

    static int hpMAX = 100;

    static int hp = hpMAX - 10;

    private int start_hp;

    private float damage = 0;
    // Use this for initialization
    void Start () {
        // HPを初期値に戻す
        hp += 10;

        if(hp > hpMAX){
            hp = hpMAX;
        }

        start_hp = hp;
    }
	
	// Update is called once per frame
	void Update () {

        // HPを表示する
        damage = damage + 1 * Time.deltaTime;
        hp = start_hp - (int)damage;
        HPText.text = hp.ToString();

        // HPが0になったらBAD END
        if (hp == 0)
        {
            SceneManager.LoadScene("BadEnd");
        }
    }

    // 体力を返す
    public static int getHp(){
        return hp;
    }
}

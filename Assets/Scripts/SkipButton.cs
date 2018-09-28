using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour {

    private bool clearFlag = false; // 1度でもエンディング(BAD ENDを除く)を迎えているかどうか

	// Use this for initialization
	void Start () {
        for (int i = 0; i < Gallery.Flags.Length - 1; i++)
        {
            for (int j = 0; j < Gallery.Flags[i].Length; j++)
            {
                if(Gallery.Flags[i][j] == true)
                {
                    clearFlag = true;
                }
            }
        }

        if(clearFlag == false && Debug.debugFlag == false)
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Skip(string NextScene)
    {
        SceneManager.LoadScene(NextScene);
    } 
}

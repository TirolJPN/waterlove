using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Opening");
        }
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            SceneManager.LoadScene("LoadToTheEnding"); // デバッグ用
        }
    }
}

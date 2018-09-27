using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {
    int enterCount = 0;

    public void DarkChange(GameObject[] BackScenes, string talk) // 暗転
    {
        if (talk.Equals("…"))
        {
            foreach (GameObject g in BackScenes)
            {
                g.SetActive(false);
            }
            BackScenes[1].SetActive(true); // 暗転
        }
        /*else
        {
            foreach (GameObject g in BackScenes)
            {
                g.SetActive(false);
            }
            BackScenes[0].SetActive(true); // 暗転解除
        }*/
    }

    public void BackChange(GameObject[] BackScenes, int i)
    {
        foreach (GameObject g in BackScenes)
        {
            g.SetActive(false);
        }
        BackScenes[i].SetActive(true);
    }

}

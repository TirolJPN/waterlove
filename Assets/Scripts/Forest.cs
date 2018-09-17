using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Forest : MonoBehaviour {

    public AudioClip audioClip; //セリフ用
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

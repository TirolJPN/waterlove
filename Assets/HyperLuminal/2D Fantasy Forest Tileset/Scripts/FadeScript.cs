﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    // 分岐に用いる閾値
    const int branchThreshold = 100;

    // 取得してくるそのゲーム終了時のHP
    //private int hp;

    //ゲームのプレイ回数
    static int playTimes = 0;

    //ハイスコアの合計
    static int amount = 0;

    // 今回のゲームのスコアを表す
    //private int highScore;

    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    #region Member Variables
    /// <summary>
    /// The sprite that represents the fade on screen
    /// </summary>
    private SpriteRenderer spriteRenderer;

	/// <summary>
	/// The alpha value of the fade
	/// </summary>
	private float AlphaValue;
	
	/// <summary>
	/// A toggle for turning this tiles functionality on or off
	/// </summary>
	public enum FADETYPE
	{
		IN = 0,
		OUT = 1,
		NONE = 2,
		RESPAWN = 3,
	}
	public FADETYPE FadeType;
	#endregion

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		FadeType = FADETYPE.IN;
		AlphaValue = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// fade in or fade out based on the objects state
		if(FadeType == FADETYPE.IN)
		{
			AlphaValue -= 0.25f * Time.deltaTime;
			// limit the possible alpha value
			if(AlphaValue < 0.0f)
			{
				AlphaValue = 0.0f;
				FadeType = FADETYPE.NONE;
			}
		}
		else if(FadeType == FADETYPE.OUT)
		{
			AlphaValue += Time.deltaTime;

			// limit the possible alpha value
			if(AlphaValue > 1.0f)
			{
				AlphaValue = 1.0f;
				FadeType = FADETYPE.NONE;
				ChangeLevel();
			}
		}
		else if(FadeType == FADETYPE.RESPAWN)
		{
			AlphaValue += (2.0f * Time.deltaTime);
			// limit the possible alpha value
			if(AlphaValue > 1.0f)
			{
				AlphaValue = 1.0f;
				FadeType = FADETYPE.IN;
				GameObject.Find("PlayerCharacter").GetComponent<PlayerMovement>().RespawnPlayerAtCheckpoint();
			}
		}

		// set the objects new colour
		spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, AlphaValue);
	}

	/// <summary>
	/// Set the fade out state	
	/// </summary>
	public void FadeOut()
	{
		FadeType = FADETYPE.OUT;
	}

	/// <summary>
	/// Respawns the fade
	/// </summary>
	public void RespawnFade()
	{
		// set the respawn state
		FadeType = FADETYPE.RESPAWN;
	}

	/// <summary>
	/// Changes the level to the next level in the list
	/// </summary>
	private void ChangeLevel()
	{
        /*int levelID = Application.loadedLevel + 1;
		if(levelID > Application.levelCount - 1){ levelID = 0; }
		Application.LoadLevel(levelID);*/


        //1回めのゲーム
        if (playTimes == 0)
        {
            playTimes++;
            amount += Score.getHighScore();
            if (HP.getHp() < 50)
            {
                SceneManager.LoadScene("BitterEnd");
            }
            else
            {
                SceneManager.LoadScene("ChooseForests");
            }
        }
        //2回目のゲーム
        else
        {
            amount += Score.getHighScore();
            //閾値を超えていればhappy end
            if (amount >= branchThreshold)
            {
                SceneManager.LoadScene("HappyEnd");
            }
            else
            {
                SceneManager.LoadScene("BitterEnd");
            }
        }
    }
}

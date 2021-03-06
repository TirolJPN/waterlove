﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	#region Member Variables
	/// <summary>
	/// Player movement speed
	/// </summary>
	private float movementSpeed = 100.0f;

	/// <summary>
	/// Animation state machine local reference
	/// </summary>
	private Animator animator;

	/// <summary>
	/// The last position of the player in previous frame
	/// </summary>
	private Vector3 lastPosition;

	/// <summary>
	/// The last checkpoint position that we have saved
	/// </summary>
	private Vector3 CheckPointPosition;

	/// <summary>
	/// Is the player dead?
	/// </summary>
	private bool isDead = false;
    #endregion

    bool isUp = false;
    bool isDown = false;
    bool isRight = false;
    bool isLeft = false;

    public AudioClip getClipBlue; // 取得時のSE用
    public AudioClip getClipYellow; // 取得時のSE用
    public AudioClip getClipPurple; // 取得時のSE用
    AudioSource audioSourceGet;

    // Use this for initialization
    void Start ()
	{
		// get the local reference
		animator = GetComponent<Animator>();

		// set initial position
		lastPosition = transform.position;
		CheckPointPosition = transform.position;

        audioSourceGet = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		// check for player exiting the game
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

        // get the input this frame
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = 0;
        //float horizontal = 0;
        if (isUp == true)
        {
           vertical = 1;
        }
        else if(isDown == true)
        {
            vertical = -1;
        }
        else if (isRight == true)
        {
            horizontal = 1;
        }
        else if (isLeft == true)
        {
            horizontal = -1;
        }
        // if there is no input then stop the animation
        if ((vertical == 0.0f)&&(horizontal == 0.0f))
		{
			animator.speed = 0.0f;
		}

		// reset the velocity each frame
		GetComponent<Rigidbody2D>().velocity =	new Vector2(0, 0);

		// horizontal movement, left or right, set animation type and speed 
		if (horizontal > 0)
		{
            GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed * Time.deltaTime, 0);
            //transform.Translate(movementSpeed * 0.015f * Time.deltaTime,0, 0);
            animator.SetInteger("Direction", 1);
			animator.speed = 1.5f;
		}
		else if (horizontal < 0)
		{
            GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed * Time.deltaTime, 0);
            //transform.Translate(-movementSpeed * 0.015f * Time.deltaTime, 0, 0);
            animator.SetInteger("Direction", 3);
			animator.speed = 1.5f;
		}

		// vertical movement, up or down, set animation type and speed 
		if (vertical > 0)
		{
			//transform.Translate(0, movementSpeed * 0.9f * Time.deltaTime, 0);
			GetComponent<Rigidbody2D>().velocity =	new Vector2(GetComponent<Rigidbody2D>().velocity.x, movementSpeed * Time.deltaTime);
			animator.SetInteger("Direction", 0);
			animator.speed = 1.35f;
		}
		else if (vertical < 0)
		{
			//transform.Translate(0, -movementSpeed *  0.9f * Time.deltaTime, 0);
			GetComponent<Rigidbody2D>().velocity =	new Vector2(GetComponent<Rigidbody2D>().velocity.x, -movementSpeed * Time.deltaTime);
			animator.SetInteger("Direction", 2);
			animator.speed = 1.35f;
		}

		//compare this position to the last known one, are we moving?
		if(this.transform.position == lastPosition)
		{
			// we aren't moving so make sure we dont animate
			animator.speed = 0.0f;
		}

		// get the last known position
		lastPosition = transform.position;

		// if we are dead do not move anymore
		if(isDead == true)
		{
			GetComponent<Rigidbody2D>().velocity =	new Vector2(0.0f, 0.0f);
			animator.speed = 0.0f;
		}

	}

    public void OnUpDown()
    {
        isUp = true;
    }

    public void OnUpUp()
    {
        isUp = false;
    }

    public void OnDownDown()
    {
        isDown = true;
    }

    public void OnDownUp()
    {
        isDown = false;
    }

    public void OnRightDown()
    {
        isRight = true;
    }

    public void OnRightUp()
    {
        isRight = false;
    }

    public void OnLeftDown()
    {
        isLeft = true;
    }

    public void OnLeftUp()
    {
        isLeft = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "DangerousTile")
		{
			GameObject.Find("FadePanel").GetComponent<FadeScript>().RespawnFade();
			isDead = true;
		}
		else if(collider.gameObject.tag == "LevelChanger")
		{
			GameObject.Find("FadePanel").GetComponent<FadeScript>().FadeOut();
			isDead = true;
		}
        else if(collider.gameObject.name.Contains("blue"))
        {
            //音を鳴らす
            audioSourceGet.clip = getClipBlue;
            audioSourceGet.PlayOneShot(getClipBlue);
        }
        else if (collider.gameObject.name.Contains("yellow"))
        {
            //音を鳴らす
            audioSourceGet.clip = getClipYellow;
            audioSourceGet.PlayOneShot(getClipYellow);
        }
        else if (collider.gameObject.name.Contains("purple"))
        {
            //音を鳴らす
            audioSourceGet.clip = getClipPurple;
            audioSourceGet.PlayOneShot(getClipPurple);
        }
    }

	/// <summary>
	/// Respawns the player at checkpoint.
    /// 復活
	/// </summary>
	public void RespawnPlayerAtCheckpoint()
	{
		// if we hit a dangerous tile then we are dead so go to the checkpoint position that was last saved
		transform.position = CheckPointPosition;
		isDead = false;
	}

}

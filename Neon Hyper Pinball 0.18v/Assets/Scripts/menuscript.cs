using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuscript : MonoBehaviour {

    public Animator animator;
	public Animator buttonanimation;
	public Animator paneltomove;
	public float speed;
	public Button Trickster;
	public Button Joker;
	public Button Chaotic;
    
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if (paneltomove.GetInteger ("inttosaywhatweareon") == 3)
		{
			paneltomove.SetInteger ("inttosaywhatweareon", 0);
		}

			if (paneltomove.GetInteger ("inttosaywhatweareon") == -3)
		{
			paneltomove.SetInteger ("inttosaywhatweareon", 0);
		}

		if (paneltomove.GetInteger ("inttosaywhatweareon") == 1)
		{

			paneltomove.SetBool ("isonchaotic", true);
			paneltomove.SetBool ("isonjoker", false);
			paneltomove.SetBool ("isontrickster", false);
			Trickster.interactable = false;
			Joker.interactable = false;
			Chaotic.interactable = true;
		}

		if (paneltomove.GetInteger ("inttosaywhatweareon") == 0)
		{
			paneltomove.SetBool ("isonchaotic", false);
			paneltomove.SetBool ("isonjoker", false);
			paneltomove.SetBool ("isontrickster", true);
			Trickster.interactable = true;
			Joker.interactable = false;
			Chaotic.interactable = false;
		}

		if (paneltomove.GetInteger ("inttosaywhatweareon") == 2)
		{
			paneltomove.SetBool ("isonchaotic", false);
			paneltomove.SetBool ("isonjoker", true);
			paneltomove.SetBool ("isontrickster", false);
			Trickster.interactable = false;
			Joker.interactable = true;
			Chaotic.interactable = false;
		}

		if (paneltomove.GetInteger ("inttosaywhatweareon") == -1)
		{
			paneltomove.SetBool ("isonchaotic", false);
			paneltomove.SetBool ("isonjoker", true);
			paneltomove.SetBool ("isontrickster", false);
			Trickster.interactable = false;
			Joker.interactable = true;
			Chaotic.interactable = false;
		}

		if (paneltomove.GetInteger ("inttosaywhatweareon") == -2)
		{
			paneltomove.SetBool ("isonchaotic", true);
			paneltomove.SetBool ("isonjoker", false);
			paneltomove.SetBool ("isontrickster", false);
			Trickster.interactable = false;
			Joker.interactable = false;
			Chaotic.interactable = true;
		}

	}

    public void Quitgame()
    {
        Application.Quit();
    }

	public void Loadmenu()
	{
		Application.LoadLevel ("menu");
	}

    public void LoadLevel1()
    {
        Application.LoadLevel("Level1");
    }

    public void LoadLevel2()
    {
        Application.LoadLevel("Level2");
    }

    public void LoadLevel3()
    {
        Application.LoadLevel("Level3");
    }

	public void loadtutorial()
	{
		Application.LoadLevel("tutorial");
	}

    public void clickedscreen()
    {
        animator.SetTrigger("ispressed");
		buttonanimation.SetTrigger ("triggertomovein");

    }

	public void LevelSelect()
	{
		buttonanimation.SetTrigger ("triggertomoveout");
		paneltomove.SetTrigger ("in");
		paneltomove.SetBool ("levelselectisup" , true);
		paneltomove.SetBool ("readytomove" , true);
	}

	public void levelselectleft()
	{
		if (paneltomove.GetBool ("readytomove") == true)
		{
				paneltomove.SetBool ("readytomove",false);
				paneltomove.SetTrigger ("left");
				paneltomove.SetBool ("readytomove",false);
				paneltomove.SetInteger ("inttosaywhatweareon", paneltomove.GetInteger ("inttosaywhatweareon") + 1);
				readytomoveagain ();
		}			
	}
	public void levelselectright()
	{
		if (paneltomove.GetBool ("readytomove") == true )
		{
			paneltomove.SetBool ("readytomove",false);
			paneltomove.SetTrigger ("right");
			paneltomove.SetBool ("readytomove",false);
			paneltomove.SetInteger ("inttosaywhatweareon", paneltomove.GetInteger ("inttosaywhatweareon") - 1);
			readytomoveagain ();
		}
	}

	public void readytomoveagain()
	{
		StartCoroutine (readytomoveswitch ());
	}

	IEnumerator readytomoveswitch()
	{
		yield return new WaitForSeconds (0.5f);
		paneltomove.SetBool ("readytomove",true);
	}

}
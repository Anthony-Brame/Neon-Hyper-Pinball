using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableBall : MonoBehaviour {


    public Timer timer;
    public scoremanager scoreManager;

    public Text playerOneWins;
    public Text playerTwoWins;

    public bool PlayerOneWins;
    public bool PlayerTwoWins;

	public Animator animationplayer;

	public bool check;

    // Use this for initialization
	public void Start () 
	{
		check = false;	
	}
	
	// Update is called once per frame
	public void Update () 
	{
		
	}

    public void CheckWinner ()
	{
		Debug.Log ("checkwinner is called");
			check = true;
			if (scoreManager.playerOneScore > scoreManager.playerTwoScore) 
			{
				PlayerOneWins = true;
				PlayerTwoWins = false;
				EndGame ();
			}

			if (scoreManager.playerTwoScore > scoreManager.playerOneScore) 
			{
				PlayerTwoWins = true;
				PlayerOneWins = false;
				EndGame ();
			}
	}
		public void EndGame()
    {
        if (PlayerOneWins == true)
        {
			animationplayer.SetTrigger ("bluewins");
			StartCoroutine(Waittillend());
			//set loadlevel to go back to menu
        }

        if (PlayerTwoWins == true)
        {
			animationplayer.SetTrigger ("redwins");
			StartCoroutine(Waittillend());
			//set loadlevel to go back to menu
        }
    }

	IEnumerator Waittillend()
	{
		yield return new WaitForSeconds (7);
		Application.LoadLevel("menu");
	}
}

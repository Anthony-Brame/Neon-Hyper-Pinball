using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour {

    public int playerOneScore;
    public int playerTwoScore;
    public Text playonescoretext;
	public Text playeronescoretext2;
	public Text playertwoscoretext2;
	public Text playtwoscoretext;

    // Use this for initialization
    void Start()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playonescoretext.text = "Score" + playerOneScore.ToString();
        playtwoscoretext.text = "Score" + playerTwoScore.ToString();
		playeronescoretext2.text = "Score" + playerOneScore.ToString();
		playertwoscoretext2.text = "Score" + playerTwoScore.ToString();
    }

    public void increaseScore(int player, int score)
    {
        if (player == 1)
        {
            playerOneScore += score;
        }
        else if (player == 2)
        {
            playerTwoScore += score;
        }
    }
}

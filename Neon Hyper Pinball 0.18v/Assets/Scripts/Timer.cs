using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Transform TimeLeft;
    public Transform TextIndicator;
    public Transform TextLoading;
	public GameObject disable;
	public Animator animationplayer;

    public float currentAmount;
    [SerializeField]
    private float speed;
	
	// Update is called once per frame
	void Update () {

        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "" ;
            TextLoading.gameObject.SetActive(true);
        }
		else if (currentAmount > 100)
        {
			animationplayer.SetBool ("boom", true);
			Destroy (GameObject.FindWithTag ("Ball"));
			GameObject.FindGameObjectWithTag ("disable").GetComponent<DisableBall>().CheckWinner();
        }
        TimeLeft.GetComponent<Image>().fillAmount = currentAmount / 100;
	}

    void Start ()
    {
        
    }
        //freeze ball and flippers
        //play graphic of explosion
        //have the players scores display clearly on screen
        //then show a bit Graphic that say p1/p2 win
        //loadlevel menu
}
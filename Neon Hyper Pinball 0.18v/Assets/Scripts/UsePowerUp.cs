using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePowerUp : MonoBehaviour
{
    public bool Player1;
    public float velocity = 0.002f;        
    public Rigidbody2D rb;
	public Transform directionforp1;
	public Transform directionforp2;
    public float timer = 5f;
    public bool activatedpower;
    Vector2 p1vector2;
    Vector2 p2vector2;
    public GameObject Ball;

    private int mySide;
    public void setMySide(int i) { mySide = i; }

    [Header("Partical effect data")]
    public GameObject cardActivateParticalEffect;

    // Use this for initialization
    void Start()
    {
        Player1 = true;
		directionforp1 = GameObject.FindGameObjectWithTag ("P1_target").transform;
		directionforp2 = GameObject.FindGameObjectWithTag ("P2_target").transform;
        p1vector2 = new Vector2(directionforp1.position.x, directionforp1.position.y);
        p2vector2 = new Vector2(directionforp2.position.x, directionforp2.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Player1 == true && activatedpower == true)
        //{
        //    rb.AddForce(p1vector2 * velocity * Time.deltaTime);
        //    activatedpower = false;
        //}

        //if (Player1 == false && activatedpower == true)
        //{
        //    rb.AddForce(p2vector2 * velocity * Time.deltaTime);
        //    activatedpower = false;
        //}
        Ball = GameObject.FindGameObjectWithTag("Ball");
        if (Ball.GetComponent<Ball>().player1 == true)
        {
            Player1 = true;
        }
        else
        {
            Player1 = false;
        }
}
    public void OnMouseDown()
    {
        if (Player1 == true && gameObject.tag == "Firepower")
        {
            ActivateFirepower();
            GameObject.FindGameObjectWithTag("Ball").GetComponent<AudioSource>().Play();
            Debug.Log("Power Up Activated!");
        }
		if (Player1 == false && gameObject.tag == "Firepower")
		{
			ActivateFirepower2();
            GameObject.FindGameObjectWithTag("Ball").GetComponent<AudioSource>().Play();
            Debug.Log("Power Up Activated! 2");
        }
    }

    public void ActivateFirepower()
    {
        //activatedpower = true;

        GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().AddForce(p1vector2 * velocity, ForceMode2D.Impulse);
        Destroy(gameObject);
        Ball.GetComponentInChildren<ParticleSystem>().enableEmission = true;
        //rb.AddForce(p1vector2 * velocity * Time.deltaTime);

        //Spawn the partical effect for the card. 
        switch (mySide)
        {
            case 1:
                Instantiate(cardActivateParticalEffect, new Vector3(-2, -2, 1), Quaternion.identity);
                break;
            case 2:
                Instantiate(cardActivateParticalEffect, new Vector3(2, 2, 1), Quaternion.identity);
                break;
            default:
                Debug.Log("Error spawning.");
                break;
        }
        
    }

	public void ActivateFirepower2()
	{
        //activatedpower = true;

        GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().AddForce(p2vector2 * velocity, ForceMode2D.Impulse);
        Destroy(gameObject);
        Ball.GetComponentInChildren<ParticleSystem>().enableEmission = true;
        //rb.AddForce(p2vector2 * velocity * Time.deltaTime);

        //Spawn the partical effect for the card. 
        switch (mySide)
        {
            case 1:
                Instantiate(cardActivateParticalEffect, new Vector3(-2, -2, 1), Quaternion.identity);
                break;
            case 2:
                Instantiate(cardActivateParticalEffect, new Vector3(2, 2, 1), Quaternion.identity);
                break;
            default:
                Debug.Log("Error spawning.");
                break;
        }
    }
}

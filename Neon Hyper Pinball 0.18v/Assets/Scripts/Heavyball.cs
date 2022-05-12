using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavyball : MonoBehaviour {

    public bool Player1;
    public float timer = 5f;
    public bool activatedpower;
    public GameObject Ball;
    public Rigidbody2D rb;

    private int mySide;
    public void setMySide(int i) { mySide = i; }

    [Header("Partical effect data")]
    public GameObject cardActivateParticalEffect;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
        if (Ball.GetComponent<Ball>().player1 == true)
        {
            Player1 = true;
        }
        else
        {
            Player1 = false;
        }

        rb = Ball.GetComponent<Rigidbody2D>();

    }

    public void OnMouseDown()

    {
        if (Player1 == true && gameObject.tag == "Heavyball")
        {
            ActivateHeavyball();
            Debug.Log("Power Up Activated!");
        }

        if (Player1 == false && gameObject.tag == "Heavyball")
        {
            ActivateHeavyball2();
            Debug.Log("Power Up Activated! 2");
        }
    }

    public void ActivateHeavyball()
    {
        //rb.drag = 10;
        Ball.GetComponent<Ball>().ActivateHeavyball();
        //StartCoroutine(heavyBall());
        Destroy (gameObject);
    }

    public void ActivateHeavyball2()
    {
        //rb.drag = 10;
        Ball.GetComponent<Ball>().ActivateHeavyball2();
        //StartCoroutine(heavyBall());
        Destroy(gameObject);
    }




}


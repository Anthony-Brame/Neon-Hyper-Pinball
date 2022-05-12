using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{

    public bool player1;
    public bool player2;

    public GameObject ball;
    public Transform particleeffectfire;
    public Transform particleeffectimpact;
    public Camera Cam;

    public static Vector2 gravity;

    public GameObject[] spawnPoint;
    public GameObject powerSpawn1;
    public GameObject powerSpawn2;
    public bool spawnBall = false;

    public GameObject firepower;
    public GameObject multiball;
    public GameObject heavyball;
    public GameObject[] powerSpawn;
    public bool showPowerUp = false;
    public Sprite heavyBallsprite;
    public Sprite normalsprite;

    public int bumperscore = 5;
    public int goalscore = 500;

    public AudioSource audiofire;
	public AudioSource multiballaudio;
	public AudioSource heavyballaudio;
    public Transform originalCamPos;

    private GameObject [] ballCount;
    public int count;

    private Rigidbody2D rb;
    bool justSpawned = true;

    // Use this for initialization
    void Start()
    {
		ResetMass();
		StartSpawn();
        StartPowerupDisplay();
        particleeffectfire.GetComponent<ParticleSystem>().enableEmission = false;
        particleeffectimpact.GetComponent<ParticleSystem>().enableEmission = false;
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(spawnWait());
    }

    IEnumerator spawnWait()
    {
        yield return new WaitForSeconds(1f);
        justSpawned = false;
    }

    void StartSpawn()
    {
            spawnPoint = GameObject.FindGameObjectsWithTag("Spawn");
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Debug.Log("Spawn Found" + spawnPoint[i].name);
            }
    }

    void StartPowerupDisplay()
    {
        powerSpawn = GameObject.FindGameObjectsWithTag("DisplayPowerUp");
        for (int j = 0; j < powerSpawn.Length; j++)
        {
            Debug.Log("Spawn Found" + powerSpawn[j].name);
        }
    }

    void SpawnBall()
    {
        if (count == 1)
        {
            int spawnPointIndex = Random.Range(0, spawnPoint.Length);
            Instantiate(ball, spawnPoint[spawnPointIndex].transform.position, spawnPoint[spawnPointIndex].transform.rotation);
            GetComponent<Ball>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    void ShowPowerup()
    {
        if (player1)
        {
            GameObject card = Instantiate(firepower, powerSpawn1.transform.position, Quaternion.identity);
            card.GetComponent<UsePowerUp>().setMySide(1);
            Debug.Log("Spawned at 1");
        }
        else if (player2)
        {
            GameObject card = Instantiate(firepower, powerSpawn2.transform.position, Quaternion.identity);
            card.GetComponent<UsePowerUp>().setMySide(2);
            Debug.Log("Spawned at 2");
        }
    }

    void ShowMultiball()
    {
        if (player1)
        {
            GameObject card2 = Instantiate(multiball, powerSpawn1.transform.position, Quaternion.identity);
            card2.GetComponent<Multiball>().setMySide(1);
            Debug.Log("Spawned at 1");
        }

        if(player2)
        {
            GameObject card2 = Instantiate(multiball, powerSpawn2.transform.position, Quaternion.identity);
            card2.GetComponent<Multiball>().setMySide(2);
            Debug.Log("Spawned at 2");
        }
    }

    void ShowHeavyball()
    {
        if(player1)
        {
            GameObject card3 = Instantiate(heavyball, powerSpawn1.transform.position, Quaternion.identity);
            card3.GetComponent<Heavyball>().setMySide(1);
            Debug.Log("Spawned at 1");
        }

        if(player2)
        {
            GameObject card3 = Instantiate(heavyball, powerSpawn2.transform.position, Quaternion.identity);
            card3.GetComponent<Heavyball>().setMySide(2);
            Debug.Log("Spawned at 2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
		if (player1) 
		{
			//need to change the colour of the ball here to blue
		} else if (player2) 
		{
			//need to change the colour of the ball here to red
		}


		ballCount = GameObject.FindGameObjectsWithTag("Ball");
        count = ballCount.Length;

        //Reset balls position if:
        //A) The ball isn't moving
        //B) The ball is out of bounds
        if (!isBallMoving() && !justSpawned || isOutOfBounds())
        {
            this.transform.position = new Vector2(0, 0);
        }
    }

    bool isBallMoving()
    {
        //Return false if the ball is not moving, otherwise return true
		return !(rb.velocity.x == 0f && rb.velocity.y == 0f);
    }

    bool isOutOfBounds()
    {
        //Return true if the ball is too far left, up, right or down. Return false otherwise.
        return ((this.transform.position.x < -6.0f || this.transform.position.x > 6.0f) || (this.transform.position.y < -8.0f || this.transform.position.y > 8.0f));
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "P1_Area")
        {
            player1 = true;
            player2 = false;
            GetComponent<Rigidbody2D>().gravityScale = 0.7f;
            Debug.Log("Player 1 has the ball");
        }

        if (coll.gameObject.tag == "P2_Area")
        {
            player2 = true;
            player1 = false;
            GetComponent<Rigidbody2D>().gravityScale = -0.7f;
            Debug.Log("Player 2 has the ball");
        }

        if (coll.gameObject.tag == "Out_Of_Bounds")
        {
            SpawnBall();
            GameObject.FindGameObjectWithTag("score").GetComponent<scoremanager>().increaseScore(2, goalscore);
            Destroy(gameObject);
            Debug.Log("Hit Out of Bounds");
        }

        if (coll.gameObject.tag == "Out_Of_Bounds2")
        {
            SpawnBall();
            GameObject.FindGameObjectWithTag("score").GetComponent<scoremanager>().increaseScore(1, goalscore);
            Destroy(gameObject);
            Debug.Log("Hit Out of Bounds");
        }

        if (coll.gameObject.tag == "Firepower" && player1 == true)
        {
            ShowPowerup();
            Debug.Log("Power Up!");
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Firepower" && player2 == true)
        {
            ShowPowerup();
            Debug.Log("Power Up!");
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Multiball" && player1 == true)
        {
            ShowMultiball();
            Debug.Log("Power Up! multiball");
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Multiball" && player2 == true)
        {
            ShowMultiball();
			Debug.Log("Power Up! multiball");
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Heavyball" && player1 == true)
        {
            ShowHeavyball();
            Debug.Log("Power Up! heavyball");
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Heavyball" && player2 == true)
        {
            ShowHeavyball();
            Debug.Log("Power Up! heavyball");
            Destroy(coll.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "bumper" && player1 == true)
        {
            particleeffectimpact.GetComponent<ParticleSystem>().enableEmission = true;
            GameObject.FindGameObjectWithTag("score").GetComponent<scoremanager>().increaseScore(1, bumperscore);

            StartCoroutine(Shake());
        }

        if (target.gameObject.tag == "bumper" && player1 == false)
        {
            particleeffectimpact.GetComponent<ParticleSystem>().enableEmission = true;
            GameObject.FindGameObjectWithTag("score").GetComponent<scoremanager>().increaseScore(2, bumperscore);

            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {

        float elapsed = 0.0f;
        float duration = 0.5f;
        float magnitude = 0.05f;

        Vector3 originalCamPos = Cam.transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Cam.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        Cam.transform.position = originalCamPos;

    }

    public void ActivateHeavyball()
    {
        //rb.drag = 10;
        StartCoroutine(heavyBall());
		heavyballaudio.Play();
    }

    public void ActivateHeavyball2()
    {
        //rb.drag = 10;
        StartCoroutine(heavyBall());
		heavyballaudio.Play();
    }

    public void ResetMass()
    {
        this.GetComponent<Rigidbody2D>().mass = 1;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normalsprite;
        Debug.Log("Normal");
    }

    IEnumerator heavyBall()
    {
		
		this.GetComponent<Rigidbody2D>().mass = 20f;
        Debug.Log("Mass changed");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = heavyBallsprite;
        yield return new WaitForSeconds(5);
		this.GetComponent<Rigidbody2D>().mass = 1f;
		this.gameObject.GetComponent<SpriteRenderer>().sprite = normalsprite;
		Debug.Log("Normal");
		ResetMass();
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiball : MonoBehaviour {

    public bool Player1;
    public float timer = 5f;
    public bool activatedpower;
    public GameObject Ball;
    static List<GameObject> MultiballSpawn = new List<GameObject>();

    private int mySide;
    public void setMySide(int i) { mySide = i; }

    [Header("Partical effect data")]
    public GameObject cardActivateParticalEffect;

    // Use this for initialization
    void Start()
    {

        Debug.Log("Multiball size: " + Multiball.MultiballSpawn.Count);

        Multiball.MultiballSpawn.Clear();
        GameObject[] tempHolder = GameObject.FindGameObjectsWithTag("MultiballSpawn");
        for (int i = 0; i < tempHolder.Length; i++)
        {
            MultiballSpawn.Add(tempHolder[i]);
            Debug.Log("Spawn Found" + MultiballSpawn[i].name);
        }
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
    }
    public void OnMouseDown()
    {
        if (Player1 == true && gameObject.tag == "Multiball")
        {
            ActivateMultiball();
            Debug.Log("Power Up Activated!");
			GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().multiballaudio.Play();
        }

        if (Player1 == false && gameObject.tag == "Multiball")
        {
            ActivateMultiball2();
            Debug.Log("Power Up Activated! 2");
			GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().multiballaudio.Play();
        }
    }

    public void ActivateMultiball()
    {
        //GameObject MultiballSpawn = (GameObject)Instantiate(Ball, transform.position, transform.rotation);
        int spawnPointIndex = Random.Range(0, Multiball.MultiballSpawn.Count -1);
        Instantiate(Ball, MultiballSpawn[spawnPointIndex].transform.position, MultiballSpawn[spawnPointIndex].transform.rotation);
        Destroy (this.gameObject);
    }

    public void ActivateMultiball2()
    {
        //GameObject MultiballSpawn = (GameObject)Instantiate(Ball, transform.position, transform.rotation);
        int spawnPointIndex = Random.Range(0, Multiball.MultiballSpawn.Count -1);
        Instantiate(Ball, MultiballSpawn[spawnPointIndex].transform.position, MultiballSpawn[spawnPointIndex].transform.rotation);
        Destroy(this.gameObject);
    }
}


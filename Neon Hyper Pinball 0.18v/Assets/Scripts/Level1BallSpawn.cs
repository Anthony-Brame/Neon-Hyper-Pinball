using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1BallSpawn : MonoBehaviour {

    public GameObject ball;
    public GameObject[] spawnPoint;

    // Use this for initialization
    void Start () {

        LevelOneBallSpawn();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LevelOneBallSpawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);
        Instantiate(ball, spawnPoint[spawnPointIndex].transform.position, spawnPoint[spawnPointIndex].transform.rotation);
    }
}

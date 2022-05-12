using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public GameObject[] spawnPoints;
    public float spawnTime = 5.0f;
    public GameObject [] powerup;
    public bool spawnPowerup = true;

	// Use this for initialization
	void Start () {

        PowerupSpawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PowerupSpawn()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("PowerUpSpawn");

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            Debug.Log("Spawn Found" + spawnPoints[i].name);
        }
        InvokeRepeating("SpawnPowerUp", spawnTime, spawnTime);
    }

    void SpawnPowerUp()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(powerup [Random.Range(0, powerup.Length)], spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(destroySelf());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}

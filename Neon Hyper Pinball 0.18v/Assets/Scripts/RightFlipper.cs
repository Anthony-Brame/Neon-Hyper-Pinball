using UnityEngine;
using System.Collections;

public class RightFlipper : MonoBehaviour {

    public GameObject flipper;
    public Transform defaultPos;
    public Transform flippedPos;

    public float step;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void flip()
    {
        StartCoroutine(flipUp());
    }

    IEnumerator flipUp()
    {
        for (int i = 0; i < 10; i++)
        {
            //flipper.transform.rotation = Vector2.Lerp(flippedPos.transform.rotation, defaultPos.rotation, step / i);
            flipper.transform.rotation = Quaternion.Inverse(flippedPos.transform.rotation /*step / i*/);
            //flipper.transform.rotation = Mathf.InverseLerp(flippedPos.transform.rotation, defaultPos.rotation, step / i);
            yield return new WaitForSeconds(0.05f);
        }


        StartCoroutine(flipDown());
    }

    IEnumerator flipDown()
    {

        for (int i = 0; i < 10; i++)
        {
            //flipper.transform.rotation = Vector2.Lerp(defaultPos.rotation, flippedPos.transform.rotation, step / i);
            flipper.transform.rotation = Quaternion.Inverse(defaultPos.rotation /*step / i*/);
            //flipper.transform.rotation = Mathf.InverseLerp(defaultPos.rotation, flippedPos.transform.rotation, step / i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}

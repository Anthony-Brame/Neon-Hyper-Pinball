using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeftFlipper : MonoBehaviour {

    //public HingeJoint2D hingeJoint2D;
    //public JointMotor2D jointMotor2D;

    public GameObject flipper;
    public Transform defaultPos;
    public Transform flippedPos;
    //public Vector2 defaultPos;
    //public Vector2 flippedPos;

    //public float speed;
    //public bool isup;
    public float step;

    // Use this for initialization
    void Start () {
       // hingeJoint2D = GetComponent<HingeJoint2D>();
        //jointMotor2D = hingeJoint2D.motor;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //JointMotor2D motor = hingeJoint2D.motor;
        //motor.motorSpeed = 400;
        //hingeJoint2D.motor = motor;

        /*if(Input.GetMouseButtonDown(0))
        {
            motor.motorSpeed = 400;
        }*/
	}

    public void flip()
    {
        StartCoroutine(flipUp());
    }

    IEnumerator flipUp()
    {
        for (int i = 0; i < 10; i++)
        {
            flipper.transform.rotation = Quaternion.Lerp(flippedPos.transform.rotation, defaultPos.rotation, step / i);
            yield return new WaitForSeconds(0.05f);
        }
        

        StartCoroutine(flipDown());
    }

    IEnumerator flipDown()
    {

        for (int i = 0; i < 10; i++)
        {
            flipper.transform.rotation = Quaternion.Lerp(defaultPos.rotation, flippedPos.transform.rotation, step);
            yield return new WaitForSeconds(0.05f);
        }
    }



}

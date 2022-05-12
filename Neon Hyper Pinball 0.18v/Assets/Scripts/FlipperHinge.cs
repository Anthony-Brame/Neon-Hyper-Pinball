using UnityEngine;
using System.Collections;

public class FlipperHinge : MonoBehaviour {

    public float force = 20;
    public float speed = 10000;

    private HingeJoint2D joint;
    private JointMotor2D motor1;

    // Use this for initialization
    void Start() {
        joint = GetComponent<HingeJoint2D>();

    }

    // Update is called once per frame
    void Update() {
    }

    public void Up()
    {
        StartCoroutine(FlipUp());
    }

    IEnumerator FlipUp()
    {
        joint.useMotor = true;
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(FlipDown());
    }

    IEnumerator FlipDown()
    {
        joint.useMotor = false;
        yield return new WaitForSeconds(0.05f);
    }
}

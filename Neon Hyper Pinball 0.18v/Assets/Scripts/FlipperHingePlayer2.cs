using UnityEngine;
using System.Collections;

public class FlipperHingePlayer2 : MonoBehaviour {

    public float force = 20;
    public float speed = 10000;

    private HingeJoint2D joint2;
    private JointMotor2D motor2;

    // Use this for initialization
    void Start()
    {
        joint2 = GetComponent<HingeJoint2D>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Up()
    {
        StartCoroutine(FlipUp());
    }

    IEnumerator FlipUp()
    {
        joint2.useMotor = true;
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(FlipDown());
    }

    IEnumerator FlipDown()
    {
        joint2.useMotor = false;
        yield return new WaitForSeconds(0.05f);
    }
}

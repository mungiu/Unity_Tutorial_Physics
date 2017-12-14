using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLaunchScene3 : MonoBehaviour
{
    public Vector3 initialVelocity;
    public Vector3 initialAngularVelocity;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;      //simulates an initial kick
        rb.angularVelocity = initialAngularVelocity;
    }

    private void FixedUpdate()
    {
        ////simulates a continuous push, does not simulate an initial kick
        //rb.transform.position += initialVelocity * Time.deltaTime;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}

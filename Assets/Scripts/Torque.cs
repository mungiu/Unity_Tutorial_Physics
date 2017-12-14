using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    public Vector3 torque;     //axis along which it will spin
    public float torqueTime;

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (torqueTime >= 0f)   //no need for while since we are in FixedUpdate loop
        {
            rb.AddTorque(torque);
            torqueTime -= Time.deltaTime;
        }
	}
}

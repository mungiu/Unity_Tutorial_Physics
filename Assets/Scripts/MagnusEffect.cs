using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cross products between the liniar velocity and the angular velocity.
/// </summary>
public class MagnusEffect : MonoBehaviour
{
    // this mimics all other real life constants, 
    //a common practice in programming is to not input constants unless required 
    //and replace all with a number
    public float magnusConstant = 1f;   //should never be zero 

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //implementing the magnus force on the object
        rb.AddForce( Vector3.Cross(rb.angularVelocity, rb.velocity) * magnusConstant);
	}
}

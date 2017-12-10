using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidDrag : MonoBehaviour
{
    [Range(1, 2f)]  // (stokes flow law): at low velocity: V^1, at higher velocity: approaces V^2
    public float velocityExponent;      // none
    public float dragConstant;

    private PhysicsEngine physicsEngine;

    // Use this for initialization
    void Start ()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
	}

    private void FixedUpdate()
    {
        float speed = physicsEngine.velocityVector.magnitude;                       //vector length
        float dragSize = CalculateDrag(speed);

        Vector3 dragVector = dragSize * -physicsEngine.velocityVector.normalized;   //speed directed
        physicsEngine.AddForce(dragVector);
    }

    float CalculateDrag(float speed)
    {
        float dragForce = dragConstant * Mathf.Pow(speed, velocityExponent);
        return dragForce;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalGravitation : MonoBehaviour
{
    private PhysicsEngine[] physicsEngineArr;   //OUT
    private const float bigG = 6.673e-11f;      // [m^3 kg^-1 s^-2] OUT

    // Use this for initialization
    void Start ()
    {
        physicsEngineArr = GameObject.FindObjectsOfType<PhysicsEngine>();   //find all physics engine object in-game
    }

    private void FixedUpdate()
    {
        CalculateGravity(); //OUT
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    /// <summary>
    /// Calculates gravity between all objects in the physicsEngineArr.
    /// </summary>
    public void CalculateGravity()
    {
        foreach (PhysicsEngine physicsEngineA in physicsEngineArr)
            foreach (PhysicsEngine physicsEngineB in physicsEngineArr)
                // eliminating duplication of two objects acting on themselves &&
                // eliminating the case when we have found ourselves in the list
                if (physicsEngineA != physicsEngineB && physicsEngineA != this)
                {
                    float m2 = physicsEngineB.mass;             //[kg]
                    float m1 = physicsEngineA.mass;             //[kg]

                    Vector3 offset =
                        physicsEngineA.transform.position -
                        physicsEngineB.transform.position;      //[meters]

                    float rSquared = Mathf.Pow(offset.magnitude, 2f);
                    float gravityMagnitude = bigG * m1 * m2 / rSquared; //order of * & / does not matter
                    Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

                    physicsEngineA.AddForce(-gravityFeltVector);// in the opposite direction off physics engine B gravity felt
                }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialKick : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 initialKick;

    //Script execution order: 1 Awake, 2 OnEnable, 3 Start
    private void OnEnable()
    {
        //rb.GetComponent<Rigidbody>();
        rb.angularVelocity = initialKick;
    }
}

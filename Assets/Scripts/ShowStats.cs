using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //every time something changes in the scene it will redo Update(), even in edit mode
public class ShowStats : MonoBehaviour
{
    private Rigidbody rigidBody;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log($"{name} inertia tensor: {rigidBody.inertiaTensor}");
        Debug.Log($"{name} Center of Mass: {rigidBody.centerOfMass}");
	}
}

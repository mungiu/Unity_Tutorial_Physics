using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PhysicsEngine))]
public class PhysicsEngine : MonoBehaviour
{
    public float mass;                  // [kg]
    public Vector3 velocityVector;      // [m s^-1]         = [m/s]         (average velocity this fixed update)
    public Vector3 netForceVector;      // N [kg m s^-2]    = [kg(m/s^2)]   (a sum of all forces)

    private List<Vector3> forceVectorList = new List<Vector3>();


    // Use this for initialization
    void Start()
    {
        SetupThrustTrails();
    }

    /// <summary>
    /// NOTE: Rendering trails first & then summing forces (clearing force list after render)
    /// </summary>
    private void FixedUpdate()
    {
        RenderTrails();

        SumForces();

        forceVectorList.Clear();

        UpdatePosition();
    }



    /// <summary>
    /// Sums up all forces in the list.
    /// </summary>
    /// <param name="appliedForce"></param>
    /// <returns></returns>
    private void SumForces()
    {
        netForceVector = Vector3.zero;      //reseting value
        foreach (Vector3 forceVector in forceVectorList)
            netForceVector += forceVector;
    }


    /// <summary>
    /// Calculates acceleration and velocity, uses them to update position per second.
    /// </summary>
    void UpdatePosition()
    {
        Vector3 accelerationVector = netForceVector / mass;         //Acceleration: a = F/m (since F = m*a) (updated per second)
        velocityVector += accelerationVector * Time.deltaTime;      //speed = acceleration * time NOTE: "+=" in code
        transform.position += velocityVector * Time.deltaTime;      //distance = velocity * time    NOTE: "+=" in code
    }


    /// <summary>
    /// Adds incoming force parameter to list.
    /// </summary>
    /// <param name="forceVector"></param>
    public void AddForce(Vector3 forceVector)
    {
        forceVectorList.Add(forceVector);
        //Debug.Log($"Adding force {forceVector} to {gameObject.name}");
    }


    /// <summary>
    /// SHOW TRAILS CODE
    /// </summary>
    /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
    public bool showTrails = true;

    private LineRenderer lineRenderer;
    private int numberOfForces;

    

    /// <summary>
    /// Defining the thrust/force trails of currently applied forces (yellow lines)
    /// Does not instantiate them.
    /// </summary>
    public void SetupThrustTrails()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.2F;
        lineRenderer.endWidth = 0.2F;

        lineRenderer.useWorldSpace = false;
    }

    /// <summary>
    /// Instantiates the defined thrust/force trails (yellow lines)
    /// </summary>
    public void RenderTrails()
    {
        if (showTrails)
        {
            lineRenderer.enabled = true;
            numberOfForces = forceVectorList.Count;
            lineRenderer.positionCount = numberOfForces * 2;
            int i = 0;

            foreach (Vector3 forceVector in forceVectorList)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
            lineRenderer.enabled = false;
    }

}
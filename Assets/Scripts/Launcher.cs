using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float maxLaunchSpeed;
    public float launchSpeed;
    public AudioClip launchSound, windUpSound;
    public PhysicsEngine ballPhysicsEngine;

    private AudioSource audioSource;
    private float extraSpeedPerFrame;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = windUpSound;             //so we know the length of the clip

        extraSpeedPerFrame =                        //ensuring max speed is achieved at end of clip
            (maxLaunchSpeed * Time.fixedDeltaTime) / audioSource.clip.length;   
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void OnMouseDown()
    {
        launchSpeed = 0f;
        InvokeRepeating("IncreaseLaunchSpeed", 0.5f, Time.fixedDeltaTime);

        audioSource.clip = windUpSound;             //ensuring every launch has new windup sound set
        audioSource.Play();
    }

    private void OnMouseUp()
    {
        CancelInvoke();
        audioSource.Stop();

        audioSource.clip = launchSound;
        audioSource.Play();

        PhysicsEngine newBall = Instantiate(ballPhysicsEngine);
        newBall.transform.parent = GameObject.Find("LaunchedBalls").transform;

        Vector3 launchVelocity = new Vector3(1, 1, 0).normalized * launchSpeed;
        newBall.velocityVector = launchVelocity;
    }

    void IncreaseLaunchSpeed()
    {
        if (launchSpeed <= maxLaunchSpeed)
            launchSpeed += extraSpeedPerFrame;
    }
}

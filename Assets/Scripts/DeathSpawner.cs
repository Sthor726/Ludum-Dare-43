using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpawner : MonoBehaviour {

    public ParticleSystem particles;

    public float fireRate = 1.5f;
    float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            particles.Play();
            timer = fireRate;
        }

	}
}

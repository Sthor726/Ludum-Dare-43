using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingLava : MonoBehaviour {

    public float startTime = 2f;

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        startTime -= Time.deltaTime;
        if(startTime < 0)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
	}
}

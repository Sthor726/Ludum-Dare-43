using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour {

    public GameObject[] particles;
    public GameObject dieParticles;
    public void Start()
    {
        particles = GameObject.FindGameObjectsWithTag("Dark");
    }

	public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Bottom")
        {
            Destroy(gameObject);
            Instantiate(dieParticles, transform.position, transform.rotation);
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Light")
        {
            Destroy(gameObject);
            Instantiate(dieParticles, transform.position, transform.rotation);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Switch")
        {
            Destroy(collision.gameObject);
            foreach(GameObject particle in particles)
            {
                particle.tag = "Light";
                ParticleSystem.MainModule main = particle.GetComponent<ParticleSystem>().main;
                main.startColor = Color.white;
            }
        } else if(collision.gameObject.tag == "KillSwitch")
        {
            BossManager.instance.Die();
            Destroy(collision.gameObject);
        }
    }

}

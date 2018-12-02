using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject[] particles;

    public GameObject dieParticles;

    public void Start()
    {
        particles = GameObject.FindGameObjectsWithTag("Dark");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "End")
        {
            GameManager.instance.EndLevel();
        }
        else if (collision.tag == "Bottom")
        {
            GameManager.instance.FailedLevel();
            Destroy(gameObject);
            Instantiate(dieParticles, transform.position, transform.rotation);
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Dark" || other.tag == "Bottom")
        {
            GameManager.instance.FailedLevel();
            Destroy(gameObject);

            Instantiate(dieParticles, transform.position, transform.rotation);
        }
           
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Switch")
        {
            Destroy(collision.gameObject);
            foreach (GameObject particle in particles)
            {
                particle.tag = "Dark";
                ParticleSystem.MainModule main = particle.GetComponent<ParticleSystem>().main;
                main.startColor = Color.black;
            }
        }
    }
}

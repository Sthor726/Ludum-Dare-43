using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    Rigidbody2D rb;

    bool grounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    float verticalInput;

    float horizontalInput;
    public float moveSensitivity = 0.5f;

    bool facingRight = true;

    public bool isSelected;

    ParticleSystem particles;

    public GameObject clone;
    public bool cloneInScene;
    bool cloneAlive = true;

    public GameObject jumpParticles;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        particles = transform.Find("Particles").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        

        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isSelected)
        {
            verticalInput = Input.GetAxisRaw("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveSpeed * Time.deltaTime * horizontalInput, rb.velocity.y);

            if (verticalInput > 0.2f && grounded)
            {
                grounded = false;
                rb.AddForce(Vector3.up * jumpForce * verticalInput);
            } 
            if (facingRight == false && horizontalInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && horizontalInput < 0)
            {
                Flip();
            }
            if (grounded == false && verticalInput < 0.2f && rb.velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * verticalInput);
            }

           
        }
        
	}
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && isSelected)
        {
            grounded = false;
            rb.AddForce(Vector3.up * jumpForce * verticalInput);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && cloneInScene == true)
        {
            isSelected = !isSelected;
            if (isSelected == true)
            {
                particles.Stop();

            }
            else
            {
                particles.Play();
            }

            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && cloneInScene == false && grounded == true)
        {

            Instantiate(clone, transform.position, transform.rotation);
            cloneInScene = true;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

 
}

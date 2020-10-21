using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 1000;
    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isTouchingWall = false;

    //Dash part
    private bool isDashing;
    private bool canDashing = true;
    IEnumerator dashCoroutine;
    float direction = 1;
    float normalGravity;

    //particles
    public ParticleSystem Particles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    { 
        float xDisplacement = Input.GetAxis("Horizontal") * speed ;
        
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //jump and test @on ground@
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }

        if(Input.GetKey(KeyCode.LeftShift)&& isGrounded )
        {
            xDisplacement = Input.GetAxis("Horizontal") * speed * 3;  //SHIFT  mode activated
            rb.velocity = new Vector2(xDisplacement, rb.velocity.y);
        }

        if (Input.GetKey("w") && isTouchingWall)
        {
            rb.transform.position += Vector3.up / 75 ; //climbing of climable objects
        }


        //dash stuff 1st check on direction
        float horisontal = Input.GetAxis("Horizontal");

        if (horisontal != 0)
        {
            direction = horisontal;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canDashing == true)
        {
            
            if (dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }

            dashCoroutine = Dash(.1f, 1);
            StartCoroutine(dashCoroutine);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        if (col.gameObject.name.Equals("MovingGround"))
        {
            this.transform.parent = col.transform;
        }
        if (col.gameObject.name.Equals("MovingGround2"))
        {
            this.transform.parent = col.transform;
        }
        if (col.gameObject.name.Equals("Move"))
        {
            this.transform.parent = col.transform;
        }
        if (col.gameObject.tag == "Climable")
        {
            isTouchingWall = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D col)
    {
        
        if (col.gameObject.name.Equals("MovingGround"))
        {
            this.transform.parent = null; 
        }
        if (col.gameObject.name.Equals("MovingGround2"))
        {
            this.transform.parent = null;
        }
        if (col.gameObject.name.Equals("Move"))
        {
            this.transform.parent = null;
        }
        if (col.gameObject.tag == "Climable")
        {
            isTouchingWall = false;
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            CreateParticles();
            rb.AddForce(new Vector2(direction*200, 0), ForceMode2D.Impulse);
        }
    }

    IEnumerator Dash(float dashDuration ,float dashCd)
    {
        Vector2 originalVelocity = rb.velocity;
        isDashing = true;
        canDashing = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.gravityScale = normalGravity;
        rb.velocity = originalVelocity;
        yield return new WaitForSeconds(dashCd);
        canDashing = true;

    }

    void CreateParticles()
    {
        Particles.Play();
    }
}

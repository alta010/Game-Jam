using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 400f;
    public int maxJumps = 2;
    int numJumps;
    public Rigidbody2D rb;
    bool facing_Right = true;
    public GameObject gc;
    bool isGrounded;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        numJumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isGrounded = gc.GetComponent<GroundCheck>().isGrounded;
    }

    private void Move()
    {
        
        if (!isGrounded)
        {
            float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            anim.SetFloat("speed", Mathf.Abs(deltaX));
            float newXPos = transform.position.x +(float) (deltaX*0.75);
            transform.position = new Vector2(newXPos, transform.position.y);
            if (deltaX > 0 && !facing_Right)
            {
                Flip();
            }
            if (deltaX < 0 && facing_Right)
            {
                Flip();
            }
            
        }
        else
        {
            float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
            anim.SetFloat("speed",Mathf.Abs(deltaX));
            float newXPos = transform.position.x + deltaX;
            transform.position = new Vector2(newXPos, transform.position.y);
            if (deltaX > 0 && !facing_Right)
            {
                Flip();
            }
            if (deltaX < 0 && facing_Right)
            {
                Flip();
            }
        }
        Debug.Log(isGrounded);
        if ((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && numJumps > 0))
        {
            Jump();
        }
        if (numJumps == 0 && isGrounded)
        {
            numJumps = maxJumps;
        }

    }
    void Jump()
    {
        isGrounded = false;
        rb.AddForce(new Vector2(0f, jumpForce));
        numJumps--;

    }
    private void Flip()
    {
        facing_Right = !facing_Right;

        Vector3 theScale = transform.localScale;
        transform.localScale = theScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
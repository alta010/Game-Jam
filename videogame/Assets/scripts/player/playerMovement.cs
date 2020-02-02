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
    bool isGrounded;
    public Animator anim;
    public bool onLadder = false;
    GameObject cam;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = GameObject.Find("Main Camera");
    }

    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string tag = collision.gameObject.tag;
        if (tag == "Ground") {
            isGrounded = true;
            numJumps = maxJumps;
        }
        if (tag == "Live Wire") {
            PlayerHealthScript health = GetComponent<PlayerHealthScript>();
            health.Damage(health.maxHP);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        string tag = collision.gameObject.tag;
        if (tag == "Ladder") {
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        string tag = collision.gameObject.tag;
        if (tag == "Ladder") {
            onLadder = false;
        }
    }

    private void Move()
    {
        if (onLadder) {
            float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed * 2;
            anim.SetFloat("speed", Mathf.Abs(deltaY));
            float newYPos = transform.position.y + deltaY * 0.75f;
            
            if (!isGrounded || deltaY > 0) {
                transform.position = new Vector2(transform.position.x, newYPos);
            }
        }   

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
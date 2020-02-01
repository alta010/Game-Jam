using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemyScript : MonoBehaviour
{

    public Vector2 moveDirection;
    public float speed;
       
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.magnitude < 10) {
            //Debug.Log("Faster!");
            rb.AddRelativeForce(moveDirection * speed - rb.velocity);
        }
        else {
            //Debug.Log("Too fast!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        moveDirection *= -1;
    }
}

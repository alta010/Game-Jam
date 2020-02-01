using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemyScript : MonoBehaviour
{

    public Vector2 moveDirection;
    public float speed;

    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(moveDirection * speed - rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Ground") return;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.flipX = !sr.flipX;
        moveDirection *= -1;
    }
}

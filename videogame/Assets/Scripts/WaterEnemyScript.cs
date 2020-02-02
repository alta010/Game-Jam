using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemyScript : MonoBehaviour
{
    public Vector2 moveDirection = Vector2.left;
    public float speed = 7;
    public Sprite sprite1, sprite2;
    bool animWait = false;
    bool spriteToUse = false;

    private void Update() {
        if (!animWait)
            StartCoroutine(Animate());
    }

    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(moveDirection * speed - rb.velocity);
    }

    IEnumerator Animate() {
        animWait = true;
        GetComponent<SpriteRenderer>().sprite = spriteToUse ? sprite1 : sprite2;
        spriteToUse = !spriteToUse;
        yield return new WaitForSeconds(0.5f);
        animWait = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Ground") return;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.flipX = !sr.flipX;
        moveDirection *= -1;
    }
}

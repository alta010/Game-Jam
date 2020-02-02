using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBunnyScript : MonoBehaviour
{
    public float jumpHeight = 300;
    public int jumpChance = 5;
    bool grounded = false;

    public Sprite sprite1, sprite2;

    void Jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
        grounded = false;
        GetComponent<SpriteRenderer>().sprite = sprite2;
    }

    private void FixedUpdate() {
        if (Random.Range(0, 100) < jumpChance && grounded) {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Ground") {
            GetComponent<SpriteRenderer>().sprite = sprite1;
            grounded = true;
        }
    }
}

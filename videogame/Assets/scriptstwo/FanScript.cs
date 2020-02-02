using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    public float strength;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag != "Ground") {
            Debug.Log("Pushing " + collision.gameObject.name);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * strength);
        }
    }
}

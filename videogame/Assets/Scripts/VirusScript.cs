using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour
{
    public float maxHeight = 4, maxTravel = 4, speed = 5;
    Vector2[] flightNodes = new Vector2[3];
    int targetNodeIndex = 0;
    bool waitUntilInBounds = false;
    int pathStep = -1;

    public Sprite sprite1, sprite2;

    private void Start() {
        Vector2 pos = transform.position;
        flightNodes[0] = new Vector2(pos.x - maxTravel, pos.y + maxHeight);
        flightNodes[1] = pos;
        flightNodes[2] = new Vector2(pos.x + maxTravel, pos.y + maxHeight);
    }

    private void NextNode() {
        waitUntilInBounds = true;
        if (targetNodeIndex == 0 || targetNodeIndex == 2) {
            pathStep *= -1;
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else {
            GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        targetNodeIndex += pathStep;
    }

    private bool OutOfBounds() {
        Vector2 pos = transform.position;
        return
            pos.y < flightNodes[1].y
        ||  pos.y > maxHeight
        ||  pos.x < flightNodes[0].x
        ||  pos.x > flightNodes[2].x;
    }

    private Vector2 GetRelativeVector(Vector2 from, Vector2 to) {
        return Vector2.MoveTowards(from, to, 1f) - from;
    }
    
    private void FixedUpdate() {
        if (OutOfBounds() && !waitUntilInBounds) {
            waitUntilInBounds = true;
            NextNode();
        }
        else if (!OutOfBounds()) {
            waitUntilInBounds = false;
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 moveDirection = GetRelativeVector(transform.position, flightNodes[targetNodeIndex]);
        rb.AddRelativeForce(moveDirection * speed - rb.velocity);
    }
}

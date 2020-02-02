using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public Transform gc;
    public bool isGrounded = true;
    public LayerMask groundLayer;
    // Start is called before the first frame 

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(gc.position, 0.01f, groundLayer);
        Debug.Log(isGrounded);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttck : MonoBehaviour
{
    public bool attacking = false;
    private float attackTime = 0.3f;
    private Animator anim;
    public GameObject projectile;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator Attack() {
        attacking = true;
        GameObject activeProjectile = Instantiate(projectile);
        playerMovement pm = GetComponent<playerMovement>();
        activeProjectile.transform.position = transform.position + (pm.facing_Right ? Vector3.right : Vector3.left) * 2;
        activeProjectile.GetComponent<Rigidbody2D>().AddForce((pm.facing_Right ? Vector2.right : Vector2.left) * 100);
        yield return new WaitForSeconds(attackTime);
        attacking = false;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !attacking)
        {
            Debug.Log("Pressed attack button");
            attacking = true;
            StartCoroutine(Attack());
        }
        anim.SetBool("attack", attacking);
    }
}

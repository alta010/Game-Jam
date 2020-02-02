using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttck : MonoBehaviour
{
    public bool attacking = false;
    private float attackTime = 0.3f;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator Attack() {
        attacking = true;
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

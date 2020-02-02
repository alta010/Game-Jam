using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttck : MonoBehaviour
{
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackedCd = 0.3f;
    public Collider2D attackTrigger;
    private Animator anim;
    // Start is called before the first frame update

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F) && !attacking)
        {
            attacking = true;
            attackTimer = attackedCd;

            attackTrigger.enabled = true;
        }
        if(attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        Debug.Log(attacking);
        anim.SetBool("attack", attacking);
        
    }

}

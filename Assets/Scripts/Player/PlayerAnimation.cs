using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    private Animator n_anim;     //habdle to animator
    private Animator n_swordAnimation; //handle for sword animation

    void Start()
    {
        n_anim = GetComponentInChildren<Animator>();      //assign handle to animator  for sprites in player
        n_swordAnimation = transform.GetChild(1).GetComponent<Animator>(); //assign handle to animator  for sword animation in player
    }
    
    public void Move(float move)
    {
        //pn: using mathf.abs to get absolute value;
        if (n_anim != null)
        {
            n_anim.SetFloat("Move", Mathf.Abs(move));
        }
    }
    public void Jump(bool jumping)
    {
        n_anim.SetBool("Jumping", jumping);
    }
    public void Attack()
    {
        if (n_anim != null)
        {
            n_anim.SetTrigger("Attack");
        }
        if (n_anim != null)
        {
            n_swordAnimation.SetTrigger("SwordAnimation");
        }

    }
    public void Hit()
    {
        n_anim.SetTrigger("Hit");
    }
    public void Death()
    {
        n_anim.SetTrigger("Death");
    }
}

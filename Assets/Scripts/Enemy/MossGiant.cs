using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
    }
    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        //Debug.Log("Damage(in Moss Gaint)");
        health -= 1;
        n_anim.SetTrigger("Hit");
        isHit = true;
        n_anim.SetBool("InCombat", true); //to do attack

        if (health < 1)
        {
            isDead = true;
            n_anim.SetTrigger("Death");
            GameObject n_diamond = Instantiate(n_diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //changing gems value using n_diamond to local gems value using base.gems
            n_diamond.GetComponent<Diamond>().n_gems = base.gems;
        }
    }   
}

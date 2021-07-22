using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
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
        //Debug.Log("Damage(in skeleton)");
        health -= 1;
        n_anim.SetTrigger("Hit");
        isHit = true;
        n_anim.SetBool("InCombat", true);

        if(health < 1)
        {
            isDead = true;
            n_anim.SetTrigger("Death");
            //Instantiating to get diamond after enemy dies
            GameObject n_diamond = Instantiate(n_diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //changing gems value using n_diamond to local gems value using base.gems
            n_diamond.GetComponent<Diamond>().n_gems = base.gems;

        }
    }
}

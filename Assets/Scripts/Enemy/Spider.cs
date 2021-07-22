using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab; // to instantiate the acid effect
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {
        
    }

    public override void Movement()
    {
        //to behave differenty from paraent;
    }

    public void Damage()
    {
        if(isDead == true)
        {
            return;
        }
        //Debug.Log("Damage(in spider)");
        Health -= 1;
        if(Health < 1)
        {
            isDead = true;
            n_anim.SetTrigger("Death");
            GameObject n_diamond = Instantiate(n_diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //changing gems value using n_diamond to local gems value using base.gems
            n_diamond.GetComponent<Diamond>().n_gems = base.gems;
            
        }
        
        

    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}

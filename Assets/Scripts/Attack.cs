using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool n_canDamage = true; // variable to determine if the damage function can be called

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("hit " + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (n_canDamage == true)
            {
                hit.Damage();
                n_canDamage = false;
                StartCoroutine(ResetDamageCall());
            }        
        }
    }
    // Coroutine to switch variable back to true after 0.5 seconds
    IEnumerator ResetDamageCall()
    {
        yield return new WaitForSeconds(0.5f);
        n_canDamage = true;
    }
}

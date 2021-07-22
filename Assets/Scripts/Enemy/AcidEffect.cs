using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 5.0f); // to destroy the acideffect if it does not hit the player
    }

    private void Update()
    {
        // fo shoot the acid 
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }
    // to check if acid effect hit the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);   // to destroy the player 
            }
        }
    }
}

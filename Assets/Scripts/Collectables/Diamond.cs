using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int n_gems = 1;
    //private Player n_add;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player n_player = other.GetComponent<Player>();
            if (n_player != null)
            {
                n_player.AddGems(n_gems);
                Destroy(this.gameObject);
            }
            
        }
    }
}

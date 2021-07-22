using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public GameObject winPanel;
    private Player n_player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            winPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            winPanel.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        winPanel.SetActive(false);
    }

}

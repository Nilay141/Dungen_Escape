using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int currentSelectedItem; // to check that we are buying the item we have selected
    public int currentItemCost;     // to know the price of current selected item

    private Player n_player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            n_player = other.GetComponent<Player>();
            if(n_player != null)
            {
                UIManager.Instance.OpenShop(n_player.Diamonds);
            }
            shopPanel.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("selecteditem");
        switch (item)
        {
            case 0: //for flame sword
                UIManager.Instance.updateshopselecion(113);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1: //for boots of flight
                UIManager.Instance.updateshopselecion(1);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2: //key to castle
                UIManager.Instance.updateshopselecion(-105);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        switch(currentSelectedItem)
        {
            case 0: //for flame sword
                GameManager.Instance.HasFlameSword = true;
                break;
            case 1: //for boots of flight
                GameManager.Instance.HasBootsofFlight = true;
                break;
            case 2: //key to castle
                GameManager.Instance.HasKeyTocastle = true;
                break;
        }
        if (n_player.Diamonds >= currentItemCost)
        {
            //Diamonds deduction from player
            n_player.Diamonds -= currentItemCost;
            UIManager.Instance.OpenShop(n_player.Diamonds);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("you don't have enough money");
            shopPanel.SetActive(false);
        }

    }
    public void ClosePanel()
    {
        shopPanel.SetActive(false);
    }
}

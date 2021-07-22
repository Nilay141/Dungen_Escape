using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager n_instance;

    public static UIManager Instance
    {
        get
        {
            if(n_instance == null)
            {
                Debug.LogError("UI manager has not been assignrd");
            }
            return n_instance;
        }
    }

    public Text playerGemCountText; // to get the gemcount of canvas UI shop panel
    public Image selectionImg;      // to highlight the selected option of canvas UI
    public Image selectionImgPrice; // to highlight the selected option of canvas UI for Gems
    public Text gemCountText;       // to get gemcount in HUD Panel
    public Image[] healthBar;
    public void OpenShop(int gemcount)
    {
        playerGemCountText.text = ""+ gemcount +"G";
    }

    public void updateshopselecion(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
        selectionImgPrice.rectTransform.anchoredPosition = new Vector2(selectionImgPrice.rectTransform.anchoredPosition.x, yPos);
    }

    private void Awake()
    {
        n_instance = this;
    }
    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i=0; i <= livesRemaining; i++)
        {
            //do nothing till we reaach the max
            if( i == livesRemaining )
            {
                // hide this one;
                healthBar[i].enabled = false;

            }
        }
    }

}

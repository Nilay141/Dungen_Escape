using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    //private Player n_player;
    private string playStoreId = "3881285";
    private string appStoreId = "3881284";

    // accessing the types of add using their placement
    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore; // to check where to target add where to play store or app  store
    public bool isTestAd;          // if u want to play test ads

    public void Start()
    {
        Advertisement.AddListener(this);
        TargetLocate();
    }

    /*void Awake()
    {
        n_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }*/
    private void TargetLocate()
    {
        if( isTargetPlayStore )
        {
            Debug.Log("target lockaed playstore");
            Advertisement.Initialize(playStoreId, isTestAd);
            return;
        }
        Advertisement.Initialize(appStoreId, isTestAd);
        
    }
    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Debug.Log("IT ads 0");
        Advertisement.Show(interstitialAd);
        Debug.Log("IT ads 1");
    }
    public void PlayRewardedAd()
    {       
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Debug.Log("RE ads 0");
        Advertisement.Show(rewardedVideoAd);
        Debug.Log("RE ads 1");
    }

    public void OnUnityAdsReady(string placementId)
    {
        // use to call => Advertisement.Show(rewardedVideoAd); to display ads
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //used to through the error when we have problem loading the add or internet connectivity issue
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // used to mute the game audio  so u can hear ads audio clearly
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //used to reward the player if he completes the ads without any error or issues
        //throw new System.NotImplementedException();

        switch (showResult)
        {
            case ShowResult.Finished:
                // if ad seen completely the
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("here's your reward , watch more to get more");
                    GameManager.Instance.n_player.AddGems(100);
                    UIManager.Instance.OpenShop(GameManager.Instance.n_player.Diamonds);
                }
                break;

            case ShowResult.Failed:
                Debug.Log("Something went worng, Ensure the internet connectivity");
                break;
            case ShowResult.Skipped:
                Debug.Log("you have skipped, the advertisement so no reward for you");
                
                break;
        }
    }

    

}

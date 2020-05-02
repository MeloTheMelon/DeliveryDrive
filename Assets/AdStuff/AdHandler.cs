using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdHandler : MonoBehaviour
{

    //Test ad string ca-app-pub-3940256099942544/5224354917
    //My ID string ca-app-pub-8712620617352872/3522439001
    private string appID = "cca-app-pub-8712620617352872~5792066042";
    private RewardedAd fullscreenAd;

    // Start is called before the first frame update
    void Start()
    {
        
        MobileAds.Initialize(appID);
        loadFullscreenAd();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            requestFullscreenAd();
        }
    }


    public void loadFullscreenAd()
    {
        fullscreenAd = new RewardedAd("ca-app-pub-3940256099942544/5224354917");
        fullscreenAd.LoadAd(new AdRequest.Builder().Build()); 
    }

    public void requestFullscreenAd()
    {
        if (fullscreenAd.IsLoaded())
        {
            fullscreenAd.Show();
            loadFullscreenAd();
        }
        else
        {
            PlayerPrefs.SetInt("AdCounter", 10);
        }
    }


}

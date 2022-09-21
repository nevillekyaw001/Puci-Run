using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class GoogleAdMobController : MonoBehaviour
{
    public static GoogleAdMobController instance;
    private InterstitialAd interstitial;
    private RewardedAd rewarded;
    public string SampleInterAd = "ca-app-pub-3940256099942544/1033173712";
    public string SampleRewardAd = "ca-app-pub-3940256099942544/5224354917";
    public string SampleAppId = "ca-app-pub-3940256099942544~3347511713";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    #region UNITY MONOBEHAVIOR METHODS


    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        RequestAndLoadInterstitialAd();
        RequestAndLoadRewardedAd();

    }

    #endregion

    #region INTERSTITIAL ADS

    public void RequestAndLoadInterstitialAd()
    {
        

        interstitial = new InterstitialAd(SampleInterAd);
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            PointSystem.AdsPoints += 1;
            PointSystem.UpdateAdsPoints();
            RequestAndLoadInterstitialAd();
        }
        
    }

    #endregion

    #region REWARDED ADS

    public void RequestAndLoadRewardedAd()
    {
        rewarded = new RewardedAd(SampleRewardAd);
        rewarded.OnAdLoaded += HandleRewardedAdLoaded;
        rewarded.OnUserEarnedReward += HandleUserEarnedReward;
        rewarded.OnAdClosed += HandleRewardedAdClosed;
        rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rewarded.LoadAd(request);
    }

    public void ShowRewardedAd()
    {
        if (this.rewarded.IsLoaded())
        {
            this.rewarded.Show();
            PointSystem.AdsPoints += 10;
            PointSystem.UpdateAdsPoints();
            RequestAndLoadRewardedAd();
        }
    }

    public void RewardAdclosed()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewarded.LoadAd(request);
    }
    #endregion

    #region AdHandlers
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //InterPointToGive = true;
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        //RewardPointToGive = true;
    }


    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        RequestAndLoadRewardedAd();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {

        RequestAndLoadRewardedAd();
    }
    #endregion
}
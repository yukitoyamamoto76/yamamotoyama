using UnityEngine;
using UnityEngine.Advertisements;

public class GameControllerScript : MonoBehaviour
{
    private string playStoreID = "3620426";
    private string appStoreID = "3620427";

    private string interstitialAd = "video";
    private string rewardVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private void Start()
    {
        Advertisement.Initialize(gameID);
    }

    private void InitializeAdvertisement()
    {
        if (isTargetPlayStore) { Advertisement.Initialize(playStoreID, isTestAd); return; }
        Advertisement.Initialize(appStoreID, isTestAd);

    }
    public void PlayInterstitialAd()
    {
        if(!Advertisement.IsReday(interstitialAd)){ return;}
        Advertisement.Show(interstitialAd);
    }
}

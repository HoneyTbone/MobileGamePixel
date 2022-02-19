using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdCreation : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "4578494";
#elif UNITY_ANDROID
    private string gameId = "4578495";
#endif
    private string mySurfacingId = "rewardedVideo";

    bool testMode = false;

    private static AdCreation playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        if(Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Not Ready for Ad");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == mySurfacingId)
        {

        }
    
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}

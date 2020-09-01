﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour,IUnityAdsListener 
{
    public string GooglePlay_ID = "3788745";
    string myPlacementId = "rewardedVideo";

    public GameObject Player;
    
    // public string ApplePlay_ID = "3788744";

     bool GameMode = true;
    // Start is called before the first frame update

    
    void Start()
    {
        Advertisement.AddListener (this);

        Advertisement.Initialize(GooglePlay_ID, GameMode);
    }

    public void DisplayVideo_AD()
    {
       
        Advertisement.Show(myPlacementId);
        
    }
    
    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            Player.SetActive(true);
            
            NextLevelAi.IncreasedTime = 1f;


        } else if (showResult == ShowResult.Skipped) {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            Player.SetActive(true);
            

            NextLevelAi.IncreasedTime = 1f;

        } else if (showResult == ShowResult.Failed) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            NextLevelAi.IncreasedTime = 1f;
            
            Player.SetActive(true);
            
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId) 
        {
        }
    }

    public void OnUnityAdsDidError (string message) 
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }
}

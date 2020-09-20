﻿using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject nextLevelAi;
    public GameObject RulesText;
    public GameObject RulesTextForLevel11;
    public GameObject ContinueButton;
    public Lives _livesRef;
    public GameObject LoseCanvas;
    public GameObject BounceObjectsToDectavateForLevel11;
    public GameObject ContinueButtonForLevel11;
    
    private static bool DidInvokeForRulesHappen;
    private static bool DidInvokeHappenForPlayerSpawn;
    private static bool DidPlayerPressContinue;
    
    private static bool DidInvokeForRulesHappenForLevel11;
    private static bool DidInvokeHappenForPlayerSpawnForLevel11;
    private static bool DidPlayerPressContinueFoeLevel11;



    private void Awake()
    {
        
    }

    public void ContinueButtonFunction()
    {
        DidPlayerPressContinue = true;
        InvokeSetPlayerAfterDelay();
        Destroy(ContinueButton, 0.1f);
    }

    public void ContinueButtonFunctionForLevel11()
    {
        DidPlayerPressContinueFoeLevel11 = true;
        InvokeSetPlayerAfterDelayForLevel11();
        DeactivateButton();
    }

    void DeactivateButton()
    {
        if (SceneManager.GetActiveScene().buildIndex == 11 && DidPlayerPressContinueFoeLevel11 == true)
        {
            ContinueButtonForLevel11.SetActive(false);
        }
    }
    

    private void SetPlayerActiveAfterDelay()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Player.SetActive(true);
            DidInvokeForRulesHappen = true;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Player.SetActive(false);
            
        }
        
        if (DidInvokeForRulesHappen == false)
            RulesText.SetActive(true); 
        else
            RulesText.SetActive(false);

        if (DidPlayerPressContinue == true)
        {
            ContinueButton.SetActive(false);
            Player.SetActive(true);
        }
    }

    private void InvokeSetPlayerAfterDelayForLevel11()
    {
        if (DidInvokeHappenForPlayerSpawnForLevel11 == false)
        {
            if (DidPlayerPressContinueFoeLevel11) SetPlayerActiveAfterDelay();

            DidInvokeHappenForPlayerSpawnForLevel11 = true;
        }
        else if (DidInvokeHappenForPlayerSpawnForLevel11)
        {
            Player.SetActive(true);
        }
    }

    
    private void InvokeSetPlayerAfterDelay()
    {
        if (DidInvokeHappenForPlayerSpawn == false)
        {
            if (DidPlayerPressContinue) SetPlayerActiveAfterDelay();

            DidInvokeHappenForPlayerSpawn = true;
        }
        else if (DidInvokeHappenForPlayerSpawn)
        {
            Player.SetActive(true);
        }
    }
    
    
    private void DeactivateRulesWhenPlayerIsSpawnedForLevel11()
    {

      
        if (SceneManager.GetActiveScene().buildIndex == 11 && Time.timeScale == NextLevelAi.IncreasedTime)
        {
            RulesTextForLevel11.SetActive(false);
     
        }
        
    }

    private void DeactivateRulesWhenPlayerIsSpawned()
    {

        if (Player.activeSelf) RulesText.SetActive(false);
        
        
    }

    // Update is called once per frame
     void Update()
     
    {

        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            if (DidPlayerPressContinueFoeLevel11 == true)
            {
                Time.timeScale = NextLevelAi.IncreasedTime;
                BounceObjectsToDectavateForLevel11.SetActive(true);
            }
            else
            {
                BounceObjectsToDectavateForLevel11.SetActive(false);
            }
        }
        
        
        if (!_livesRef.Heart3.activeSelf)
        {
           LoseCanvas.SetActive(true);
           Player.SetActive(false);
        }
        
        DeactivateRulesWhenPlayerIsSpawned();
        DeactivateButton();
        DeactivateRulesWhenPlayerIsSpawnedForLevel11();

    }

     
}

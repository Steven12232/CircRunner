using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    public GameObject GameObjectsToDeactivateForLevel1;

    private static bool DidInvokeForRulesHappen;
    private static bool DidInvokeHappenForPlayerSpawn;
    private static bool DidPlayerPressContinue;
    
    private static bool DidInvokeForRulesHappenForLevel11;
    private static bool DidInvokeHappenForPlayerSpawnForLevel11;

    private bool DidTimeChangeAfterPlayerPressedContinueOnLevel11;
    
    public  static bool DidPlayerPressContinueFoeLevel11;



    private void Awake()
    {

    }
    
    
    public void ContinueButtonFunction()
    {
        DidPlayerPressContinue = true;
        InvokeSetPlayerAfterDelay();
        Time.timeScale = 1.0f;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObjectsToDeactivateForLevel1.SetActive(true);
        }
        Destroy(ContinueButton, 0.1f);
        
        
    }

    public void ContinueButtonFunctionForLevel11()
    {
        DidPlayerPressContinueFoeLevel11 = true;
        InvokeSetPlayerAfterDelayForLevel11();
        Time.timeScale = 1.0f;
        DeactivateButton();
    }

    void DeactivateButton()
    {
        if (SceneManager.GetActiveScene().buildIndex == 11 && DidPlayerPressContinueFoeLevel11)
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
        DidTimeChangeAfterPlayerPressedContinueOnLevel11 = false;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Player.SetActive(false);
            
        }
        
        if (DidInvokeForRulesHappen == false)
            RulesText.SetActive(true); 
        else
            RulesText.SetActive(false);

        if (DidPlayerPressContinue)
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

    public void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("HighestLevel", 1);

        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetInt("HighestLevel", 2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            PlayerPrefs.SetInt("HighestLevel", 3);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            PlayerPrefs.SetInt("HighestLevel", 4);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            PlayerPrefs.SetInt("HighestLevel", 5);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            PlayerPrefs.SetInt("HighestLevel", 6);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            PlayerPrefs.SetInt("HighestLevel", 7);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            PlayerPrefs.SetInt("HighestLevel", 8);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            PlayerPrefs.SetInt("HighestLevel", 9);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            PlayerPrefs.SetInt("HighestLevel", 10);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            PlayerPrefs.SetInt("HighestLevel", 11);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            PlayerPrefs.SetInt("HighestLevel", 12);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            PlayerPrefs.SetInt("HighestLevel", 13);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            PlayerPrefs.SetInt("HighestLevel", 14);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 15)
        {
            PlayerPrefs.SetInt("HighestLevel", 15);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            PlayerPrefs.SetInt("HighestLevel", 16);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            PlayerPrefs.SetInt("HighestLevel", 17);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            PlayerPrefs.SetInt("HighestLevel", 18);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 19)
        {
            PlayerPrefs.SetInt("HighestLevel", 19);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 20)
        {
            PlayerPrefs.SetInt("HighestLevel", 20);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 21)
        {
            PlayerPrefs.SetInt("HighestLevel", 21);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 22)
        {
            PlayerPrefs.SetInt("HighestLevel", 22);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 23)
        {
            PlayerPrefs.SetInt("HighestLevel", 23);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 24)
        {
            PlayerPrefs.SetInt("HighestLevel", 24);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 25)
        {
            PlayerPrefs.SetInt("HighestLevel", 25);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 26)
        {
            PlayerPrefs.SetInt("HighestLevel", 26);
        }
    }



    void ChangeTimeLevel11()
    {
        if (DidTimeChangeAfterPlayerPressedContinueOnLevel11 == false)
        {
            Time.timeScale = NextLevelAi.IncreasedTime;
            DidTimeChangeAfterPlayerPressedContinueOnLevel11 = true;
        }
    }
   
    
    
    // Update is called once per frame
     void Update()
     
    {

        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            if (DidPlayerPressContinueFoeLevel11)
            {
                ChangeTimeLevel11();
                BounceObjectsToDectavateForLevel11.SetActive(true);
            }
            else
            {
                BounceObjectsToDectavateForLevel11.SetActive(false);
            }
        }


      
        
        
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (DidPlayerPressContinue)
            {
                GameObjectsToDeactivateForLevel1.SetActive(true);
            }
            else
            {
                GameObjectsToDeactivateForLevel1.SetActive(false); 
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

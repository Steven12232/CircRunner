using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public TextMeshProUGUI RestartWithAdsText;
    public GameObject Rules;
    // Start is called before the first frame update
    void Start()
    {
        
    }

        
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        NextLevelAi.LevelNumber = 1;
        Time.timeScale = 1f;
    }
    
    public void ActivatePauseMenu()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1) //Checks if the scene is 1
        {
            switch (PauseMenuCanvas.activeSelf)
            {
                case true when Rules.activeSelf == false:
                    PauseMenuCanvas.SetActive(false);
                    Time.timeScale = 1;
                    break;
                case false when Rules.activeSelf == false:
                    PauseMenuCanvas.SetActive(true);
                    Time.timeScale = 0;
                    break;
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex != 1) // Checks if the scene is not 1
        {
            switch (PauseMenuCanvas.activeSelf)
            {
                case true:
                    PauseMenuCanvas.SetActive(false);
                    Time.timeScale = 1;
                    break;
                case false:
                    PauseMenuCanvas.SetActive(true);
                    Time.timeScale = 0;
                    break;
            }
        }
        
    }


    void SetRestartTextLevel()
    {
        RestartWithAdsText.text = "Restart On Level:" + NextLevelAi.LevelNumber.ToString();
        RestartWithAdsText.fontSize = 58;
    }

     void Update()
    {
        SetRestartTextLevel();
    }
}

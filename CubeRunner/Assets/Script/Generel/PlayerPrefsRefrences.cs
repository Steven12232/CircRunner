using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPrefsRefrences : MonoBehaviour
{
    public Button[] LevelButtons;
    public GameObject[] QuestionMark;
    public GameObject[] LevelNumber;
    
    
    

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        int HighestLevel = PlayerPrefs.GetInt("HighestLevel", 1);
        
        
        for (int i = 0; i < LevelButtons.Length; i++)
        {

            if (i > HighestLevel)
            {
                LevelButtons[i].interactable = false;
                QuestionMark[i].SetActive(true);
                LevelNumber[i].SetActive(false);
            }
        
       
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

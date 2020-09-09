using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject nextLevelAi;
    public GameObject RulesText;
    public GameObject ContinueButton;
    public Lives _livesRef;
    public GameObject LoseCanvas;
    
    private static bool DidInvokeForRulesHappen;
    private static bool DidInvokeHappenForPlayerSpawn;
    private static bool DidPlayerPressContinue;



    private void Awake()
    {
        
    }

    public void ContinueButtonFunction()
    {
        DidPlayerPressContinue = true;
        InvokeSetPlayerAfterDelay();
        Destroy(ContinueButton, 0.1f);
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
    
    
    
    private void DeactivateRulesWhenPlayerIsSpawned()
    {
        if (Player.activeSelf) RulesText.SetActive(false);
    }

    // Update is called once per frame
     void Update()
     
    {
        DeactivateRulesWhenPlayerIsSpawned();

        if (!_livesRef.Heart3.activeSelf)
        {
           LoseCanvas.SetActive(true);
           Player.SetActive(false);
        }
    }

     
}

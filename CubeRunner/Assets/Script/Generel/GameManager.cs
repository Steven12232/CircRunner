using System.Collections;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject nextLevelAi;
    public Text LevelText;
    public AIScript aiScriptRef;
    public Text RulesText;
    public GameObject ContinueButton;
    public Lives _livesRef;
    public GameObject LoseCanvas;
    
    private static bool DidInvokeForRulesHappen;
    private static bool DidInvokeHappenForPlayerSpawn;
    private static bool DidPlayerPressContinue;

    private GameObject[] NumberOfAiLeft;
    private GameObject[] OrigionalNumberOfAiLeft;

    private int LevelNumber;

    private void Awake()
    {
        LevelNumber = SceneManager.GetActiveScene().buildIndex;
       
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
        if (SceneManager.GetActiveScene().buildIndex == 1) Player.SetActive(false);

        if (DidInvokeForRulesHappen == false)
            RulesText.enabled = true;
        else
            RulesText.enabled = false;

        if (DidPlayerPressContinue == true)
        {
            ContinueButton.SetActive(false);
            Player.SetActive(true);
        }
        OrigionalNumberOfAiLeft = GameObject.FindGameObjectsWithTag("AI");
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


    private IEnumerator StopGameAfterDelay(float DelayTime)
    {
        yield return new WaitForSeconds(DelayTime);

        Time.timeScale = 0.0f;
    }


    
    
    private void DeactivateRulesWhenPlayerIsSpawned()
    {
        if (Player.activeSelf) RulesText.enabled = false;
    }

    // Update is called once per frame
     void Update()
    {
        LevelText.text = "Level:" + LevelNumber;
        DeactivateRulesWhenPlayerIsSpawned();
        NumberOfAiLeft = GameObject.FindGameObjectsWithTag("AI");

        if (!_livesRef.Heart3.activeSelf)
        {
           LoseCanvas.SetActive(true);
           Time.timeScale = 0f;
        }
        SetLastAiTrue();
    }

     void SetLastAiTrue()
    {
        if (NumberOfAiLeft.Length == 0)
        {
            if (nextLevelAi == null) return;
            nextLevelAi.SetActive(true);
        }
    }
}

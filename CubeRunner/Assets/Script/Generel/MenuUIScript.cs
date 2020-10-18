using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void PlayButtonStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void LevelSelect()
    {
        SceneManager.LoadScene(27);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

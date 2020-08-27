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
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Qutting App");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActivatePauseMenu()
    {
        if (PauseMenuCanvas.activeSelf == true)
        {
            PauseMenuCanvas.SetActive(false);
        }
        else if(PauseMenuCanvas.activeSelf == false)
        {
            PauseMenuCanvas.SetActive(true);

        }
      

       
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenuCanvas.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else if(PauseMenuCanvas.activeSelf == false)
        {
            Time.timeScale = 1;
        }
    }
}

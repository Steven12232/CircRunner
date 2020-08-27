using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextLevelCounter : MonoBehaviour
{
    public Text LevelText;
    private int LevelNumber;


     void Awake()
    {
        LevelNumber = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}

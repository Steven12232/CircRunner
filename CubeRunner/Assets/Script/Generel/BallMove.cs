using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMove : MonoBehaviour
{

    public GameObject MoveObject;

    private Vector2 StartPos;

    private Vector2 EndPos;

    public Vector2 Offset;

    private float Time = 1f;

    private bool isAtPosition = false;
    
    private float currentLerpTime = 0;

    private bool ResetCurretnLerpTime = false;
    
    // Start is called before the first frame update

    void ResetLerpTime()
    {
        currentLerpTime = 0;
    }
    
    void Start()
    {
        StartPos = MoveObject.transform.position;
        EndPos = StartPos + Offset;
    }

    IEnumerator WaitForTime(float Delay)
    {
        ResetCurretnLerpTime = false;
        
        yield return new WaitForSeconds(Delay);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (MoveObject.transform.position.x == EndPos.x && MoveObject.transform.position.y == EndPos.y)
        {
            isAtPosition = true;
        }
        else if (MoveObject.transform.position.x == StartPos.x && MoveObject.transform.position.y == StartPos.y)
        {
            isAtPosition = false;
        }
        
        
        
        if (isAtPosition == false)
        {
            if (ResetCurretnLerpTime == false)
            {
                ResetLerpTime();
                ResetCurretnLerpTime = true;               
                WaitForTime(0.9f);
            }
            
            currentLerpTime += UnityEngine.Time.deltaTime;
            
            if (currentLerpTime >= Time)
            {
                currentLerpTime = Time;
            }

            float perc = currentLerpTime / Time;

        
            MoveObject.transform.position = Vector2.Lerp(StartPos, EndPos, perc);
        }
        
        
                ResetLerpTime();
                ResetCurretnLerpTime = true;               
                WaitForTime(0.9f);
            }
            
            currentLerpTime += UnityEngine.Time.deltaTime;
   
            if (currentLerpTime >= Time)
            {
                currentLerpTime = Time;
            }
            
            float perc1 = currentLerpTime / Time;
            
            MoveObject.transform.position = Vector2.Lerp(EndPos, StartPos, perc1);
        }


    }
}

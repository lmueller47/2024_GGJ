using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int orbsCollected;
    public static float currentTime = 0f;
    float startingTime = 15f;
    public static bool timerOn = false;

    private void Awake()
    {
        orbsCollected = 0;
        currentTime = startingTime;
    }

    void Update()
    {
       if(timerOn)
        {
            currentTime -= 1 * Time.deltaTime;
        }

       if(currentTime < 0)
       {
            //game over or lose stats
            currentTime = 0;
            Debug.Log("Time's up!");
            timerOn = false;
       }
    }
}

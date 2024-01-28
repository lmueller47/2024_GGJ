using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int orbsCollected;
    public static float currentTime = 0f;
    float startingTime = 15f;
    public static bool timerOn = false;
    [SerializeField] private Animator anim;

    [SerializeField] Text count;
    private void Start()
    {
        orbsCollected = 0;
        currentTime = startingTime;
    }

    void Update()
    {
       if(timerOn)
        {
            currentTime -= 1 * Time.deltaTime;
            count.text = currentTime.ToString("0");
        }

       if(currentTime < 0)
       {
            //game over or lose stats
            currentTime = 0;
            Debug.Log("Time's up!");
            timerOn = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }

        if (orbsCollected < 3)
        {
            anim.SetInteger("Stage", 0);
        }
        else if (orbsCollected >= 3 && orbsCollected < 6)
        {
            anim.SetInteger("Stage", 1);
        }
        else if (orbsCollected >= 6)
        {
            anim.SetInteger("Stage", 2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [SerializeField] Image blackout;

    private void Update()
    {
        if(GameManager.orbsCollected > 0)
        {
            if (GameManager.currentTime < 5)
            {
                var tempColor = blackout.color;
                tempColor.r = 255;
                blackout.color = tempColor;
            }
            else
            {
                var tempColor = blackout.color;
                tempColor.r = 0;
                blackout.color = tempColor;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //add to game manager collectable count
            GameManager.orbsCollected++;

            if(GameManager.orbsCollected == 1)
            {
                GameManager.timerOn = true;
                Movement.speed *= 1.5f;
                Movement.jumpPower *= 1.5f;
                var tempColor = blackout.color;
                tempColor.a = 0.1f;
                blackout.color = tempColor;
            }
            else if(GameManager.orbsCollected > 1 && GameManager.orbsCollected <= 3)
            {
                //reset timer to original time
                GameManager.currentTime = 15f;

                var tempColor = blackout.color;
                tempColor.a = 0.3f;
                blackout.color = tempColor;
            }
            else if (GameManager.orbsCollected > 3 && GameManager.orbsCollected <= 5)
            {
                //reset timer to 10
                GameManager.currentTime = 10f;

                var tempColor = blackout.color;
                tempColor.a = 0.5f;
                blackout.color = tempColor;
            }
            else if (GameManager.orbsCollected > 5 && GameManager.orbsCollected <= 6)
            {
                //reset timer to 5
                GameManager.currentTime = 5f;

                var tempColor = blackout.color;
                tempColor.a = 0.7f;
                blackout.color = tempColor;
            }
            else if (GameManager.orbsCollected > 6 && GameManager.orbsCollected <= 7)
            {
                //reset timer to original time
                GameManager.currentTime = 3f;

                var tempColor = blackout.color;
                tempColor.a = 0.9f;
                blackout.color = tempColor;
            }
            else if(GameManager.orbsCollected >= 8)
            {
                //Player blacks out level is over 
                //next scene
            }

            Destroy(gameObject);
        }
    }
}

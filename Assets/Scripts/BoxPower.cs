using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPower : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerButton")
        {
            collision.gameObject.GetComponent<PowerButton>().powerOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerButton")
        {
            collision.gameObject.GetComponent<PowerButton>().powerOn = false;
        }
    }
}

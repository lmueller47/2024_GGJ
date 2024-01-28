using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    [SerializeField] float speed = 2f;

    private Vector3 nextPosition;
    private void Start()
    {
        nextPosition = endPoint.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        if(transform.position == nextPosition)
        {
            nextPosition = (nextPosition == startPoint.position) ? endPoint.position : startPoint.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            collision.gameObject.transform.parent = null;
        }

    }
}

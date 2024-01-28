using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject platform;

    public bool powerOn = false;
    [SerializeField] float speed = 2f;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = startPoint.position;
    }
    private void Update()
    {
        if(powerOn)
        {
            targetPosition = endPoint.position;
            Debug.Log("changed");
        }
        else
        {
            targetPosition = startPoint.position;
        }
    }

    private void FixedUpdate()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, speed * Time.deltaTime);
    }

}

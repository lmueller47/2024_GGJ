using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPull : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    public Vector3 offset;

    private Animator anim;

    GameObject box;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position - offset, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Box" && Input.GetKeyDown(KeyCode.E))
        {
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

            anim.SetBool("IsPulling", true);

        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;

            anim.SetBool("IsPulling", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position - offset, (Vector2)(transform.position - offset)+  Vector2.right * transform.localScale.x* distance);
    }
}

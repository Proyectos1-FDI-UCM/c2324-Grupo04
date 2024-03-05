using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Raycast : MonoBehaviour
{
    [SerializeField] float distance = 10f;

    [SerializeField] Transform _playerTransform;
    Transform _myTransform;
    RaycastHit2D hitUp;
    RaycastHit2D hitRight;
    RaycastHit2D hitDown;
    RaycastHit2D hitLeft;

    public void NewDirection()
    {

    }

    void Start()
    {
        _myTransform = transform;
    }


    void FixedUpdate()
    {
        hitUp = Physics2D.Raycast(_myTransform.position, transform.up, distance);
        hitRight = Physics2D.Raycast(_myTransform.position, transform.right, distance);
        hitDown = Physics2D.Raycast(_myTransform.position, transform.up * -1, distance);
        hitLeft = Physics2D.Raycast(_myTransform.position, transform.right * -1, distance);

        if (hitRight.collider != null)
        {
            Debug.DrawRay(transform.position, transform.right, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right, Color.red);
        }

        if (hitUp.collider != null)
        {
            Debug.DrawRay(transform.position, transform.up, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up, Color.red);
        }
        if (hitDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.red);
        }
        if (hitLeft.collider != null)
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.red);
        }
    }
}

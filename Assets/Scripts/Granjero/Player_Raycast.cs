using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Raycast : MonoBehaviour
{
    [SerializeField] float distanceDown = 1f;
    [SerializeField] float distanceSide = 1f;

    private GranjeroMovement _movimientoPlayer;
    Transform _myTransform;
    RaycastHit2D hitRight;
    RaycastHit2D hitDown;
    RaycastHit2D hitLeft;
    [SerializeField] LayerMask layerToHit;

    void Start()
    {
        _myTransform = transform;
        _movimientoPlayer = GetComponent<GranjeroMovement>();
    }


    void FixedUpdate()
    {
        hitRight = Physics2D.Raycast(_myTransform.position, transform.right, distanceSide, layerToHit);
        hitDown = Physics2D.Raycast(_myTransform.position, transform.up * -1, distanceDown, layerToHit);
        hitLeft = Physics2D.Raycast(_myTransform.position, transform.right * -1, distanceSide, layerToHit);

        if (hitRight.collider != null)
        {
            Debug.Log(hitRight.collider);
            Debug.DrawRay(transform.position, transform.right, Color.green);
            _movimientoPlayer.SetBoolRight(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right, Color.red);
            _movimientoPlayer.SetBoolRight(false);
        }

        if (hitDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.green);
            _movimientoPlayer.SetBoolDown(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.red);
            _movimientoPlayer.SetBoolDown(false);
        }
        if (hitLeft.collider != null)
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.green);
            _movimientoPlayer.SetBoolLeft(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.red);
            _movimientoPlayer.SetBoolLeft(false);
        }
    }
}

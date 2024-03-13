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
    RaycastHit2D hitRightUp;
    RaycastHit2D hitRightDown;
    RaycastHit2D hitDown;
    RaycastHit2D hitLeft;
    RaycastHit2D hitLeftUp;
    RaycastHit2D hitLeftDown;
    [SerializeField] LayerMask layerToJump;
    [SerializeField] LayerMask layerToWalls;
    public bool _allowTrampoline = false;

    void Start()
    {
        _myTransform = transform;
        _movimientoPlayer = GetComponent<GranjeroMovement>();
    }


    void FixedUpdate()
    {
        Vector2 positionUp = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Vector2 positionDown = new Vector2(transform.position.x, transform.position.y - 0.5f);
        hitRight = Physics2D.Raycast(_myTransform.position, transform.right, distanceSide, layerToWalls);
        hitRightUp = Physics2D.Raycast(positionUp, transform.right, distanceSide, layerToWalls);
        hitRightDown = Physics2D.Raycast(positionDown, transform.right, distanceSide, layerToWalls);

        hitDown = Physics2D.Raycast(_myTransform.position, transform.up * -1, distanceDown, layerToJump);

        hitLeft = Physics2D.Raycast(_myTransform.position, transform.right * -1, distanceSide, layerToWalls);
        hitLeftUp = Physics2D.Raycast(positionUp, transform.right * -1, distanceSide, layerToWalls);
        hitLeftDown = Physics2D.Raycast(positionDown, transform.right * -1, distanceSide, layerToWalls);

        if (hitRight.collider != null || hitRightUp.collider != null || hitRightDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.right, Color.green);
            Debug.DrawRay(positionUp, transform.right, Color.green);
            Debug.DrawRay(positionDown, transform.right, Color.green);
            _movimientoPlayer.SetBoolRight(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right, Color.red);
            Debug.DrawRay(positionUp, transform.right, Color.red);
            Debug.DrawRay(positionDown, transform.right, Color.red);
            _movimientoPlayer.SetBoolRight(false);
        }

        if (hitDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.green);
            _movimientoPlayer.SetBoolDown(true);
            _allowTrampoline = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.red);
            _movimientoPlayer.SetBoolDown(false);
            _allowTrampoline = true;
        }
        if (hitLeft.collider != null || hitLeftUp.collider != null || hitLeftDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.green);
            Debug.DrawRay(positionUp, transform.right * -1, Color.green);
            Debug.DrawRay(positionDown, transform.right * -1, Color.green);
            _movimientoPlayer.SetBoolLeft(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.red);
            Debug.DrawRay(positionUp, transform.right * -1, Color.red);
            Debug.DrawRay(positionDown, transform.right * -1, Color.red);
            _movimientoPlayer.SetBoolLeft(false);
        }
    }
}

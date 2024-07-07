using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Raycast : MonoBehaviour
{
    [SerializeField] float distanceDown = 1f;
    [SerializeField] float distanceSide = 1f;

    private GranjeroMovement _movimientoPlayer;
    Transform _myTransform;
    [SerializeField] LayerMask layerToJump;
    [SerializeField] LayerMask layerToWalls;
    [SerializeField] LayerMask layerToLadder;
    public bool _allowTrampoline = false;

    #region properties
    public bool choqueAbajo;
    public bool choqueIzq;
    public bool choqueDer;
    #endregion

    #region methods
    void Start()
    {
        _myTransform = transform;
        _movimientoPlayer = GetComponent<GranjeroMovement>();
    }


    void Update() // �Hay alguna raz�n para hacer esto en el FixedUpdate()? - R
    {
        // Todo esto es s�lo para depuraci�n
        Vector2 positionUp = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Vector2 positionDown = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hitRight = Physics2D.Raycast(_myTransform.position, transform.right, distanceSide, layerToWalls);
        RaycastHit2D hitRightUp = Physics2D.Raycast(positionUp, transform.right, distanceSide, layerToWalls);
        RaycastHit2D hitRightDown = Physics2D.Raycast(positionDown, transform.right, distanceSide, layerToWalls);

        RaycastHit2D hitDown = Physics2D.Raycast(_myTransform.position, transform.up * -1, distanceDown, layerToJump);
        //RaycastHit2D hitDownLadder = Physics2D.Raycast(_myTransform.position, transform.up * -1, distanceDown, layerToLadder);

        RaycastHit2D hitLeft = Physics2D.Raycast(_myTransform.position, transform.right * -1, distanceSide, layerToWalls);
        RaycastHit2D hitLeftUp = Physics2D.Raycast(positionUp, transform.right * -1, distanceSide, layerToWalls);
        RaycastHit2D hitLeftDown = Physics2D.Raycast(positionDown, transform.right * -1, distanceSide, layerToWalls);

        if (hitRight.collider != null || hitRightUp.collider != null || hitRightDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.right, Color.green);
            Debug.DrawRay(positionUp, transform.right, Color.green);
            Debug.DrawRay(positionDown, transform.right, Color.green);
            //_movimientoPlayer.SetBoolRight(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right, Color.red);
            Debug.DrawRay(positionUp, transform.right, Color.red);
            Debug.DrawRay(positionDown, transform.right, Color.red);
            //_movimientoPlayer.SetBoolRight(false);
        }

        if (hitDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.green);
            //_movimientoPlayer.SetBoolDown(true);
            _allowTrampoline = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.red);
            //_movimientoPlayer.SetBoolDown(false);
            _allowTrampoline = true;
        }

        if (hitLeft.collider != null || hitLeftUp.collider != null || hitLeftDown.collider != null)
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.green);
            Debug.DrawRay(positionUp, transform.right * -1, Color.green);
            Debug.DrawRay(positionDown, transform.right * -1, Color.green);
            //_movimientoPlayer.SetBoolLeft(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.right * -1, Color.red);
            Debug.DrawRay(positionUp, transform.right * -1, Color.red);
            Debug.DrawRay(positionDown, transform.right * -1, Color.red);
            //_movimientoPlayer.SetBoolLeft(false);
        }

        // He quitado la comprobaci�n de la escalera porque no vamos a hacer escalera
        /*
        if (hitDownLadder.collider != null)
        {
            Debug.DrawRay(transform.position, transform.up * -1, Color.yellow);
            _movimientoPlayer.SetBoolLadder(true);
        }
        else
        {
            _movimientoPlayer.SetBoolLadder(false);
        }*/
    }

    public bool ChoqueAbajo()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(_myTransform.position, transform.up * -1, distanceDown, layerToJump);
        return hitDown.collider != null;
    }

    public bool ChoqueIzq()
    {
        Vector2 positionUp = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Vector2 positionDown = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hitLeft = Physics2D.Raycast(_myTransform.position, transform.right * -1, distanceSide, layerToWalls);
        RaycastHit2D hitLeftUp = Physics2D.Raycast(positionUp, transform.right * -1, distanceSide, layerToWalls);
        RaycastHit2D hitLeftDown = Physics2D.Raycast(positionDown, transform.right * -1, distanceSide, layerToWalls);
        return hitLeft.collider != null || hitLeftUp.collider != null || hitLeftDown.collider != null;
    }

    public bool ChoqueDer()
    {
        Vector2 positionUp = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Vector2 positionDown = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hitRight = Physics2D.Raycast(_myTransform.position, transform.right, distanceSide, layerToWalls);
        RaycastHit2D hitRightUp = Physics2D.Raycast(positionUp, transform.right, distanceSide, layerToWalls);
        RaycastHit2D hitRightDown = Physics2D.Raycast(positionDown, transform.right, distanceSide, layerToWalls);
        return hitRight.collider != null || hitRightUp.collider != null || hitRightDown.collider != null;
    }


    #endregion
}

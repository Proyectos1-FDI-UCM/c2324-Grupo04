using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Raycast : MonoBehaviour
{
    [SerializeField] private float distanceDown = 1f;
    [SerializeField] private float distanceSide = 1f;

    private GranjeroMovement _movimientoPlayer;
    private Transform _transform;

    [SerializeField] private LayerMask layerToJump;
    [SerializeField] private LayerMask layerToWalls;
    [SerializeField] private LayerMask layerToLadder;

    public bool allowTrampoline = false;

    private bool _choqueAbajo;
    private bool _choqueIzq;
    private bool _choqueDer;

    public bool ChoqueAbajo
    {
        get { return _choqueAbajo; }
        private set { _choqueAbajo = value; }
    }

    public bool ChoqueIzq
    {
        get { return _choqueIzq; }
        private set { _choqueIzq = value; }
    }

    public bool ChoqueDer
    {
        get { return _choqueDer; }
        private set { _choqueDer = value; }
    }

    private void Start()
    {
        _transform = transform;
        _movimientoPlayer = GetComponent<GranjeroMovement>();
    }

    private void Update()
    {
        Vector2 positionUp = new Vector2(transform.position.x, transform.position.y + 0.5f);
        Vector2 positionDown = new Vector2(transform.position.x, transform.position.y - 0.5f);

        RaycastHit2D hitRight = Physics2D.Raycast(_transform.position, transform.right, distanceSide, layerToWalls);
        RaycastHit2D hitRightUp = Physics2D.Raycast(positionUp, transform.right, distanceSide, layerToWalls);
        RaycastHit2D hitRightDown = Physics2D.Raycast(positionDown, transform.right, distanceSide, layerToWalls);

        RaycastHit2D hitDown = Physics2D.Raycast(_transform.position, transform.up * -1, distanceDown, layerToJump);

        RaycastHit2D hitLeft = Physics2D.Raycast(_transform.position, transform.right * -1, distanceSide, layerToWalls);
        RaycastHit2D hitLeftUp = Physics2D.Raycast(positionUp, transform.right * -1, distanceSide, layerToWalls);
        RaycastHit2D hitLeftDown = Physics2D.Raycast(positionDown, transform.right * -1, distanceSide, layerToWalls);

        ChoqueAbajo = hitDown.collider != null;
        ChoqueIzq = !(hitLeft.collider == null && hitLeftUp.collider == null && hitLeftDown.collider == null);
        ChoqueDer = !(hitRight.collider == null && hitRightUp.collider == null && hitRightDown.collider == null);

        allowTrampoline = !ChoqueAbajo;
    }

    public bool CheckChoqueAbajo()
    {
        return ChoqueAbajo;
    }

    public bool CheckChoqueIzq()
    {
        return ChoqueIzq;
    }

    public bool CheckChoqueDer()
    {
        return ChoqueDer;
    }
}

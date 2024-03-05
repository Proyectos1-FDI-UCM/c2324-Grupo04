using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetector : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private bool up;
    [SerializeField] private bool left;
    [SerializeField] private bool right;

    private GranjeroMovement _movimientoPlayer;
    void OnCollisionStay2D()
    {
        if (up)
        {
            _movimientoPlayer.SetBoolUp(true);
        }
        if (left)
        {
            _movimientoPlayer.SetBoolLeft(true);
        }
        if (right)
        {
            _movimientoPlayer.SetBoolRight(true);
        }
    }
    void OnCollisionExit2D()
    {
        if (up)
        {
            _movimientoPlayer.SetBoolUp(false);
        }
        if (left)
        {
            _movimientoPlayer.SetBoolLeft(false);
        }
        if (right)
        {
            _movimientoPlayer.SetBoolRight(false);
        }
    }
    void start
    {
        _movimientoPlayer = _player.GetComponent<GranjeroMovement>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvejaBalido : MonoBehaviour
{
    private Transform _myTransform;
    private bool playerDetected = false;
    public Transform _granjero;

    [SerializeField]
    private float AreaDetecX;
    [SerializeField]
    private float AreaDetecY;

    private float xDistance;
    private float yDistance;

    [SerializeField]
    private float tiempoPrimerBalido;
    private float tiempoRNDBalido;
    private float _tiempoBalido;
    private bool ovejaBalido = false;
    System.Random rnd = new System.Random();


    private void DetectarPlayer()
    {
        if (playerDetected) { playerDetected = false; }
        xDistance = Math.Abs(_granjero.position.x - transform.position.x);
        yDistance = Math.Abs(_granjero.position.y - transform.position.y);
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            playerDetected = true;
        }
    }

    private void Balar()
    {
        if (playerDetected && ovejaBalido)
        {
            //Script para sonido
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _granjero = GameManager.Instance.ReferenciaTransformGranjero();
        _tiempoBalido = 0;
        tiempoRNDBalido = rnd.Next(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        DetectarPlayer();
        if (GameManager.Instance.cargandoOveja)
        {
            _tiempoBalido = 0;
            ovejaBalido = false;
        }
        else
        {
            _tiempoBalido += Time.deltaTime;
        }

        if (_tiempoBalido > tiempoPrimerBalido)
        {
            ovejaBalido = true;
        }

        if (ovejaBalido)
        {
            if (_tiempoBalido > tiempoRNDBalido)
            {
                Balar();
                tiempoRNDBalido = rnd.Next(5, 10);
                _tiempoBalido = 0;
            }
        }
    }
}

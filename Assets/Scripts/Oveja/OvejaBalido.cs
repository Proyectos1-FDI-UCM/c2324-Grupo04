using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvejaBalido : MonoBehaviour
{
    private Transform _myTransform;
    private bool playerDetected = false;
    public Transform _granjero;
    [SerializeField] private AudioSource _balido1;
    [SerializeField] private AudioSource _balido2;
    [SerializeField] private AudioSource _balido3;
    private int _balido = 0;


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
    [SerializeField]
    private int rnd1;
    [SerializeField]
    private int rnd2;


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
            _balido = rnd.Next(0,100);
            if (_balido > 60) { _balido1.Play(); }
            else if (_balido < 40) { _balido2.Play(); }
            else { _balido3.Play(); }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _granjero = GameManager.Instance.ReferenciaTransformGranjero();
        _tiempoBalido = 0;
        tiempoRNDBalido = rnd.Next(rnd1, rnd2);
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
            Balar();
        }

        if (ovejaBalido)
        {
            if (_tiempoBalido > tiempoRNDBalido)
            {
                Balar();
                tiempoRNDBalido = rnd.Next(rnd1, rnd2);
                _tiempoBalido = 0;
            }
        }
    }
}

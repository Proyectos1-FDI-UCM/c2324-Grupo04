using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SensorEnem : MonoBehaviour
{
    private Transform _myTransform;
    public bool playerDetected = false;
    public GameObject granjero;
    public bool ovejaDetected = false;
    public GameObject oveja;
    public bool señueloDetected = false;
    public GameObject señuelo;

    [SerializeField]
    private float AreaDetecX;
    [SerializeField]
    private float AreaDetecY;

    private float xDistance;
    private float yDistance;

    public void seguirPlayer(ref int cambioDirec)
    {
        if (granjero.transform.position.x - transform.position.x < -0.3)
        {
            cambioDirec = -1;
        }
        else if (granjero.transform.position.x - transform.position.x > 0.3)
        {
            cambioDirec = 1;
        }
        else { cambioDirec = 0; }
    }

    public void seguirOveja(ref int cambioDirec)
    {
        if (oveja.transform.position.x - transform.position.x < -0.3)
        {
            cambioDirec = -1;
        }
        else if (oveja.transform.position.x - transform.position.x > 0.3)
        {
            cambioDirec = 1;
        }
        else { cambioDirec = 0; }
    }

    public void seguirSeñuelo(ref int cambioDirec)
    {
        if (señuelo.transform.position.x - transform.position.x < -0.3)
        {
            cambioDirec = -1;
        }
        else if (señuelo.transform.position.x - transform.position.x > 0.3)
        {
            cambioDirec = 1;
        }
        else { cambioDirec = 0; }
    }

    void Start()
    {
        _myTransform = transform;
    }

    void Update()
    {
        if (playerDetected) { playerDetected = false; }
        xDistance = Math.Abs(granjero.transform.position.x - transform.position.x);
        yDistance = Math.Abs(granjero.transform.position.y - transform.position.y);
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            playerDetected = true;
        }

        if (ovejaDetected) { ovejaDetected = false; }
        if (GameManager.Instance.cargandoOveja) { }
        else
        {
            xDistance = Math.Abs(oveja.transform.position.x - transform.position.x);
            yDistance = Math.Abs(oveja.transform.position.y - transform.position.y);
        }
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            ovejaDetected = true;
        }

        if (señueloDetected) { señueloDetected = false; }
        xDistance = Math.Abs(señuelo.transform.position.x - transform.position.x);
        yDistance = Math.Abs(señuelo.transform.position.y - transform.position.y);
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            señueloDetected = true;
        }
    }
}

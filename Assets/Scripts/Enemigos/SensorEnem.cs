using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SensorEnem : MonoBehaviour
{
    private Transform _myTransform;
    public bool playerDetected = false;
    public GameObject granjero;
    public bool ovejaDetected = false;
    public GameObject oveja;
    public bool se�ueloDetected = false;
    private Vector3 _se�ueloTransform;

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

    public void seguirSe�uelo(ref int cambioDirec)
    {
        if (_se�ueloTransform.x - transform.position.x < -0.3)
        {
            cambioDirec = -1;
        }
        else if (_se�ueloTransform.x - transform.position.x > 0.3)
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
        if (GameManager.Instance.se�ueloExist)
        {
            _se�ueloTransform = GameManager.Instance.Se�ueloPosition();
        }
        else
        {
            _se�ueloTransform = new Vector3 (-20, 0, 0);
        }

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

        if (se�ueloDetected) { se�ueloDetected = false; }
        xDistance = Math.Abs(_se�ueloTransform.x - transform.position.x);
        yDistance = Math.Abs(_se�ueloTransform.y - transform.position.y);
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            se�ueloDetected = true;
        }
    }
}

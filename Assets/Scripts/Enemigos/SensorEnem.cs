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
    public bool se�ueloDetected = false;
    public GameObject se�uelo;

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
        if (se�uelo.transform.position.x - transform.position.x < -0.3)
        {
            cambioDirec = -1;
        }
        else if (se�uelo.transform.position.x - transform.position.x > 0.3)
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
        xDistance = Math.Abs(oveja.transform.position.x - transform.position.x);
        yDistance = Math.Abs(oveja.transform.position.y - transform.position.y);
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            ovejaDetected = true;
        }

        if (se�ueloDetected) { se�ueloDetected = false; }
        xDistance = Math.Abs(se�uelo.transform.position.x - transform.position.x);
        yDistance = Math.Abs(se�uelo.transform.position.y - transform.position.y);
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            se�ueloDetected = true;
        }
    }
}

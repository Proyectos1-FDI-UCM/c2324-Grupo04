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

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected) { playerDetected = false; }
        xDistance = Math.Abs(granjero.transform.position.x - transform.position.x);
        yDistance = Math.Abs(granjero.transform.position.y - transform.position.y);
        if (xDistance < AreaDetecX && yDistance < AreaDetecY)
        {
            playerDetected = true;
        }
       
    }
}

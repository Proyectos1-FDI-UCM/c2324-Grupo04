using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranjeroAnimation : MonoBehaviour
{



    private Transform _myTransform;
    private bool miraDer = true;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }



    public void Gira(float dir)
    {        
        if (miraDer && dir > 0)
        {
            print("Giro izq");
            _myTransform.localScale = Vector3.one;
            miraDer = false;
        }
        else if (!miraDer && dir < 0)
        {
            print("Giro der");
            _myTransform.localScale = new Vector3(-1, 1, 1);
            miraDer = true;
        }
    }


}

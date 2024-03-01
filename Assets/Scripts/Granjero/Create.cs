using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    [SerializeField]
    private GameObject Trampoline;
    private Transform _myTransform;

    [SerializeField]
    private float _tacoste = 0;
    [SerializeField]
    private float _secoste = 0;


    private void OnAction2()
    {

        if (GameManager.Instance.ObtenerCuerdas() >= _tacoste)
        {
            GameObject trampolin = Instantiate(Trampoline, _myTransform.position , Quaternion.identity);
            print(trampolin);
            Debug.Log("Trampolin");
        }
    }

    private void Start()
    {
        _myTransform = transform;
    }

}

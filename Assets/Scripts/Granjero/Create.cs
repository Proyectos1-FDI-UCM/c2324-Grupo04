using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    [SerializeField]
    private GameObject Trampoline;
    private Transform _myTransform;
    private void OnAction2()
    {
        GameObject trampolin = Instantiate(Trampoline, _myTransform.position, Quaternion.identity);
        print(trampolin);
    }
    private void Start()
    {
        _myTransform = transform;
    }

}

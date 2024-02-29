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
        if (GameManager.Instance.ObtenerCuerdas() >= 5)
        {
            ConstruirTrampolin();
        }
    }

    private void ConstruirTrampolin()
    {
        GameObject trampolin = Instantiate(Trampoline, _myTransform.position, Quaternion.identity);
        Debug.Log("Trampolín construido!");
    }
}
    private void Start()
    {
        _myTransform = transform;
    }

}

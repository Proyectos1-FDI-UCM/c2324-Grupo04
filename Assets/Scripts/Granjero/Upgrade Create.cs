using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Create : MonoBehaviour
{
    [SerializeField]
    private GameObject Trampoline;
    [SerializeField]
    private GameObject senueloPrefab;
    private Transform _myTransform;
    private void OnAction2()
    {
        if (GameManager.Instance.ObtenerCuerdas() >= 5)
        {
            ConstruirTrampolin();
        }
    }
    private void OnAction4()
    {
        if (GameManager.Instance.ObtenerCuerdas() >= 8)
        {
            ConstruirSenuelo();
        }
    }

    private void ConstruirTrampolin()
    {
        GameObject trampolin = Instantiate(Trampoline, _myTransform.position, Quaternion.identity);
        Debug.Log("Trampolín construido!");
    }
    private void ConstruirSenuelo()
    {
        GameObject senuelo = Instantiate(senueloPrefab, _myTransform.position, Quaternion.identity);
        Debug.Log("Señuelo construido!");
    }
    private void Start()
    {
    _myTransform = transform;
    }
}

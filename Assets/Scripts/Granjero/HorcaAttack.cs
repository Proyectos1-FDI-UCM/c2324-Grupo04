using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorcaAttack : MonoBehaviour
{
    [SerializeField] private float _hitboxDuration = 0.4f;
    [SerializeField] private GameObject _hitboxPrefab;
    [SerializeField] private float _horizontalOffset = 0.4f;
    private Transform _myTransform;
    private GranjeroMovement _myGranjeroMovement;

    void OnAction1()
    {                                                                          // Idealmente este vector director lo controla el GranjeroMovement
        GameObject hitbox = Instantiate(_hitboxPrefab, _myTransform.position + Vector3.right * _horizontalOffset, _myTransform.rotation);
        Destroy(hitbox, _hitboxDuration);
        Debug.Log("Ataca");
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myGranjeroMovement = GetComponent<GranjeroMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

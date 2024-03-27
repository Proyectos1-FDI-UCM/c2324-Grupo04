using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//fijarme en el vector de movimiento del enemymov
//añadir exclmacion
public class LoboAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] Transform _transform;
    private LoboMov controller;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = transform;
        controller = GetComponent<LoboMov>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loboizq(bool lobdcha)
    {
        _animator.SetBool("lobdcha", lobdcha = false);
    }

    public void Loboder(bool lobdcha)
    {
        _animator.SetBool("lobdcha", lobdcha = true);
    }

    public void Loboquietoi()
    {

    }
    public void Loboquietod()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//fijarme en el vector de movimiento del enemymov
//añadir exclmacion
public class LoboAnimation : MonoBehaviour
{

    public GameObject limit1;
    public GameObject limit2;

    [SerializeField] private Animator _animator;
    [SerializeField] Transform _transform;
    private LoboMov controller;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = transform;
        controller = GetComponent<LoboMov>();//no se muy bien para que se necesita el lobo movement??
        _animator.SetBool("lobdcha", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform == limit1)
        {

        }
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

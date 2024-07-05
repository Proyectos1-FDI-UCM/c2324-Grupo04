using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//fijarme en el vector de movimiento del enemymov
//añadir exclmacion
public class LoboAnimation : MonoBehaviour
{
    #region references
    public GameObject limit1;
    public GameObject limit2;

    [SerializeField]
    private Material _flashMaterial;
    private Material _originalMaterial;
    private SpriteRenderer _mySR;


    [SerializeField]
    private Animator _animator;
    [SerializeField]
    Transform _transform;
    private LoboMov controller;
    #endregion

    #region parameters
    [SerializeField]
    private float _flashTime = 0.8f; // Tiempo que se queda blanco tras recibir daño
    [SerializeField]
    private float _flashInterval = 0.1f; // Tiempo entre apagado y encendido
    #endregion

    #region variables
    private float _timeFlashing = 0f;
    #endregion


    #region methods
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = transform;
        controller = GetComponent<LoboMov>();//no se muy bien para que se necesita el lobo movement??
        _animator.SetBool("lobdcha", false);
        _mySR = GetComponent<SpriteRenderer>();
        _originalMaterial = _mySR.material;
    }

    public void Loboizq(bool lobdcha)
    {
        _animator.SetBool("lobdcha", lobdcha = false);
    }

    public void Loboder(bool lobdcha)
    {
        _animator.SetBool("lobdcha", lobdcha = true);
    }

    public void DamageAnimation() // Activa la animación de recibir daño (poner el sprite blanco)
    {
        if (_timeFlashing >= _flashTime)
        {
            _timeFlashing = 0;
        }
        else
        {
            _timeFlashing += _flashInterval * 2;
            FlashBegin();
        }
    }

    private void FlashBegin() // Método auxiliar que desactiva la animación de recibir daño
    {
        _mySR.material = _flashMaterial;

        Invoke("FlashEnd", _flashInterval);
    }

    private void FlashEnd() // Método auxiliar que desactiva la animación de recibir daño
    {
        _mySR.material = _originalMaterial;
        Invoke("DamageAnimation", _flashInterval);
    }
    #endregion
}

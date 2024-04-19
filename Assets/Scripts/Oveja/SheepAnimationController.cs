using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimationController : MonoBehaviour
{
    #region references
    [SerializeField]
    private Material _flashMaterial;
    private Material _originalMaterial;
    private SpriteRenderer _mySR;
    private Animator _myAnimator;
    private MovimientoOveja _myMov;
    private Rigidbody2D _myRB;
    //private Animation _anim; // Definitivamente no sé qué estoy haciendo - R
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
    // Start is called before the first frame update
    void Start()
    {
        _mySR = GetComponent<SpriteRenderer>();
        _originalMaterial = _mySR.material;
        _myAnimator = GetComponent<Animator>();
        _myMov = GetComponent<MovimientoOveja>();
        _myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(_myRB.velocity.x) > 0)
        {
            _myAnimator.SetBool("IsWalking", true);
        }
        else
        {
            _myAnimator.SetBool("IsWalking", false);
        }
    }
}

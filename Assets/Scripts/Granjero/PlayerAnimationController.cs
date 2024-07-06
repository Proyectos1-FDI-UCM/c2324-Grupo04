using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    private Animator _myAnimator;
    private Rigidbody2D _myRB;
    #endregion


    #region parameters
    [SerializeField]
    private float _attackTime = 0.1f; // Tiempo que dura la animación de ataque
    #endregion


    #region variables
    private bool miraDer = true;
    private float epsil = 0.1f;
    private int estado = 0;
    private float _tiempo = 0f;
    #endregion



    #region methods

    void Start()
    {
        _myTransform = transform;
        _myAnimator = GetComponent<Animator>();
        _myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (estado == 3)
        {
            _tiempo += Time.deltaTime;
            if (_tiempo >= _attackTime)
            {
                _tiempo = 0f;
                estado = 0;
            }
        }
        else
        {
            if (Mathf.Abs(_myRB.velocity.x) >= epsil)
            {
                _myAnimator.SetInteger("EstadoAnimacion", 1);
            }
            else
            {
                _myAnimator.SetInteger("EstadoAnimacion", 0);
            }
        }
    }
    
    public void Gira(float dir)
    {        
        if (miraDer && dir > 0)
        {
            _myTransform.localScale = Vector3.one;
            miraDer = false;
        }
        else if (!miraDer && dir < 0)
        {
            _myTransform.localScale = new Vector3(-1, 1, 1);
            miraDer = true;
        }
        Anda();
    }

    private void Anda()
    {
        if (estado < 1) // Tal como está ahora la prioridad en animación es ataque > salto > caminar
        {
            estado = 1;
            _myAnimator.SetInteger("EstadoAnimacion", estado);
        }
    }

    public void Ataca()
    {
        if (estado < 3)
        {
            estado = 3;
            _myAnimator.SetInteger("EstadoAnimacion", 3);
        }
    }

    public void SueltaObjeto()
    {
        print("Suelta objeto (animación)");
    }

    public void OvejaSoltada()
    {
        _myAnimator.SetBool("LlevandoOveja", false);
    }

    public void OvejaRecogida()
    {
        _myAnimator.SetBool("LlevandoOveja", true);
    }

    public void Salta()
    {

    }
    #endregion



    #region leyenda 
    /// En principio ordenados por prioridad
    /// 0 -> Quieto (Idle)
    /// 1 -> Andando
    /// 2 -> Salto
    /// 3 -> Ataque
    /// 4 -> Suelta objeto
    #endregion
}

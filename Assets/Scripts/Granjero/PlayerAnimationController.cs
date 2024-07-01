using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region references
    private Transform _Transform;
    private Animator _Animator;
    private GranjeroMovement _Movement;
    private Rigidbody2D _RB;
    //private Animation _anim; // Definitivamente no sé qué estoy haciendo - R
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
        _Transform = transform;
        _Animator = GetComponent<Animator>();
        _Movement = GetComponent<GranjeroMovement>();
        _RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (saltando)
        //{
        //    saltando = Mathf.Abs(_myMovement.Movement().y) > epsil;
        //}
        // El modelo actual no utili
        if (estado == 3)
        {
            print("Atacando (anim)");
            _tiempo += Time.deltaTime;
            if (_tiempo >= _attackTime)
            {
                _tiempo = 0f;
                estado = 0; //Innecesario, no?
            }
        }
        else
        {
            if (Mathf.Abs(_myRB.velocity.x) >= epsil)
            {
                _Animator.SetInteger("EstadoAnimacion", 1);
                //print("Está andando");
            }
            else
            {
                _Animator.SetInteger("EstadoAnimacion", 0);
                //print("No está andando");
            }
        }
    }

    public void Quieto()
    {
        print("Quieto (animación)");
        _Animator.SetInteger("EstadoAnimacion", 0);
    }
    
    public void Gira(float dir)
    {        
        if (miraDer && dir > 0)
        {
            //print("Giro izq");
            _Transform.localScale = Vector3.one;
            miraDer = false;
        }
        else if (!miraDer && dir < 0)
        {
            //print("Giro der");
            _Transform.localScale = new Vector3(-1, 1, 1);
            miraDer = true;
        }
        Anda();
    }

    private void Anda()
    {
        if (estado < 1) // Tal como está ahora la prioridad en animación es ataque > salto > caminar
        {
            estado = 1;
            _Animator.SetInteger("EstadoAnimacion", estado);
        }
    }

    public void Ataca()
    {
        //print("Ataca (animación)");
        if (estado < 3)
        {
            estado = 3;
            _Animator.SetInteger("EstadoAnimacion", 3);
        }
    }

    public void SueltaObjeto()
    {
        print("Suelta objeto (animación)");
    }

    public void OvejaSoltada()
    {
        _Animator.SetBool("LlevandoOveja", false);
    }

    public void OvejaRecogida()
    {
        _Animator.SetBool("LlevandoOveja", true);
    }

    public void Salta()
    {
        //print("Salta (animación)");
        //if (estado < 2)
        //{
        //    estado = 2;
        //    _myAnimator.SetInteger("EstadoAnimacion", estado);
        //}
    }
    #endregion


    //#region enums
    //public enum Estado // Quizá lo use más tarde por claridad y por solidez, pero de momento tiramos con un código numérico (ni siquiera sé si se puede usar un tipo propio en el animator) - R
    //{
    //    Quieto,
    //    Andando,
    //    Atacando
    //}
    //#endregion


    #region leyenda 
    /// En principio ordenados por prioridad
    /// 0 -> Quieto (Idle)
    /// 1 -> Andando
    /// 2 -> Salto
    /// 3 -> Ataque
    /// 4 -> Suelta objeto
    #endregion


    #region plantillas
    // _anim.CrossFade(state, transitionTime, animationLayer);
    // transitionTime = 0
    // animationLayer = 0
    // _anim.CrossFade("Andar", 0, 0)
    #endregion

}

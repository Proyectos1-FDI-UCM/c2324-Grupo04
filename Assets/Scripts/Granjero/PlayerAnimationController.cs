using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    private Animator _myAnimator;
    private GranjeroMovement _myMovement;
    private Rigidbody2D _myRB;
    //private Animation _anim; // Definitivamente no sé qué estoy haciendo - R
    #endregion


    #region parameters
    [SerializeField] private float _tiempoAtaque = 1f;
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
        _myMovement = GetComponent<GranjeroMovement>();
        _myRB = GetComponent<Rigidbody2D>();
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
            if (_tiempo >= _tiempoAtaque)
            {
                _tiempo = 0f;
                estado = 0; //Innecesario, no?
            }
        }
        else
        {
            if (Mathf.Abs(_myRB.velocity.x) >= epsil)
            {
                _myAnimator.SetInteger("EstadoAnimacion", 1);
                //print("Está andando");
            }
            else
            {
                _myAnimator.SetInteger("EstadoAnimacion", 0);
                //print("No está andando");
            }
        }
    }

    public void Quieto()
    {
        print("Quieto (animación)");
        _myAnimator.SetInteger("EstadoAnimacion", 0);
    }
    
    public void Gira(float dir)
    {        
        if (miraDer && dir > 0)
        {
            //print("Giro izq");
            _myTransform.localScale = Vector3.one;
            miraDer = false;
        }
        else if (!miraDer && dir < 0)
        {
            //print("Giro der");
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
        //print("Ataca (animación)");
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
        //print("Salta (animación)");
        //if (estado < 2)
        //{
        //    estado = 2;
        //    _myAnimator.SetInteger("EstadoAnimacion", estado);
        //}
    }

    public void DamageAnimation()
    {
        print("Parapadea (animación)");
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

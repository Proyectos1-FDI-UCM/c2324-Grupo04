using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HeartIcons;

public class Healthbar : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _prefabCorazon;

    private HeartIcon[] _corazones;

    private Transform _myTransform;

    [SerializeField]
    private HealthComponent _vidaRepresentada;
    #endregion

    #region properties

    #endregion

    #region variables

    [SerializeField]
    private int _maxCorazones = 4;

    [SerializeField]
    private float _initialOffset = 1;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _corazones = new HeartIcon[_maxCorazones];
        for (int i = 0; i < 4; i++)
        {
            _corazones[i] = Instantiate(_prefabCorazon, _myTransform.position + Vector3.right * (i + _initialOffset), _myTransform.rotation, _myTransform).GetComponent<HeartIcon>();
            //_corazones[i].Inicializacion();
        }
        ActualizaEstados();
    }

    public void ActualizaEstados()
    {
        int currentHealth = _vidaRepresentada.CurrentHealth();
        int maxHealth = _vidaRepresentada.MaxHealth();
        //int currentHealth = Mathf.Clamp(_vidaRepresentada.CurrentHealth(), 0, _maxCorazones);
        //int maxHealth = Mathf.Clamp(_vidaRepresentada.MaxHealth(), 0, _maxCorazones);
        //Debug.Log("Vida: " + currentHealth + " vida máxima: " + maxHealth);

        int corazonesDibujados = currentHealth / 2;
        bool medioCorazon = currentHealth % 2 == 1;

        for (int i = 0; i < corazonesDibujados; i++) // Dibuja todos los corazones enteros
        {
            //Debug.Log("Entro en el bucle 1: " + i);
            _corazones[i].Entero();
        }
        if (medioCorazon)
        {
            _corazones[corazonesDibujados].Medio();
            corazonesDibujados++;
            //Debug.Log("Llevo " + corazonesDibujados + " corazones dibujados");
            //Debug.Log("La vida máxima es " + maxHealth);
        }
        //for (int i = corazonesDibujados; i < maxHealth; i++) // Fuera del rango?
        //{
        //    //Debug.Log("Entro en el bucle 2: " + i);
        //    _corazones[i].Vacio();
        //}
        //for (int i = maxHealth; i < _corazones.Length; i++)
        //{
        //    //Debug.Log("Entro en el bucle 3: " + i);
        //    _corazones[i].Desactivado();
        //}

        //// VERSIÓN CON CORAZONES ENTEROS
        //for (int i = 0; i < currentHealth; i++)
        //{
        //    Debug.Log("Entro en el bucle 1: " + i);
        //    _corazones[i].Entero();
        //}
        //for (int i = currentHealth; i < maxHealth; i++)
        //{
        //    Debug.Log("Entro en el bucle 2: " + i);
        //    _corazones[i].Vacio();
        //}
        //for (int i = maxHealth; i < _corazones.Length; i++)
        //{
        //    Debug.Log("Entro en el bucle 3: " + i);
        //    _corazones[i].Desactivado();
        //}
        //for (int i = currentHealth; i < 4 && i < maxHealth; i++)
        //{
        //    _corazones[i].Vacio();
        //}
    }

    public void Mueve(Vector3 desplazamiento)
    {
        _myTransform.position = _myTransform.position + desplazamiento;
    }

    void Update()
    {
        //HERRAMIENTAS DE DEPURACIÓN

        ActualizaEstados();

        //if (Input.GetKeyDown("up"))
        //{
        //    GameObject.Find("Granjero").GetComponent<HealthComponent>().ChangeMaxHealth(1);
        //    print("vida máxima aumentada");
        //    ActualizaEstados();
        //}
        //else if (Input.GetKeyDown("down"))
        //{
        //    print("down arrow key is held down");
        //}
        //else if (Input.GetKeyDown("v"))
        //{
        //    print("la vida es " + _vidaRepresentada.CurrentHealth());
        //}
        //else if (Input.GetKeyDown("b"))
        //{
        //    print("bajando la vida");
        //    if (_vidaRepresentada.gameObject.GetComponent<HealthComponent>() != null)
        //    {
        //        print("Se ha cogido bien el HC");
        //    }
        //    _vidaRepresentada.gameObject.GetComponent<HealthComponent>().ChangeHealth(-1);
        //}
    }

}

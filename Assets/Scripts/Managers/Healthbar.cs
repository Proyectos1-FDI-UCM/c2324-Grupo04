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
        int maxHealth = _vidaRepresentada.MaxHealth() / 2; // Precisión par en este parámetro
        //int currentHealth = Mathf.Clamp(_vidaRepresentada.CurrentHealth(), 0, _maxCorazones);
        //int maxHealth = Mathf.Clamp(_vidaRepresentada.MaxHealth(), 0, _maxCorazones);

        int corazonesDibujados = currentHealth / 2;
        bool medioCorazon = currentHealth % 2 == 1;

        for (int i = 0; i < corazonesDibujados; i++) // Dibuja todos los corazones enteros
        {
            _corazones[i].Entero();
        }
        if (medioCorazon)
        {
            _corazones[corazonesDibujados].Medio();
            corazonesDibujados++;
        }
        for (int i = corazonesDibujados; i < maxHealth; i++)
        {
            _corazones[i].Vacio();
        }
        for (int i = maxHealth; i < _corazones.Length; i++)
        {
            _corazones[i].Desactivado();
        }
    }

    public void Mueve(Vector3 desplazamiento)
    {
        _myTransform.position = _myTransform.position + desplazamiento;
    }

    void Update()
    {
        ActualizaEstados();
    }

}

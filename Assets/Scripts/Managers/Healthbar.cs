using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _corazones = new HeartIcon[4];
        for (int i = 0; i < 4; i++)
        {
            _corazones[i] = Instantiate(_prefabCorazon, _myTransform.position + Vector3.right * i, _myTransform.rotation, _myTransform).GetComponent<HeartIcon>();
            //_corazones[i].Inicializacion();
        }
        ActualizaEstados();
    }

    public void ActualizaEstados()
    {
        int currentHealth = _vidaRepresentada.CurrentHealth();
        int maxHealth = _vidaRepresentada.MaxHealth();
        Debug.Log("Vida: " +  currentHealth + " vida máxima: " +  maxHealth);

        for (int i = 0; i < currentHealth; i++)
        {
            Debug.Log("Entro en el bucle");
            _corazones[i].Entero();
        }
        //for (int i = currentHealth; i < 4 && i < maxHealth; i++)
        //{
        //    _corazones[i].Vacio();
        //}
    }

}

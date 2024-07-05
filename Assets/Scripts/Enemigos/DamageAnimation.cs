using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAnimation : MonoBehaviour
{
    #region references
    [SerializeField]
    private Material _flashMaterial;
    private Material _originalMaterial;
    private SpriteRenderer _mySR;
    #endregion

    #region parameters
    [SerializeField]
    private float _flashTime = 1.2f; // Tiempo que se queda blanco tras recibir daño
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
        _mySR = GetComponent<SpriteRenderer>();
        _originalMaterial = _mySR.material;
    }

    public void Damage() // Activa la animación de recibir daño (poner el sprite blanco)
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

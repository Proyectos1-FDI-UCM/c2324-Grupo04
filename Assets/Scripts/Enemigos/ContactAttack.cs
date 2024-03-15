using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttack : MonoBehaviour
{
    private Transform _myTransform;
    private HealthComponent _healthComponent;
    [SerializeField] private float invulnerabilidad;
    private float _invulnerabilidadGranjero;
    private float _invulnerabilidadOveja;
    private float _invulnerabilidadSe�uelo;

    [SerializeField] private int damage = -1;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if ((collision.gameObject.GetComponent<GranjeroMovement>() != null )||( collision.gameObject.GetComponent<OvejaInteraction>() != null)|| (collision.gameObject.GetComponent<Se�uelo>() != null))
        {
            if (_invulnerabilidadGranjero > invulnerabilidad && collision.gameObject.GetComponent<GranjeroMovement>() != null)
            {
                _invulnerabilidadGranjero = 0;
                collision.gameObject.GetComponent<HealthComponent>().ChangeHealth(damage);
            }
            if (_invulnerabilidadOveja > invulnerabilidad && collision.gameObject.GetComponent<OvejaInteraction>() != null)
            {
                _invulnerabilidadOveja = 0;
                collision.gameObject.GetComponent<HealthComponent>().ChangeHealth(damage);
            }
            if (_invulnerabilidadSe�uelo > invulnerabilidad && collision.gameObject.GetComponent<Se�uelo>() != null)
            {
                _invulnerabilidadSe�uelo = 0;
                collision.gameObject.GetComponent<HealthComponent>().ChangeHealth(damage);
            }

            Debug.Log("Colisi�n con el granjero o con la oveja");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _invulnerabilidadGranjero = 0;
        _invulnerabilidadOveja = 0;
        _invulnerabilidadSe�uelo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _invulnerabilidadGranjero += Time.deltaTime;
        _invulnerabilidadOveja += Time.deltaTime;
        _invulnerabilidadSe�uelo += Time.deltaTime;
    }
}

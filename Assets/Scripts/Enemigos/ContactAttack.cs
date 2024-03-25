using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttack : MonoBehaviour
{
    private Transform _myTransform;
    private HealthComponent _healthComponent;

    [SerializeField] private int damage = -1;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if ((collision.gameObject.GetComponent<GranjeroMovement>() != null )||( collision.gameObject.GetComponent<OvejaInteraction>() != null)|| (collision.gameObject.GetComponent<Señuelo>() != null))
        {
            collision.gameObject.GetComponent<HealthComponent>().ChangeHealth(damage);
            Debug.Log("Colisión con el granjero o con la oveja");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

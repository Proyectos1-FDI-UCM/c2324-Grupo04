using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnem : MonoBehaviour
{
    private Transform _myTransform;
    private HealthComponent _healthComponent;
    public GameObject player;

    [SerializeField] private int damage = -1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.GetComponent<GranjeroMovement>() != null)
        {
            player.GetComponent<HealthComponent>().ChangeHealth(damage);
            Debug.Log("Collision Granjero");
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

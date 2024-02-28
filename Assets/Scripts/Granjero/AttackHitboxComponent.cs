using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitboxComponent : MonoBehaviour
{
    #region parameters
    //[SerializeField] float _duration; // En principio es el HorcaAttack el que destruye este objeto
    [SerializeField] int _damage; // HA DE SER UN N�MERO NEGATIVO
    #endregion

    #region variables
    //float _timePassed = 0f;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other) // No s� por qu� no entra en este m�todo
    {
        Debug.Log("Entra en el trigger");
        EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            Debug.Log("Colisionado con un enemigo");
            other.GetComponent<HealthComponent>().ChangeHealth(_damage);
        }
    }

    

    /*void Update() // En principio es el HorcaAttack el que destruye este objeto
    {
        if (_duration <= 0)
        {
            Destroy(this.GameObject)
        }

        _duration -= Time.deltaTime;
    }*/
}

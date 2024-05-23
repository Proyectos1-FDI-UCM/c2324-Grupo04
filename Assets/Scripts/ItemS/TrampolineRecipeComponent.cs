using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineRecipeComponent : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) // Se activa cuando algo colisiona con él
    {
        Create _create = collision.GetComponent<Create>(); // Busca un componente del tipo Create

        if (_create != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
        {
            UIManager.Instance.TrampolineRecipePickedUp();
            _create.ActivateTrampoline();
            Destroy(gameObject);
        }
    }
}

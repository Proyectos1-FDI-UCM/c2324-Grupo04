using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca_Interaction : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public bool palancaActiva = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<GranjeroMovement>() != null)
        {
            if (palancaActiva)
            {
                _spriteRenderer.flipX = false;
                palancaActiva = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
                palancaActiva = true;
            }
        }
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}

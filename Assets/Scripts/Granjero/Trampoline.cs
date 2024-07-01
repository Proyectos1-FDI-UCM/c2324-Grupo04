using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 40f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GranjeroMovement granjeroMovement = collision.gameObject.GetComponent<GranjeroMovement>();
        Player_Raycast playerRaycast = collision.gameObject.GetComponent<Player_Raycast>();

        if (granjeroMovement != null && playerRaycast.allowTrampoline)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.up * _bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    [SerializeField] private float bounce = 40f;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent<GranjeroMovement>() != null) && (collision.gameObject.GetComponent<Player_Raycast>()._allowTrampoline != null))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<GranjeroMovement>() && collision.gameObject.GetComponent<Player_Raycast>()._allowTrampoline)
    //    {
    //        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
    //    }
        
    //}
}

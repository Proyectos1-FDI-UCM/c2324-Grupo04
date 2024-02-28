using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    [SerializeField]
    private float bounce = 20f;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Granjero"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * bounce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamagecomponent : MonoBehaviour
{

    HPManager HPManager;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HPManager = GetComponent<HPManager>();
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if (HPManager != null)
        {
            HPManager.changeCurrentHealth(damage);
        }
    }
}

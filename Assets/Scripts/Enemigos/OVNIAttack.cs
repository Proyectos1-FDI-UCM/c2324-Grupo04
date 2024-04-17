using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVNIAttack : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject attackCharge;

    public void Attacking(ref bool attacking)
    {
        if (attacking)
        {
            attackArea.SetActive(true);
            attackCharge.SetActive(true);
            //attackCharge.GetComponent<SpriteRenderer>().
        }
        else
        {
            attackArea.SetActive(false);
            attackCharge.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        attackArea.SetActive(false);
        attackCharge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

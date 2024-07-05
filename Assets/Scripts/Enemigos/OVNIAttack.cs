using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVNIAttack : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject attackCharge;
    private Collider2D collision;
    [SerializeField] private Vector3 scaleChange, maxScale;

    public void Attacking(ref bool attacking)
    {
        if (attacking)
        {
            attackCharge.SetActive(true);
            attackCharge.transform.localScale += scaleChange;
        }

        if (attackCharge.transform.localScale.x > maxScale.x - 0.5)
        {
            attackArea.SetActive(true);
        }

        if (attackCharge.transform.localScale.x > maxScale.x)
        {
            attackCharge.SetActive(false);
            attackArea.SetActive(false);
            attackCharge.transform.localScale -= maxScale;
            attacking = false;
        }  
    }

    // Start is called before the first frame update
    void Start()
    {
        attackArea.SetActive(false);
        attackCharge.SetActive(false);
        scaleChange = new Vector3(0.05f, 0f, 0f);
        maxScale = new Vector3(5f, 0f, 0f);
    }
}

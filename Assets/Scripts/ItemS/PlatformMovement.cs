using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    private float waitTime;
    [SerializeField] private Transform[] moveSpots;
    [SerializeField] private float startWaitTime = 2;
    private int i = 0;
    private Vector2 actualPos;
    //NUEVOS ELEMENTOS
    [SerializeField]private bool esPeso;
    private Control_ObjetosActivadosPorBotón controlObjetos;

    void Start()
    {
        waitTime = startWaitTime;
        controlObjetos = GetComponent<Control_ObjetosActivadosPorBotón>();
    }

    private void Update()
    {   
        bool pesoActivo = controlObjetos.setActive1;
        if (esPeso)
        {  
            if (pesoActivo == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[0].transform.position, speed * Time.deltaTime);
            } else
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[1].transform.position, speed * Time.deltaTime);
            }

        } else 
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
            {
                if (waitTime <= 0)
                {
                    if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }

                    waitTime = startWaitTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
		  collision.collider.transform.SetParent(transform);
	  }

    private void OnCollisionExit2D(Collision2D collision)
    {
		  collision.collider.transform.SetParent(null);
	}*/
}

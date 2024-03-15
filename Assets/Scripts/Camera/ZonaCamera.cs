using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZonaCamera : MonoBehaviour
{
	[SerializeField] private Transform Centro;
	[SerializeField] private Transform Granjero;
	private bool dentro=false;
	[SerializeField] private CinemachineVirtualCamera vcam;

	private void Start()
	{
		
	}

	void OnTriggerEnter2D(Collider2D collision) // Se activa cuando �lgo colisiona con �l
	{
		//vcam = GetComponent<CinemachineVirtualCamera>();
		//if (vcam != null) Debug.Log("Vcam buena");
 		GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement
		Debug.Log("Colision");

		if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
		{
			Debug.Log("TrueColision");
			if (!dentro)
			{
				vcam.Follow = Centro;
				dentro = true;
				Debug.Log("Dentro");
			}
			else
			{
				vcam.Follow = Granjero;
				dentro = false;
				Debug.Log("Fuera");
			}
		}else
		{
			Debug.Log("Null");
		}
	}
}



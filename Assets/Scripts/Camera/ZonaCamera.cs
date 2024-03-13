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

	void OnTriggerEnter2D(Collider2D collision) // Se activa cuando �lgo colisiona con �l
	{
		var vcam = GetComponent<CinemachineVirtualCamera>().Follow;
		GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

		if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
		{
			if (!dentro)
			{
				vcam = Centro;
				dentro = true;
				Debug.Log("Dentro");
			}
			else
			{
				vcam = Granjero;
				dentro = false;
				Debug.Log("Fuera");
			}
		}else
		{
			Debug.Log("Null");
		}
	}
}



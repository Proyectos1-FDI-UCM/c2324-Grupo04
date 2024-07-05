using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZonaCamera : MonoBehaviour
{
	[SerializeField] private Transform CentroDentro;
	[SerializeField] private Transform Granjero;
	[SerializeField] private CinemachineVirtualCamera vcam;
	[SerializeField] private Transform camerapos;
	private bool dentro = false;
	private float time;

	private void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D collision) // Se activa cuando �lgo colisiona con �l
	{
		//vcam = GetComponent<CinemachineVirtualCamera>();
		//if (vcam != null) Debug.Log("Vcam buena");
		GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement
		if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
		{
			vcam.Follow = CentroDentro;
			dentro = true;
		}
	}
	void OnTriggerExit2D(Collider2D collision) // Se activa cuando �lgo colisiona con �l
	{
		//vcam = GetComponent<CinemachineVirtualCamera>();
		//if (vcam != null) Debug.Log("Vcam buena");
		GranjeroMovement granjeroMovement = collision.GetComponent<GranjeroMovement>(); // Busca un componente del tipo GranjeroMovement

		if (granjeroMovement != null) // Comprueba que granjeroMovement existe (y por tanto que lo que ha chocado es el granjero)
		{
            vcam.Follow = Granjero;
			dentro = false;
		}
    }
}
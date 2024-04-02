using UnityEngine;

public class MostrarCanvas : MonoBehaviour
{
    public Canvas canvas;
    public float duracionVisible = 5.0f; 

    private float tiempoInicioVisible;

    void Start()
    {
        canvas.enabled = false;
    }

    public void Mostrar()
    {
        canvas.enabled = true;
        tiempoInicioVisible = Time.time;
        Invoke("Ocultar", duracionVisible);
    }

    public void Ocultar()
    {
        canvas.enabled = false;
    }
}

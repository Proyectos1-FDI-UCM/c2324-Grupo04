using UnityEngine;
using UnityEngine.EventSystems;

public class Meta_NoLaEmpresa : MonoBehaviour
{
    private bool FinPartida = false;
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject resetButton;
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.GetComponent<GranjeroMovement>() && GameManager.Instance.cargandoOveja == true || Collider.gameObject.GetComponent<OvejaBalido>())
        {
            FinPartida = true;
            victory.SetActive(true);
            Time.timeScale = 0.0f;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(resetButton);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        victory.SetActive(false);
    }
}

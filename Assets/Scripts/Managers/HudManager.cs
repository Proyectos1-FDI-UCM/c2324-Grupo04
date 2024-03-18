using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public static HudManager instance;
    
    [SerializeField] private TMP_Text coinText;
  	[SerializeField] private TMP_Text cuerdaText;
	private int currentCoins;
    private int currentCuerda;
    private int cuerdaTexto;


	void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "X " + currentCoins.ToString();
		    cuerdaText.text = "X " + currentCuerda.ToString();
	}

    // Update is called once per frame
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "X " + currentCoins.ToString();
    }
	public void UpdateCuerda(int v)
	{
        currentCuerda = v * GameManager.Instance.ObtenerCuerdas();
        Debug.Log(currentCuerda);
	  	cuerdaText.text = "X " + currentCuerda.ToString();
  	}

}

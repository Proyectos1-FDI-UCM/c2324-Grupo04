using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public static HudManager instance;
    
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private int currentCoins = 0;


    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "X " + currentCoins.ToString();
    }

    // Update is called once per frame
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "X " + currentCoins.ToString();
    }
}

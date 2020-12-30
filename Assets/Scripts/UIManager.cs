using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;

    void Start()
    {
        _coinText.text = "Coins: 0";
    }

    public void UpdateCoinText(int coins)
    {
        _coinText.text = "Coins: " + coins.ToString();   
    }
}

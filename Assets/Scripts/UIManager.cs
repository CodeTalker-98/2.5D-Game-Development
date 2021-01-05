using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _livesText;

    void Start()
    {
        _coinText.text = "Coins: 0";
    }

    public void UpdateCoinText(int coins)
    {
        _coinText.text = "Coins: " + coins.ToString();   
    }

   public void UpdateLivesText(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}

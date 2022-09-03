using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBank : MonoBehaviour
{
    [SerializeField] private int _amount = 0;
    [SerializeField] private TextMeshProUGUI _coinsAmountText;

    public void Add(int amount)
    {
        _amount += amount;
        UpdateText();
    }
    public void Get()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        _coinsAmountText.text = _amount.ToString();
    }
}

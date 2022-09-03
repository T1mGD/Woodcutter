using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] HealthSystem _healthSystem;
    [SerializeField] private Image _fillBar;
    [SerializeField] private TextMeshProUGUI _healthText;
    private float _fillAmount;

    private void Start()
    {
        UpdateBar();
    }
    public void UpdateBar()
    {
        _fillBar.fillAmount = 1.0f / _healthSystem.MaxHealth * _healthSystem.Health;
        _healthText.text = $"{_healthSystem.Health} / {_healthSystem.MaxHealth}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthbarBoss : MonoBehaviour
{
    [SerializeField] private Image _healbar;
    [SerializeField] private Enemy _enemy;
    private float _maxHealth;
    private void Start()
    {
        _maxHealth = _enemy.GetHealth();
    }

    private void FixedUpdate()
    {
        Debug.Log(_maxHealth);
        Debug.Log(_enemy.GetHealth());
        _healbar.fillAmount = _enemy.GetHealth() / _maxHealth;
    }
}

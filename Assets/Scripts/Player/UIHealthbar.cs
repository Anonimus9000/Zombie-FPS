using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthbar : MonoBehaviour
{
    [SerializeField] private Image _healbar;
    [SerializeField] private Player _player;
    private float _maxHealth;
    private void Start()
    {
        if (_player == null)
            _player = FindObjectOfType<Player>();
        _maxHealth = _player.GetHealth();
    }

    private void FixedUpdate()
    {
        _healbar.fillAmount = _player.GetHealth() / _maxHealth;
    }
}

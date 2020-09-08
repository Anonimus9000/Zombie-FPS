using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private float _maxHealth;
    private float _preHealth;
    private float _health;
    private float _viewHealthBar;

    private void Start()
    {
        _maxHealth = _enemy.GetHealth();
        _preHealth = _maxHealth;
        _health = _maxHealth;
        _viewHealthBar = gameObject.transform.localScale.x;
    }

    private void FixedUpdate()
    {
        _health = _enemy.GetHealth();
        
        if (_preHealth != _health)
        {
            ChangeHealthBar();
            
            _preHealth = _health;
        }
    }

    private void ChangeHealthBar()
    {
        var percentChange = (_maxHealth - _health) / _maxHealth;
        
        var scaleY = gameObject.transform.localScale.y;
        var scaleZ = gameObject.transform.localScale.z;
        
        if(_health <= 0)
            gameObject.SetActive(false);
        else
            gameObject.transform.localScale = new Vector3(_viewHealthBar - (_viewHealthBar * percentChange),
                scaleY, scaleZ);
    }
}

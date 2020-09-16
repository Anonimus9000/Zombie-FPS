using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _period;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _sumOfSpawn = 0f;
    private float _timeUntilnextSpawn;
    private float _count = 0f;

    #region MonoBehaviour
    
    private void OnValidate()
    {
        if (_sumOfSpawn < 0)
            _sumOfSpawn = 0;
    }

    private void Start()
    {
        _timeUntilnextSpawn = Random.Range(0, _period);
    }

    private void Update()
    {
        if(!IsMaxSpawned())
            CheckPeriodAndSpawn();
    }
    
    #endregion

    private void CheckPeriodAndSpawn()
    {
        _timeUntilnextSpawn -= Time.deltaTime;
        if (_timeUntilnextSpawn <= 0 && _enemy != null)
        {
            _timeUntilnextSpawn = Random.Range(0, _period);
            Spawn();
        }
    }

    private bool IsMaxSpawned()
    {
        if (_count >= _sumOfSpawn)
            return true;
        else
            return false;
    }

    private void Spawn()
    {
        Instantiate(_enemy, transform.position, transform.rotation);
        _count++;
    }

    private void CheckEnemyNull()
    {
        if(_enemy == null)
            Debug.Log("Prefab enemy on spawn is null");
    }
}

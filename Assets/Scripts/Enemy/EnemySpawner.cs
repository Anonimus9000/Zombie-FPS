using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _period;
    [SerializeField] private Enemy _enemy;
    private float _timeUntilnextSpawn;

    private void Start()
    {
        _timeUntilnextSpawn = Random.Range(0, _period);
    }

    private void Update()
    {
        _timeUntilnextSpawn -= Time.deltaTime;
        if (_timeUntilnextSpawn <= 0)
        {
            _timeUntilnextSpawn = Random.Range(0, _period);
            Instantiate(_enemy, transform.position, transform.rotation);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathToExit : MonoBehaviour
{
    [SerializeField] private UIPoint _point;
    [SerializeField] private Transform _targetExit;
    [SerializeField] private Player _player;
    private NavMeshAgent _navMeshAgent;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _navMeshAgent.SetDestination(_targetExit.position);
    }

    private void FixedUpdate()
    {
        if (_point.IsComplete())
        {
            gameObject.transform.position = _player.transform.position;
            
            _lineRenderer.positionCount = _navMeshAgent.path.corners.Length;
            _lineRenderer.SetPositions(_navMeshAgent.path.corners);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextLvL : MonoBehaviour
{
    [SerializeField] private float _speedRotate = 1f;
    [SerializeField] private UIPoint _point;
    private bool _isOpen = false;
    private Vector3 _defaultRotation;
    private Vector3 _openRotation;

    private void Start()
    {
        _defaultRotation = transform.eulerAngles;
        _openRotation = new Vector3(_defaultRotation.x, _defaultRotation.y + 90f, _defaultRotation.z);
    }

    private void Update()
    {
        if(_point.IsComplete() && !_isOpen)
            OpenDoor();
        
        if (transform.rotation.y >= 90f)
            _isOpen = true;
        if(_isOpen)
            Debug.Log("door is open");
    }

    public void OpenDoor()
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, _openRotation, Time.deltaTime * _speedRotate);
    }
}

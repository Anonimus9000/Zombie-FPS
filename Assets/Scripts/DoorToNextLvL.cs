using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextLvL : MonoBehaviour
{
    private UIPoint _point;

    private void Start()
    {
        _point = FindObjectOfType<UIPoint>();
    }

    private void Update()
    {
        if(_point.IsComplete())
            OpenDoor();
    }

    public void OpenDoor()
    {
        var openRotation = new Quaternion(0, 90, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, 1);
    }
}

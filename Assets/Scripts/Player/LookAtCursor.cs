using System;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private AimCursor _cursor;
    private void Start()
    {
        _cursor = FindObjectOfType<AimCursor>();
    }

    private void Update()
    {
        Vector3 forward = _cursor.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
    }
}

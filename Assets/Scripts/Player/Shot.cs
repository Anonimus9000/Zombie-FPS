using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private Transform _gunBarrel;
    private LineRenderer _lineRenderer;
    private bool _isVisible;
    
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    void FixedUpdate()
    {
        if (_isVisible)
            _isVisible = false;
        else
            gameObject.SetActive(false);
    }

    public void Show( Vector3 to)
    {
        _lineRenderer.SetPositions(new Vector3[]{ _gunBarrel.position, to });
        _isVisible = true;
        gameObject.SetActive(true);
    }

    public Vector3 GetGunBarrelPosition()
    {
        return _gunBarrel.transform.position;
    }
}

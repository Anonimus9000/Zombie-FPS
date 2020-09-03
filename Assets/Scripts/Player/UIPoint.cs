using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoint : MonoBehaviour
{
    [SerializeField] private Text _countKillPointText;
    [SerializeField] private Text _countText;
    [SerializeField] private Player _player;
    [SerializeField] private int _howMatchNeedKill;
    private bool _isComplete = false;

    private void Start()
    {
        _countText.text = _howMatchNeedKill.ToString();
        _countKillPointText.text = _player.GetPoint().ToString();
    }

    private void FixedUpdate()
    {
        _countKillPointText.text = _player.GetPoint().ToString();
        if (_player.GetPoint() >= _howMatchNeedKill)
            _isComplete = true;
    }

    public bool IsComplete()
    {
        return _isComplete;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWinnerText : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Text _text;

    private void FixedUpdate()
    {
        if (_enemy.GetHealth() <= 0)
            _text.text = "YOU WIN!";
    }
}

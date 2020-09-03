using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrackingMeleeEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private Player _player;
    private void OnCollisionStay(Collision other)
    {
        foreach (ContactPoint collision in other)
        {
            if (collision.otherCollider.tag == "Player")
            {
                _player = other.gameObject.GetComponent<Player>();
                _enemy.Attack(_player);
                break;
            }
        }
    }
}

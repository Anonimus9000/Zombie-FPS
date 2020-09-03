using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class  Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected Player player;

    #region MonoBehaviour
    private void OnValidate()
    {
        if (player == null)
            player = FindObjectOfType<Player>();
    }
    #endregion
    
    public float GetHealth()
    {
        return health;
    }
    public virtual void TakeDamage(float damage)
    {
        if (health > 0)
            health -= damage;
    }
    public abstract void Attack(Player player);
    
    public abstract void Kill();

    public abstract void Stay();

    public abstract void StopStay();
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Zombie : Enemy
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private bool _isCanAttack = true;

    #region MonoBehaviour
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _navMeshAgent.speed = speed;
    }

    private void Update()
    {
        if(_isCanAttack)
            StopCoroutine(nameof(TimerAttack));
        
        _animator.SetFloat("Speed", _navMeshAgent.velocity.magnitude);
        
        if(health <= 0)
            Kill();
    }

    private void FixedUpdate()
    {
        _navMeshAgent.SetDestination(player.transform.position);
    }
    
    #endregion
    
    public override void Attack(Player player)
    {
        if (_isCanAttack)
        {
            _isCanAttack = false;
            player.TakeDamage(damage);
            _animator.SetTrigger("Attack");
            StartCoroutine(TimerAttack(1 / attackSpeed));
        }
    }

    public override void TakeDamage(float damage)
    {
        GetComponentInChildren<ParticleSystem>().Play();
        base.TakeDamage(damage);
    }

    public override void Kill()
    {
        _animator.SetTrigger("Death");
        
        Stay();
        
        Destroy(GetComponent<BoxCollider>());
    }

    public override void Stay()
    {
        _navMeshAgent.speed = 0;
    }

    public override void StopStay()
    {
        _navMeshAgent.speed = speed;
    }

    IEnumerator TimerAttack(float waitTimePerSecond)
    {
        yield return new WaitForSeconds(waitTimePerSecond);
        
        _isCanAttack = true;
    }
}

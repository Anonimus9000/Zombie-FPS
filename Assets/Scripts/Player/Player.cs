using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Shot _shot;
    [SerializeField] private float _helth;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _damage;
    private Rigidbody _rigidbody;
    private PlayerAnimatorController _playerAnimator;
    private AimCursor _aim;
    private PlayerAudio _playerAudio;
    private bool _isCanAttack = true;
    private int _countPointKill;

    #region MonoBehaviour
    private void OnValidate()
    {
        if (_speed < 0)
            _speed = 0;
        if (_helth < 0)
            _helth = 0;
        if (_attackSpeed < 0)
            _attackSpeed = 0;
        if (_damage < 0)
            _damage = 0;
    }
    
    private void Start()
    {
        _playerAudio = GetComponentInChildren<PlayerAudio>();
        _rigidbody = GetComponent<Rigidbody>();
        _aim = FindObjectOfType<AimCursor>();
        _playerAnimator = GetComponentInChildren<PlayerAnimatorController>();
    }
    
    private void Update()
    {
        _playerAnimator.SetAxis(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(_helth <= 0)
            Kill();
        
        if( Input.GetButtonDown("Fire1"))
            Attack();
    }

    private void FixedUpdate()
    {
        MovementLogic();
        
        if(_isCanAttack)
            StopCoroutine(nameof(TimerAttack));
    }
    
    #endregion

    public float GetHealth()
    {
        return _helth;
    }

    public int GetPoint()
    {
        return _countPointKill;
    }
    public void AddPoint()
    {
        _countPointKill++;
    }
    
    public void TakeDamage(float damage)
    {
        _playerAnimator.TakeHit();
        
        if(_helth > 0)
            _helth -= damage;
    }
    private void MovementLogic()
    {
        var axisVertical = Input.GetAxis("Vertical");
        var axisHorizontal = Input.GetAxis("Horizontal");
        
        var direction  = new Vector3(axisHorizontal, 0, axisVertical);
        direction = direction.normalized;
        
        _rigidbody.AddRelativeForce(direction * _speed);
    }

    private void Attack()
    {
        if (_isCanAttack)
        {
            _playerAnimator.Shoot();
            _playerAudio.StartAudioShot();
            Shot();
            
            _isCanAttack = false;
            
            StartCoroutine(TimerAttack(1 / _attackSpeed));
        }
    }
    private void Shot()
    {
        var target = _aim.transform.position;
        var to = new Vector3(target.x, _shot.GetGunBarrelPosition().y, target.z);
        var direction = (to - _shot.GetGunBarrelPosition()).normalized;

        RaycastHit hit;
        if (Physics.Raycast(_shot.GetGunBarrelPosition(), to - _shot.GetGunBarrelPosition(), 
            out hit, 100))
            to = new Vector3(hit.point.x, _shot.GetGunBarrelPosition().y, hit.point.z);
        else
            to = _shot.GetGunBarrelPosition() + direction * 100;
        
        SetDamageFromShot(hit);
        
        _shot.Show(to);
    }

    private void SetDamageFromShot(RaycastHit hit)
    {
        if (hit.transform != null) {
            var zombie = hit.transform.GetComponent<Zombie>();
            var burrel = hit.transform.GetComponent<BurrelExplosion>();
            if (zombie != null)
            {
                zombie.TakeDamage(_damage);
                if(zombie.GetHealth() <= 0)
                    AddPoint();
            }

            if (burrel != null)
                burrel.Explosion();
        }
    }
    private void Kill()
    {
        _playerAnimator.Death();
    }
    
    IEnumerator TimerAttack(float waitTimePerSecond)
    {
        yield return new WaitForSeconds(waitTimePerSecond);
        
        _isCanAttack = true;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private float _axisHorizontal;
    private float _axisVertical;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Shoot1 = Animator.StringToHash("Shoot");
    private static readonly int Death1 = Animator.StringToHash("Death");
    private static readonly int Hit = Animator.StringToHash("TakeHit");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        SetSpeed(_axisHorizontal, _axisVertical);
    }

    public void SetAxis(float axisHorizontal, float axisVertical)
    {
        _axisHorizontal = axisHorizontal;
        _axisVertical = axisVertical;
    }

    public void Shoot()
    {
        _animator.SetTrigger(Shoot1);
    }

    public void Death()
    {
        _animator.SetTrigger(Death1);
    }

    public void TakeHit()
    {
        _animator.SetTrigger(Hit);
    }

    private void SetSpeed(float axisHorizontal, float axisVertical)
    {
        axisVertical = Mathf.Abs(axisVertical);
        axisHorizontal = Mathf.Abs(axisHorizontal);

        if(axisVertical > axisHorizontal)
            _animator.SetFloat(Speed, axisVertical);
        else 
            _animator.SetFloat(Speed, axisHorizontal);
    }
}

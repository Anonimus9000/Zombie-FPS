using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void TakeDamage(float damage);

    void Attack(Player player);

    void Kill();

    void Stay();

    void StopStay();
}

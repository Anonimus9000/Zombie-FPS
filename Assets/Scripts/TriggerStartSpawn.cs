using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStartSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Spawner.SetActive(true);
        }
    }
}

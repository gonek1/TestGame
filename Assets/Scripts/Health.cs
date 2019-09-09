using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healtpoint;
    public GameObject ChestPrefab;
    public int Healtpoint { get => _healtpoint; set => _healtpoint = value; }
    public void TakeDamage(int _damage)
    {
        Healtpoint -= _damage;
        if (Healtpoint<=0)
        {
           
            Die();
        }
    }

    private void Die()
    {
       
        Instantiate(ChestPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}

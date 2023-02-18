using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Destroy(gameObject);
        }
    }



}

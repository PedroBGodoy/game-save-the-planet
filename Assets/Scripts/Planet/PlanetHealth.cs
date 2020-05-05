using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private bool isInvincible = false;

    public int health { get; private set; }

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        health -= damage;
        if (health <= 0)
            health = 0;
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

}

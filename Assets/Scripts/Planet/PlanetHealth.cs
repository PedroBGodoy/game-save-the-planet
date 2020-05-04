using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int health = 3;
    [SerializeField] private bool isInvincible = false;

    private void Awake()
    {
        health = maxHealth;
    }

    private void OnEnable()
    {
        GameManager.OnPlay += OnPlay;
    }

    private void OnDisable()
    {
        GameManager.OnPlay -= OnPlay;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        health -= damage;
        if (health <= 0)
        {
            health = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        GameManager.instance.GameOver();
    }

    private void OnPlay()
    {
        health = maxHealth;
    }

}

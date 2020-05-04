using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private MoveTowardsPlanet movementController;

    [SerializeField] private int damage = 1;

    private void Awake()
    {
        movementController = GetComponent<MoveTowardsPlanet>();
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        GameManager.OnReset += OnReset;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        GameManager.OnReset -= OnReset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planet")
        {
            PlanetHealth planetHealth = other.GetComponent<PlanetHealth>();
            if (planetHealth)
            {
                planetHealth.TakeDamage(damage);
            }
            else
            {
                Debug.Log("[MeteorController][Error] PlanetHealth not found on collider!");
            }
        }
        else if (other.tag == "Shield")
        {
            if (GameManager.instance)
            {
                GameManager.instance.AddScore();
            }
        }
        Destroy(this.gameObject);
    }

    private void OnGameOver()
    {
        if (movementController)
        {
            movementController.canMove = false;
        }
    }

    private void OnReset()
    {
        Destroy(this.gameObject);
    }

}

using System;
using UnityEngine;

[RequireComponent(typeof(MoveTowardsPlanet))]
public class MeteorController : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private Action<GameObject> onDestroyCallback;
    private MoveTowardsPlanet movementController;
    private GameManager gameManager;

    public void Initializer(Action<GameObject> callback, GameManager _gameManager)
    {
        onDestroyCallback = callback;
        gameManager = _gameManager;
    }

    private void Awake()
    {
        movementController = GetComponent<MoveTowardsPlanet>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planet")
            HandlePlayerCollision(other);
        else if (other.tag == "Shield")
            HandleShieldCollision(other);

        onDestroyCallback(this.gameObject);
        Destroy(this.gameObject);
    }

    private void HandlePlayerCollision(Collider2D collider)
    {
        collider.GetComponent<Planet>().PlanetHealth.TakeDamage(damage);
    }

    private void HandleShieldCollision(Collider2D collider)
    {
        gameManager.Score.AddScore();
    }

    public void StopMovement()
    {
        movementController.canMove = false;
    }

    public void ResumeMovement()
    {
        movementController.canMove = true;
    }

}

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
        movementController = this.GetComponent<MoveTowardsPlanet>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planet")
        {
            HandlePlanetCollision(other);
        }
        else if (other.tag == "Shield")
        {
            HandleShieldCollision(other);
        }

        DestroyThis();
    }

    private void DestroyThis()
    {
        onDestroyCallback(this.gameObject);
        Destroy(this.gameObject);
    }

    private void HandlePlanetCollision(Collider2D collider)
    {
        collider.GetComponent<Planet>().PlanetHealth.TakeDamage(damage);
        gameManager.CheckPlayerHealth();
    }

    private void HandleShieldCollision(Collider2D collider)
    {
        gameManager.Score.AddScore();
        gameManager.UpdateScoreHUD();
    }

    public void StopMovement() => movementController.canMove = false;
    public void ResumeMovement() => movementController.canMove = true;

}

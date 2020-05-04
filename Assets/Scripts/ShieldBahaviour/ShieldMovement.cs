using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private bool canRotate = true;

    private float xMov = 0;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        GameManager.OnPlay += OnPlay;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        GameManager.OnPlay -= OnPlay;
    }
    private void Update()
    {
        xMov = Input.GetAxisRaw("Horizontal");

        if (canRotate)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, -xMov * speed * Time.deltaTime);
    }

    private void OnGameOver()
    {
        canRotate = false;
    }

    private void OnPlay()
    {
        canRotate = true;
    }

}

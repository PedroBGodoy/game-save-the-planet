using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlanet : MonoBehaviour
{

    public bool canMove = true;

    [Header("Obj Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float targetDistanceTolerance = 1.4f;

    [Header("Debug")]
    [SerializeField] private bool drawLine = false;

    private float distance = 0.0f;
    private Vector3 targetPosition;

    private void Awake()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Planet").transform.position;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, targetPosition);
        if (distance >= targetDistanceTolerance && canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 dir = (targetPosition - transform.position).normalized;
        dir.z = 0;

        transform.Translate(dir * speed * Time.deltaTime);

        if (drawLine)
            Debug.DrawLine(transform.position, transform.position + (dir * distance), Color.red);
    }

}

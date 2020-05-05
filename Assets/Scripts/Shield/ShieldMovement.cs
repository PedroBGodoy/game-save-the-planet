using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private float inMenuRotationSpeed = 10f;
    [SerializeField] private bool canRotate = true;

    private float xMov = 0;
    private bool inMenuRotation = true;

    private void Update()
    {
        xMov = Input.GetAxisRaw("Horizontal");

        if (canRotate)
            Rotate();

        if (inMenuRotation)
            AutoRotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, 0, -xMov * speed * Time.deltaTime);
    }

    private void AutoRotate()
    {
        transform.Rotate(0, 0, inMenuRotationSpeed * Time.deltaTime);
    }

    public void EnableMovement()
    {
        canRotate = true;
        inMenuRotation = false;
    }

    public void BlockMovement()
    {
        canRotate = false;
    }

    public void EnableAutoRotation()
    {
        inMenuRotation = true;
        canRotate = false;
    }

    public void DisableAutoRotation()
    {
        inMenuRotation = false;
    }

}

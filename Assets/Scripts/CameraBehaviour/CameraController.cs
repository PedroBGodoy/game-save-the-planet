using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float inMenuPosition = -15f;
    [SerializeField] private float inGamePosition = -10f;
    [SerializeField] private float translationSpeed = .5f;
    public AnimationCurve translationCurve;

    private Camera cam;
    private float targetPosition = -15f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        targetPosition = transform.position.z;
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        GameManager.OnPlay += OnPlay;
        GameManager.OnMenu += OnMenu;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        GameManager.OnPlay -= OnPlay;
        GameManager.OnMenu -= OnMenu;
    }

    private void Update()
    {
        float distance = transform.position.z - targetPosition;

        if (Mathf.Abs(distance) >= 0.05f)
        {
            float translation = translationCurve.Evaluate(1 / Mathf.Abs(distance)) * Time.deltaTime * translationSpeed;
            translation *= distance > 0 ? -1 : 1;
            cam.transform.position = new Vector3(0, 0, transform.position.z + translation);
        }
    }

    private void OnGameOver()
    {
        targetPosition = inGamePosition;
    }

    private void OnPlay()
    {
        targetPosition = inGamePosition;
    }

    private void OnMenu()
    {
        targetPosition = inMenuPosition;
    }

}

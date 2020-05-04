using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private bool canSpawn = false;
    [SerializeField] private bool isSpawning = false;
    [SerializeField] private bool fakeSpawn = false;
    [SerializeField] private float spawnDistanceFromBoundary = 1f;
    [SerializeField] private float startSpawnDelay = 3f;

    public GameObject meteorPrefab;

    private Vector2 screenBounds;

    private void Awake()
    {
        CheckPrefabs();
        GetScreenBoundary();
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
        if (canSpawn && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine("SpawnMeteor");
        }
    }

    IEnumerator SpawnMeteor()
    {
        Vector3 spawnPoint = GetSpawnPoint();

        if (!fakeSpawn)
        {
            GameObject instance = Instantiate(meteorPrefab, spawnPoint, Quaternion.identity);
        }

        yield return new WaitForSeconds(1 / spawnRate);

        if (canSpawn)
            StartCoroutine("SpawnMeteor");
        else
            isSpawning = false;
    }

    private Vector3 GetSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        int side = Random.Range(1, 4 + 1);
        switch (side)
        {
            case 1:
                spawnPoint.x = Random.Range(-screenBounds.x, screenBounds.x + 1);
                spawnPoint.y = screenBounds.y;
                break;
            case 2:
                spawnPoint.y = Random.Range(-screenBounds.y, screenBounds.y + 1);
                spawnPoint.x = screenBounds.x;
                break;
            case 3:
                spawnPoint.x = Random.Range(-screenBounds.x, screenBounds.x + 1);
                spawnPoint.y = -screenBounds.y;
                break;
            case 4:
                spawnPoint.y = Random.Range(-screenBounds.y, screenBounds.y + 1);
                spawnPoint.x = -screenBounds.x;
                break;
        }

        return spawnPoint;
    }

    private void GetScreenBoundary()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        screenBounds.y += spawnDistanceFromBoundary;
        screenBounds.x += spawnDistanceFromBoundary;
    }

    private void CheckPrefabs()
    {
        if (!meteorPrefab)
        {
            Debug.Log("[Spawner][Error] Meteor prefab missing!");
            canSpawn = false;
        }
    }

    private void OnGameOver()
    {
        canSpawn = false;
        isSpawning = false;
        StopAllCoroutines();
    }

    private void OnPlay()
    {
        StartCoroutine("StartSpawner");
    }

    private void OnMenu()
    {
        canSpawn = false;
        isSpawning = false;
        StopAllCoroutines();
    }

    IEnumerator StartSpawner()
    {
        yield return new WaitForSeconds(startSpawnDelay);

        canSpawn = true;
    }

}

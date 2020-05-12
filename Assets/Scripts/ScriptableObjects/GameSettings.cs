using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "SaveThePlanet/GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    [Header("Level Settings")]
    public Level defaultLevel;

    [Header("Planet Settings")]
    public int player_maxHealth = 3;

    [Header("Shield Settings")]
    public float shield_Speed = 175f;
    public float shield_inMenuSpeed = 10f;

    [Header("Spawner Settings")]
    public float spawn_Rate = 0.75f;
    public float spawn_DistanceFromBoundary = 2;
    public float spawn_startDelay = 3;
    public GameObject spawn_meteorPrefab = null;

    [Header("Camera Settings")]
    public float cam_inMenuPosition = -20f;
    public float cam_inGamePosition = -15f;
    public float cam_translationSpeed = 5f;

    [Header("General Settings")]
    public float resumeGameSeconds = 3f;
}

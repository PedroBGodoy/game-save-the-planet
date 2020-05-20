using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Level[] levels = { };

    private Level _currentLevel;
    private GameManager _gameManager;
    private Planet _currentPlanet;

    public Planet CurrentPlanet => _currentPlanet;
    public Level CurrentLevel => _currentLevel;

    public void Initialize(GameManager manager, Level defaultLevel)
    {
        _gameManager = manager;
        ChangeLevel(defaultLevel);
    }

    public void ChangeLevel(int levelIndex)
    {
        foreach (Level level in levels)
        {
            if (level.index == levelIndex)
            {
                ChangeLevel(level);
                return;
            }
        }
    }
    public void ChangeLevel(string levelName)
    {
        foreach (Level level in levels)
        {
            if (level.Name == levelName)
            {
                ChangeLevel(level);
                return;
            }
        }
    }
    public void ChangeLevel(Level level)
    {
        if (!level)
            return;

        if (_currentPlanet)
            Destroy(_currentPlanet.gameObject);

        _currentLevel = level;
        InstantiatePlanet();
        _gameManager.GameStateMachine.OnLevelChange(_currentLevel);
    }

    public void NextLevel()
    {
        int levelIndex = _currentLevel.index + 1;

        if (levelIndex <= levels.Length)
            ChangeLevel(levelIndex);
    }

    public void PreviousLevel()
    {
        int levelIndex = _currentLevel.index - 1;

        if (levelIndex >= 0)
            ChangeLevel(levelIndex);
    }

    private void InstantiatePlanet()
    {
        var instance = Instantiate(CurrentLevel.PlanetPrefab, Vector3.zero, Quaternion.identity);
        _currentPlanet = instance.GetComponent<Planet>();
    }

}

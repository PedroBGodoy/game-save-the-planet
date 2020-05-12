using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private HUD hud = null;
    [SerializeField] private Spawner spawner = null;
    [SerializeField] private Shield shield = null;
    [SerializeField] private CameraController cameraController = null;
    [SerializeField] private GameSettings gameSettings = null;
    [SerializeField] private LevelManager levelManager = null;

    private GameStateMachine gameStateMachine;
    private ScoreController scoreController = new ScoreController();

    public HUD HUD => hud;
    public ScoreController ScoreController => scoreController;
    public Spawner Spawner => spawner;
    public Planet Planet => levelManager.CurrentPlanet;
    public Shield Shield => shield;
    public CameraController Camera => cameraController;
    public GameSettings GameSettings => gameSettings;
    public GameStateMachine GameStateMachine => gameStateMachine;
    public LevelManager LevelManager => levelManager;

    private void Awake()
    {
        gameStateMachine = this.GetComponent<GameStateMachine>();

        CheckGameSettings();

        gameStateMachine.Initialize(this);
        spawner.Initializer(this);
        levelManager.Initialize(this, gameSettings.defaultLevel);
    }

    private void OnApplicationPause(bool pauseStatus) => gameStateMachine.OnPause();

    private void CheckGameSettings()
    {
        if (gameSettings) return;

        Debug.LogError("[GameManager][CRITICAL] No GameSettings found! Desabling component!");
        this.enabled = false;
    }

}

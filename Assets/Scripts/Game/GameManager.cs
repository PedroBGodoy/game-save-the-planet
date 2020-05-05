using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private HUD hud = null;
    [SerializeField] private Spawner spawner = null;
    [SerializeField] private Planet planet = null;
    [SerializeField] private Shield shield = null;
    [SerializeField] private CameraController cameraController = null;
    [SerializeField] private GameSettings gameSettings = null;

    private GameStateMachine gameStateMachine;
    private ScoreController scoreController = new ScoreController();

    public HUD HUD => hud;
    public ScoreController Score => scoreController;
    public Spawner Spawner => spawner;
    public Planet Planet => planet;
    public Shield Shield => shield;
    public CameraController Camera => cameraController;
    public GameSettings GameSettings => gameSettings;
    public GameStateMachine GameStateMachine => gameStateMachine;

    private void Awake()
    {
        gameStateMachine = this.GetComponent<GameStateMachine>();

        gameStateMachine.Initialize(this);
        spawner.Initializer(this);

        CheckGameSettings();
    }

    public void CheckPlayerHealth()
    {
        if (planet.PlanetHealth.health == 0)
            GameStateMachine.OnGameOver();
    }

    public void UpdateScoreHUD()
    {
        HUD.UpdateScore(scoreController.GetScore());
    }

    private void CheckGameSettings()
    {
        if (gameSettings) return;

        Debug.LogError("[GameManager][CRITICAL] No GameSettings found! Desabling component!");
        this.enabled = false;
    }

}

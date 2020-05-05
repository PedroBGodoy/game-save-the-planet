using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private HUD hud = null;
    [SerializeField] private Spawner spawner = null;
    [SerializeField] private Planet planet = null;
    [SerializeField] private Shield shield = null;
    [SerializeField] private CameraController cameraController = null;
    [SerializeField] private GameSettings gameSettings = null;

    private StateMachine stateMachine;
    private ScoreController scoreController = new ScoreController();

    public HUD HUD => hud;
    public ScoreController Score => scoreController;
    public Spawner Spawner => spawner;
    public Planet Planet => planet;
    public Shield Shield => shield;
    public CameraController Camera => cameraController;
    public GameSettings GameSettings => gameSettings;
    public StateMachine StateMachine => stateMachine;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();

        stateMachine.Initialize(this);
        spawner.Initializer(this);

        if (!gameSettings)
        {
            Debug.LogError("[GameManager][CRITICAL] No GameSettings found!");
            this.enabled = false;
        }
    }

    private void Update()
    {
        CheckPlayerHealth();
    }

    private void CheckPlayerHealth()
    {
        if (planet.PlanetHealth.health == 0)
            StateMachine.OnGameOver();
    }
}

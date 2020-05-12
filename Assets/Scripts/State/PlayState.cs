using UnityEngine;

public class PlayState : GameState
{
    public PlayState(GameManager _manager) : base(_manager) { }

    public override void Start()
    {
        manager.ScoreController.ResetScore();
        manager.HUD.UpdateScore(manager.ScoreController.GetScore());
        manager.Planet.PlanetHealth.ResetHealth();

        manager.HUD.Play();
        manager.Shield.ShieldMovement.EnableMovement();
        manager.Spawner.StartSpawner();
        manager.Camera.MoveCameraTo(manager.GameSettings.cam_inGamePosition);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            manager.GameStateMachine.OnPause();
    }

    public override void GameOver() => manager.GameStateMachine.SetState(new GameOverState(manager));

    public override void Pause() => manager.GameStateMachine.SetState(new PauseState(manager));

    public override void CheckPlanetHealth()
    {
        if (manager.Planet.PlanetHealth.health <= 0)
            manager.GameStateMachine.OnGameOver();
    }
    private void UpdateScore() => manager.HUD.UpdateScore(manager.ScoreController.GetScore());

}

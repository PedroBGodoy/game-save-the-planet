using System.Collections;
using UnityEngine;

public class PlayState : GameState
{
    public PlayState(GameManager _manager) : base(_manager) { }

    public override void Start()
    {
        manager.Score.ResetScore();
        manager.UpdateScoreHUD();
        manager.Planet.PlanetHealth.ResetHealth();

        manager.HUD.Play();
        manager.Shield.ShieldMovement.EnableMovement();
        manager.Spawner.StartSpawner();
        manager.Camera.MoveCameraTo(manager.GameSettings.cam_inGamePosition);
    }

    public override void GameOver()
    {
        manager.GameStateMachine.SetState(new GameOverState(manager));
    }

    public override void Pause()
    {
        manager.Spawner.StopSpawner();
        manager.Spawner.StopAllObjectsMovement();
    }

    public override IEnumerator Resume()
    {
        manager.Spawner.StartSpawner();
        manager.Spawner.ResumeAllObjectsMovement();

        yield return new WaitForSeconds(manager.GameSettings.resumeGameSeconds);
    }
}

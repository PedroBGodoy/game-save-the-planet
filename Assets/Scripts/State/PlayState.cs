using System.Collections;
using UnityEngine;

public class PlayState : State
{
    public PlayState(GameManager _manager) : base(_manager) { }

    public override IEnumerator Start()
    {
        manager.Score.ResetScore();
        manager.Planet.PlanetHealth.ResetHealth();

        manager.HUD.Play();
        manager.Shield.ShieldMovement.EnableMovement();
        manager.Spawner.StartSpawner();
        manager.Camera.MoveCameraTo(manager.GameSettings.cam_inGamePosition);
        yield break;
    }

    public override IEnumerator GameOver()
    {
        manager.StateMachine.SetState(new GameOverState(manager));
        yield break;
    }

    public override IEnumerator Pause()
    {
        manager.Spawner.StopSpawner();
        manager.Spawner.StopAllObjectsMovement();
        yield break;
    }

    public override IEnumerator Resume()
    {
        manager.Spawner.StartSpawner();
        manager.Spawner.ResumeAllObjectsMovement();
        yield break;
    }
}
